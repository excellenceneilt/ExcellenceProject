create table VENTA(
IdVenta				int primary key identity,
IdTipComprobanteV	int,
NumeroDocumento		nvarchar(100),
IdClienteV			int,
DocumentoCliente	varchar(50),
NombreCliente		varchar(50),
TotalPagar			decimal(10,2),
PagoCon				decimal(10,2),
Cambio				decimal(10,2),
FechaRegistro		datetime default getdate()
CONSTRAINT FK_IdClienteV FOREIGN KEY (IdClienteV)
    REFERENCES CLIENTE(IdCliente),
CONSTRAINT FK_IdTipComprobanteV FOREIGN KEY (IdTipComprobanteV)
    REFERENCES TIPO_COMPROBANTE(IdTipoComprobante)
)

create procedure usp_RegistrarVenta
(
@IdUsuario int,
@TipoDocumento varchar(500),
@NumeroDocumento varchar(500),
@DocumentoCliente varchar(500),
@NombreCliente varchar(500),
@MontoPago decimal(18,2),
@MontoCambio decimal(18,2),
@MontoTotal decimal (18,2),
@DetalleVenta [EDetalle_Venta] READONLY,
@Resultado bit output,
@Mensaje varchar(500) output
)
as
begin
	
	begin try
		
		declare @idventa int = 0
		set @Resultado = 1
		set @Mensaje = ''

		begin transaction registro

		insert into VENTA(IdUsuario,TipoDocumento,NumeroDocumento,DocumentoCliente,NombreCliente,MontoPago,MontoCambio,MontoTotal)
		values(@IdUsuario,@TipoDocumento,@NumeroDocumento,@DocumentoCliente,@NombreCliente,@MontoPago,@MontoCambio,@MontoTotal)

		set @idventa = SCOPE_IDENTITY()

		insert into DETALLE_VENTA(IdVenta,IdProducto,PrecioVenta,Cantidad,SubTotal)
		select @idventa, IdProducto, PrecioVenta, Cantidad, SubTotal from @DetalleVenta
		
		commit transaction registro

	end try
	begin catch
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()
		rollback transaction registro
	end catch

end
go

/*
create proc sp_ReporteVentas
(
@fechainicio varchar(10),
@fechafin varchar(10)
)
as
begin
set dateformat dmy;
select
CONVERT(char(10),v.FechaRegistro,103)[FechaRegistro],v.TipoDocumento,v.NumeroDocumento,v.MontoTotal,
u.NombreCompleto[UsuarioRegistro],
v.DocumentoCliente,v.NombreCliente,
p.Codigo[CodigoProducto],p.Nombre[NombreProducto],ca.Descripcion[Categoria],dv.PrecioVenta,dv.Cantidad,dv.SubTotal
from VENTA v
inner join USUARIO u on u.IdUsuario = v.IdUsuario
inner join DETALLE_VENTA dv on dv.IdVenta = v.IdVenta
inner join PRODUCTO p on p.IdProducto = dv.IdProducto
inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
where CONVERT(date,v.FechaRegistro) between @fechainicio and @fechafin
end
go
*/
drop procedure sp_ReporteVentas
create proc sp_ReporteVentas
(
@fechainicio varchar(10),
@fechafin varchar(10)
)
as
begin
set dateformat dmy;
select
CONVERT(char(10),v.FechaRegistro,103)[FechaRegistro],v.TipoDocumento,v.NumeroDocumento,v.MontoTotal,
u.NombreCompleto[UsuarioRegistro],
v.DocumentoCliente,v.NombreCliente,
p.Codigo[CodigoProducto],p.Nombre[NombreProducto],dv.PrecioVenta,dv.Cantidad,dv.SubTotal
from VENTA v
inner join USUARIO u on u.IdUsuario = v.IdUsuario
inner join DETALLE_VENTA dv on dv.IdVenta = v.IdVenta
inner join PRODUCTO p on p.IdProducto = dv.IdProducto
where CONVERT(date,v.FechaRegistro) between @fechainicio and @fechafin
end
go




  /*PROCESOS PARA REGISTRAR UNA VENTA*/
CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE
(
[IdProducto] int NULL,
[PrecioVenta] decimal(18,2) NULL,
[Cantidad] int NULL,
[SubTotal] decimal(18,2)
)
go