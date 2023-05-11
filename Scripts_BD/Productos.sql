/*
create table PRODUCTO(
IdProducto int primary key identity,
Codigo varchar(50),
Nombre varchar(50),
Descripcion varchar(50),
IdMarca int references Marca(IdMarca),
IdCategoria int references Categoria(IdCategoria),
Stock int not null default 0,
PrecioCompra decimal(10,2) default 0,
PrecioVenta decimal(10,2) default 0,
Estado bit,
FechaRegistro datetime default getdate()
);
*/
drop table producto
exec sp_fkeys 'producto'
create table PRODUCTO(
IdProducto int primary key identity,
Codigo varchar(50),
Nombre varchar(50),
Descripcion varchar(50),
IdMarca int references Marca(IdMarca),
Stock int not null default 0,
PrecioCompra decimal(10,2) default 0,
PrecioVenta decimal(10,2) default 0,
Estado bit,
FechaRegistro datetime default getdate()
);
drop table PRODUCTO
--Procedimientos almacenados

--Registrar producto
drop proc SP_RegistrarProducto
/*
create proc SP_RegistrarProducto(
  @Codigo varchar(50), 
  @Nombre varchar(50), 
  @Descripcion varchar(50), 
  @IdCategoria int, 
  @IdMarca int,
  @Estado bit, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 0 if not exists (
    select 
      * 
    from 
      PRODUCTO 
    where 
      Codigo = @Codigo
  ) begin insert into producto(
    Codigo, Nombre, Descripcion, IdCategoria,IdMarca ,
    Estado
  ) 
VALUES 
  (
    @Codigo, @Nombre, @Descripcion, @IdCategoria, @IdMarca,
    @Estado
  ) 
SET 
  @Resultado = SCOPE_IDENTITY() end else 
set 
  @Mensaje = 'Ya existe un producto con el mismo código' end
  
  go
*/
create proc SP_RegistrarProducto(
  @Codigo varchar(50), 
  @Nombre varchar(50), 
  @Descripcion varchar(50),
  @IdMarca int,
  @Estado bit, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 0 if not exists (
    select 
      * 
    from 
      PRODUCTO 
    where 
      Codigo = @Codigo
  ) begin insert into producto(
    Codigo, Nombre, Descripcion,IdMarca ,
    Estado
  ) 
VALUES 
  (
    @Codigo, @Nombre, @Descripcion, @IdMarca,
    @Estado
  ) 
SET 
  @Resultado = SCOPE_IDENTITY() end else 
set 
  @Mensaje = 'Ya existe un producto con el mismo código' end
  
  go


--Editar producto
drop proc SP_ModificarProducto
/*
create proc SP_ModificarProducto(
  @IdProducto int, 
  @Codigo varchar(50), 
  @Nombre varchar(50), 
  @Descripcion varchar(50), 
  @IdMarca int,
  @IdCategoria int, 
  @Estado bit, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 1 if not exists (
    select 
      * 
    from 
      PRODUCTO 
    where 
      Codigo = @Codigo 
      and IdProducto != @IdProducto
  ) 
update 
  PRODUCTO 
set 
  Codigo = @Codigo, 
  Nombre = @Nombre, 
  Descripcion = @Descripcion, 
  IdMarca = @IdMarca,
  IdCategoria = @IdCategoria, 
  Estado = @Estado 
where 
  IdProducto = @IdProducto else begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'No se puede repetir la descripción de un producto' end end
*/drop proc SP_ModificarProducto
create proc SP_ModificarProducto(
  @IdProducto int, 
  @Codigo varchar(50), 
  @Nombre varchar(50), 
  @Descripcion varchar(50), 
  @IdMarca int,
  @Estado bit, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 1 if not exists (
    select 
      * 
    from 
      PRODUCTO 
    where 
      Codigo = @Codigo 
      and IdProducto != @IdProducto
  ) 
update 
  PRODUCTO 
set 
  Codigo = @Codigo, 
  Nombre = @Nombre, 
  Descripcion = @Descripcion, 
  IdMarca = @IdMarca,
  Estado = @Estado 
where 
  IdProducto = @IdProducto else begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'No se puede repetir la descripción de un producto' end end
go 

--Eliminar producto

create proc SP_EliminarProducto(
  @IdProducto int, 
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
      inner join PRODUCTO p on p.IdProducto = dc.IdProducto 
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