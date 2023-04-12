/*
create table Marca(
IdMarca int primary key identity,
Descripcion varchar(50),
IdCategoria int references Categoria(IdCategoria),
Estado bit,
FechaRegistro datetime default getdate()
)
*/
create table Marca(
IdMarca int primary key identity,
Descripcion varchar(50),
Estado bit,
FechaRegistro datetime default getdate()
)
drop table Marca
select * from Marca
EXEC sp_fkeys 'Marca'

/*
create PROC SP_RegistrarMarca(
  @Descripcion varchar(50),
  @IdCategoria int, 
  @Estado bit, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 0 if not exists (
    SELECT 
      * 
    FROM 
      Marca
    WHERE 
      Descripcion = @Descripcion
  ) BEGIN insert into Marca(Descripcion,IdCategoria, Estado) 
values 
  (@Descripcion,@IdCategoria, @Estado) 
set 
  @Resultado = SCOPE_IDENTITY() end ELSE 
set 
  @Mensaje = 'No se puede repetir la descripción de una categoría' end
  go
*/drop PROC SP_RegistrarMarca
create PROC SP_RegistrarMarca(
  @Descripcion varchar(50),
  @Estado bit, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 0 if not exists (
    SELECT 
      * 
    FROM 
      Marca
    WHERE 
      Descripcion = @Descripcion
  ) BEGIN insert into Marca(Descripcion, Estado) 
values 
  (@Descripcion, @Estado) 
set 
  @Resultado = SCOPE_IDENTITY() end ELSE 
set 
  @Mensaje = 'No se puede repetir la descripción de una categoría' end
  go



--NO DEBERIA EJECUTAR ESE QUERY PORQUE NO EXISTE LA TABLA CATEGORIA
select IdProducto, Codigo, Nombre, p.Descripcion, c.IdCategoria,C.Descripcion[DescripcionCategoria],m.IdMarca, m.Descripcion[DescripcionMarca], Stock, PrecioCompra, PrecioVenta, p.Estado from PRODUCTO p
inner join CATEGORIA c on c.IdCategoria = p.IdCategoria
inner join MARCA m on m.IdMarca = p.IdMarca