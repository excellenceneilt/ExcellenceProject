create table ESPECIALIDAD(
	IdEspecialidad int primary key identity not null,
	Descripcion varchar(50),
	Estado bit,
	FechaRegistro datetime default getdate()
	);

	select * from ESPECIALIDAD
	
	insert into ESPECIALIDAD(Descripcion,Estado) values 
	('Dermatolog�a', 1),('Cirug�a est�tica',1)


	create PROC SP_RegistrarEspecialidad(
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
      ESPECIALIDAD 
    WHERE 
      Descripcion = @Descripcion
  ) BEGIN insert into ESPECIALIDAD(Descripcion, Estado) 
values 
  (@Descripcion, @Estado) 
set 
  @Resultado = SCOPE_IDENTITY() end ELSE 
set 
  @Mensaje = 'No se puede repetir la descripci�n de una especialidad' end go

--Editar categor�a
create PROC SP_EditarEspecialidad(
  @IdEspecialidad int, 
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
      ESPECIALIDAD 
    WHERE 
      Descripcion = @Descripcion 
      and IdEspecialidad != @IdEspecialidad
  ) 
update 
  ESPECIALIDAD 
set 
  Descripcion = @Descripcion, 
  Estado = @Estado 
where 
  IdEspecialidad = @IdEspecialidad ELSE begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'No se puede repetir la descripci�n de una especialidad' end end go

  select * from PRODUCTO
--Eliminar especialidad

CREATE PROC SP_EliminarEspecialidad(
  @IdEspecialidad int, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 1 if not exists (
    --Validando si existe un v�nculo entre categor�a y un producto (si hay un producto registrado con cierta categor�a)
    SELECT 
      * 
    FROM 
      ESPECIALIDAD e 
      inner join CLIENTE c on c.IdEspecialidad = e.IdEspecialidad 
    where 
      e.IdEspecialidad = @IdEspecialidad
  ) begin delete top(1) 
from 
  ESPECIALIDAD 
where 
  IdEspecialidad = @IdEspecialidad --top(1) para eliminar s�lo un registro
  end ELSE begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'La especialidad se encuentra relacionada a un cliente' end end go