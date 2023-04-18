create table COMPRA(
IdCompra		int primary key identity,
IdUsuarioC		int,
IdProveedorC	int,
MontoTotal		decimal(10,2) default 0,
TipoDocumento	varchar(50) default 'Boleta',
NumeroDocumento varchar(50),
FechaRegistro	datetime default getdate()
CONSTRAINT FK_IdUsuarioC FOREIGN KEY (IdUsuarioC)
    REFERENCES USUARIO(IdUsuario),
CONSTRAINT FK_IdProveedorC FOREIGN KEY (IdProveedorC)
    REFERENCES PROVEEDOR(IdProveedor)
)

go


create table DETALLE_COMPRA(
IdDetalleCompra int primary key identity,
IdCompraDC int references COMPRA(IdCompra),
IdProductoDC int references Producto(IdProducto),
Cantidad int,
PrecioCompra decimal(10,2),
PrecioVenta decimal(10,2),
Total decimal(10,2),
FechaRegistro datetime default getdate()
CONSTRAINT FK_IdCompraDC FOREIGN KEY (IdCompraDC)
    REFERENCES COMPRA(IdCompra),
CONSTRAINT FK_IdProductoDC FOREIGN KEY (IdProductoDC)
    REFERENCES PRODUCTO(IdProducto)
)

go

 create procedure sp_RegistrarCompra
(
	@IdUsuario int,
	@IdProveedor int,
	@TipoDocumento varchar(500),
	@NumeroDocumento varchar(500),
	@MontoTotal decimal(18,2),
	@DetalleCompra [EDetalle_Compra] READONLY,
	@Resultado bit output,
	@Mensaje varchar(500) output
)
as
begin
	begin try
		declare	@idcompra int = 0
			set @Resultado = 1
			set @Mensaje = ''

			begin transaction registro
				
				insert into COMPRA (IdUsuario,IdProveedor,TipoDocumento,NumeroDocumento,MontoTotal)
				values(@IdUsuario,@IdProveedor,@TipoDocumento,@NumeroDocumento,@MontoTotal)

				set @idcompra = SCOPE_IDENTITY()

				insert into DETALLE_COMPRA(IdCompraDC,IdProductoDC,PrecioCompra,PrecioVenta,Cantidad,Total)
				select @idcompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal from @DetalleCompra

				update p set p.Stock = p.Stock +dc.Cantidad,
				p.PrecioCompra = dc.PrecioCompra,
				p.PrecioVenta = dc.PrecioVenta
				from PRODUCTO p
				inner join @DetalleCompra dc on dc.IdProducto = p.IdProducto

			commit transaction registro

	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registo
	end catch
end
go


/* 
create proc sp_ReporteCompras
(
@fechainicio varchar(10),
@fechafin varchar(10),
@idproveedor int
)
as
begin
set dateformat dmy;
select
CONVERT(char(10),c.FechaRegistro,103)[FechaRegistro],c.TipoDocumento,c.NumeroDocumento,c.MontoTotal,
u.NombreCompleto[UsuarioRegistro],
pr.Documento[DocumentoProveedor],pr.RazonSocial,
p.Codigo[CodigoProducto],p.Nombre[NombreProducto],ca.Descripcion[Categoria],dc.PrecioCompra,dc.PrecioVenta,dc.Cantidad,dc.MontoTotal[SubTotal]
from COMPRA c
inner join USUARIO u on u.IdUsuario = c.IdUsuario
inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor
inner join DETALLE_COMPRA dc on dc.IdCompra = c.IdCompra
inner join PRODUCTO p on p.IdProducto = dc.IdProducto
inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
where CONVERT(date,c.FechaRegistro) between @fechainicio and @fechafin
and pr.IdProveedor = iif(@idproveedor=0,pr.IdProveedor,@idproveedor)
end
go*/

drop proc sp_ReporteCompras

  create proc sp_ReporteCompras
(
@fechainicio varchar(10),
@fechafin varchar(10),
@idproveedor int
)
as
begin
set dateformat dmy;
select
CONVERT(char(10),c.FechaRegistro,103)[FechaRegistro],c.TipoDocumento,c.NumeroDocumento,c.MontoTotal,
u.NombreCompleto[UsuarioRegistro],
pr.Documento[DocumentoProveedor],pr.RazonSocial,
p.Codigo[CodigoProducto],p.Nombre[NombreProducto],dc.PrecioCompra,dc.PrecioVenta,dc.Cantidad,dc.Total[SubTotal]
from COMPRA c
inner join USUARIO u on u.IdUsuario = c.IdUsuario
inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor
inner join DETALLE_COMPRA dc on dc.IdCompraDC = c.IdCompra
inner join PRODUCTO p on p.IdProducto = dc.IdProductoDC
where CONVERT(date,c.FechaRegistro) between @fechainicio and @fechafin
and pr.IdProveedor = iif(@idproveedor=0,pr.IdProveedor,@idproveedor)
end
go

select * from DETALLE_COMPRA