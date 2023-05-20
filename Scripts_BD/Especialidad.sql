create table ESPECIALIDAD(
	IdEspecialidad int primary key identity not null,
	Descripcion varchar(50),
	Estado bit,
	FechaRegistro datetime default getdate()
	);

	select * from ESPECIALIDAD
	
	insert into ESPECIALIDAD(Descripcion,Estado) values 
	('Dermatología', 1),('Cirugía estética',1)


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
  @Mensaje = 'No se puede repetir la descripción de una especialidad' end go

--Editar categoría
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
  @Mensaje = 'No se puede repetir la descripción de una especialidad' end end go

  select * from PRODUCTO
--Eliminar especialidad

CREATE PROC SP_EliminarEspecialidad(
  @IdEspecialidad int, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 1 if not exists (
    --Validando si existe un vínculo entre categoría y un producto (si hay un producto registrado con cierta categoría)
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
  IdEspecialidad = @IdEspecialidad --top(1) para eliminar sólo un registro
  end ELSE begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'La especialidad se encuentra relacionada a un cliente' end end go