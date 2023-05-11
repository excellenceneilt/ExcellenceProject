--Creación tablas

create table Equipo(
	IdEquipo int primary key identity,
	CodigoEquipo varchar(50),
	Marca varchar(50),
	Modelo varchar(50),
	SerialNumber varchar(50),
	IdEstadoEquipo  int default 1 foreign key references EstadoEquipo(IdEstadoEquipo),
	Estado bit,
	FechaRegistro date default getdate(),
	IdProducto int references Producto(IdProducto),
	IdCliente int references Cliente(IdCliente),
	IdCompra int references Compra(IdCompra)
);
go

--Procedimientos almacenados

--Registrar equipos

drop proc SP_RegistrarEquipos
/*
create proc SP_RegistrarEquipos(

@CodigoEquipo int,
@Modelo varchar (50),
@SerialNumber varchar (50),
@IdProducto int,
@IdCategoria int,
@IdEstadoEquipo int,
@Estado bit, 

  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 0 declare @IdEquipo int if not exists (
    select 
      * 
    from 
      Equipo 
    where 
      CodigoEquipo = @CodigoEquipo
  ) begin insert into Equipo(
    CodigoEquipo, Modelo, SerialNumber, IdProducto, IdCategoria, IdEstadoEquipo, Estado
  ) 
values 
  (
   @CodigoEquipo, @Modelo, @SerialNumber, @IdProducto,@IdCategoria, @IdEstadoEquipo, @Estado
  ) 
set 
  @Resultado = SCOPE_IDENTITY() end else 
set 
  @Mensaje = 'El número de CodEquipo ya existe' end 
*/
drop proc SP_RegistrarEquipos
create proc SP_RegistrarEquipos(

@CodigoEquipo varchar(50),
@Marca varchar(50),
@Modelo varchar (50),
@SerialNumber varchar (50),
@IdProducto	int,
@Estado bit, 

  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 0 declare @IdEquipo int if not exists (
    select 
      * 
    from 
      Equipo 
    where 
      SerialNumber = @SerialNumber
  ) begin insert into Equipo(
    CodigoEquipo, Marca,Modelo, SerialNumber,  Estado, IdProducto
  ) 
values 
  (
   @CodigoEquipo,@Marca, @Modelo, @SerialNumber, @Estado, @IdProducto
  ) 
set 
  @Resultado = SCOPE_IDENTITY() end else 
set 
  @Mensaje = 'El número serial ya existe' end 
go

--Modificar equipo

drop proc SP_ModificarEquipo
/*
create proc SP_ModificarEquipo(
  @IdEquipo int, 
@CodigoEquipo varchar(50),
@Modelo varchar (50),
@SerialNumber varchar (50),
@IdProducto int,
@IdCategoria int,
@IdEstadoEquipo int,

	@Estado bit, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 1 declare @IDequipp INT if not exists(
    select 
      * 
    from 
      Equipo 
    WHERE 
     CodigoEquipo = @CodigoEquipo
      and IdEquipo != @IdEquipo
  ) begin 
update 
  Equipo 
set 
 CodigoEquipo = @CodigoEquipo,
Modelo = @Modelo,
SerialNumber = @SerialNumber,
IdProducto = @IdProducto,
IdCategoria = @IdCategoria,
IdEstadoEquipo = @IdEstadoEquipo,
  Estado = @Estado 
where 
  IdEquipo = @IdEquipo end else begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'El número de equipo ya existe' end end
*/
create proc SP_ModificarEquipo(
@IdEquipo int, 
@CodigoEquipo varchar(50),
@Modelo varchar (50),
@SerialNumber varchar (50),
@IdProducto int,
@IdEstadoEquipo int,
@Estado bit, 
@Resultado int output, 
@Mensaje varchar(500) output
)
	as begin 
set 
  @Resultado = 1 declare @IDequipp INT if not exists(
    select 
      * 
    from 
      Equipo 
    WHERE 
     CodigoEquipo = @CodigoEquipo
      and IdEquipo != @IdEquipo
  ) begin 
update 
  Equipo 
set 
 CodigoEquipo = @CodigoEquipo,
Modelo = @Modelo,
SerialNumber = @SerialNumber,
IdProducto = @IdProducto,
IdEstadoEquipo = @IdEstadoEquipo,
  Estado = @Estado 
where 
  IdEquipo = @IdEquipo end else begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'El número de equipo ya existe' end end
go
  --Eliminar equipo

  create proc SP_EliminarEquipo(
  @IdEquipo int, 
  @Respuesta bit output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Respuesta = 0 
set 
  @Mensaje = '' declare @pasoreglas bit = 1 if exists (
    select 
      * 
    from 
      DETALLE_COMPRA dc 
      inner join EQUIPO e on p.IdEquipo = dc.IdProducto 
    where 
      p.IdProducto = @IdProducto
  ) begin 
set 
  @pasoreglas = 0 
set 
  @Respuesta = 0 
set 
  @Mensaje = @Mensaje + 'No se puede eliminar porque se encuentra relacionado a una compra' end if exists (
    select 
      * 
    from 
      DETALLE_VENTA dv 
      inner join PRODUCTO p on p.IdProducto = dv.IdProducto 
    where 
      p.IdProducto = @IdProducto
  ) begin 
set 
  @pasoreglas = 0 
set 
  @Respuesta = 0 
set 
  @Mensaje = @Mensaje + 'No se puede eliminar porque se encuentra relacionado a una venta' end if(@pasoreglas = 1) begin 
delete from 
  PRODUCTO 
where 
  IdProducto = @IdProducto 
set 
  @Respuesta = 1 end end