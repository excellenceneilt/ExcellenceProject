create table Categoria(	
	IdCategoria int primary key identity,
	Descripcion varchar(100),
	Estado bit,
	FechaRegistro datetime default getdate()
	);
	drop table categoria
--Procedimientos almacenados
select * from categoria
--Registrar categor�a
create PROC SP_RegistrarCategoria(
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
      CATEGORIA 
    WHERE 
      Descripcion = @Descripcion
  ) BEGIN insert into CATEGORIA(Descripcion, Estado) 
values 
  (@Descripcion, @Estado) 
set 
  @Resultado = SCOPE_IDENTITY() end ELSE 
set 
  @Mensaje = 'No se puede repetir la descripci�n de una categor�a' end go


  select * from PRODUCTO
--Editar categor�a
create PROC SP_EditarCategoria(
  @IdCategoria int, 
  @Estado bit, 
  @Descripcion varchar(50), 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 1 if not exists (
    SELECT 
      * 
    FROM 
      CATEGORIA 
    WHERE 
      Descripcion = @Descripcion 
      and IdCategoria != @IdCategoria
  ) 
update 
  CATEGORIA 
set 
  Descripcion = @Descripcion, 
  Estado = @Estado 
where 
  IdCategoria = @IdCategoria ELSE begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'No se puede repetir la descripci�n de una categor�a' end end go


--Eliminar categoria

CREATE PROC SP_EliminarCategoria(
  @IdCategoria int, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 1 if not exists (
    --Validando si existe un v�nculo entre categor�a y un producto (si hay un producto registrado con cierta categor�a)
    SELECT 
      * 
    FROM 
      CATEGORIA c 
      inner join PRODUCTO p on p.IdCategoria = c.IdCategoria 
    where 
      c.IdCategoria = @IdCategoria
  ) begin delete top(1) 
from 
  CATEGORIA 
where 
  IdCategoria = @IdCategoria --top(1) para eliminar s�lo un registro
  end ELSE begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'La categor�a se encuentra relacionada a un producto' end end go