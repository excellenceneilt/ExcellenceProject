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
select * from PRODUCTO
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

create proc SP_EditarMarca(
@IdMarca int,
@Estado bit,
@Descripcion varchar(50),
@Resultado int output,
@Mensaje varchar(500) output
) as begin
set 
	@Resultado = 1 if not exists(
		select * from Marca where Descripcion = @Descripcion and IdMarca = @IdMarca)
	update
		marca
	set
		Descripcion = @Descripcion,
		Estado = @Estado
	where
		IdMarca = @IdMarca else begin 
	set
		@Resultado = 0
	set 
		@Mensaje = 'El nombre que estás colocando es el mismo, coloca otro' end end 
		go

		select * from marca 