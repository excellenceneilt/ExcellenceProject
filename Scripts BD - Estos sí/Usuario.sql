create table USUARIO(
IdUsuario int primary key identity,
Documento varchar(50),
NombreCompleto varchar(50),
Correo varchar(50),
Clave varchar(50),
IdRol int references ROL(IdRol),
Estado bit,
FechaCreacion datetime default getdate()
)


--Registrar usuario

CREATE PROC SP_REGISTRARUSUARIO(
  @Documento varchar(50), 
  @NombreCompleto varchar(50), 
  @Correo varchar(50), 
  @Clave varchar(50), 
  @IdRol int, 
  @Estado bit, 
  @IdUsuarioResultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @IdUsuarioResultado = 0 
set 
  @Mensaje = '' if not exists(
    select 
      * 
    from 
      USUARIO 
    where 
      Documento = @Documento
  ) begin insert into usuario(
    Documento, NombreCompleto, Correo, 
    Clave, IdRol, Estado
  ) 
values 
  (
    @Documento, @NombreCompleto, @Correo, 
    @Clave, @IdRol, @Estado
  ) 
set 
  @IdUsuarioResultado = SCOPE_IDENTITY() end else 
set 
  @Mensaje = 'No se puede repetir el documento para más de un usuario' end
  GO



-- Editar usuario

CREATE PROC SP_EDITARUSUARIO(
  @IdUsuario int, 
  @Documento varchar(50), 
  @NombreCompleto varchar(50), 
  @Correo varchar(50), 
  @Clave varchar(50), 
  @IdRol int, 
  @Estado bit, 
  @Respuesta bit output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Respuesta = 0 
set 
  @Mensaje = '' if not exists(
    select 
      * 
    from 
      USUARIO 
    where 
      Documento = @Documento 
      and IdUsuario != @IdUsuario
  ) begin 
update 
  usuario 
set 
  Documento = @Documento, 
  NombreCompleto = @NombreCompleto, 
  Correo = @Correo, 
  Clave = @Clave, 
  IdRol = @IdRol, 
  Estado = @Estado 
where 
  IdUsuario = @IdUsuario 
set 
  @Respuesta = 1 end else 
set 
  @Mensaje = 'No se puede repetir el documento para más de un usuario' end


--Eliminar usuario

CREATE PROC SP_ELIMINARUSUARIO(
  @IdUsuario int, 
  @Respuesta bit output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Respuesta = 0 
set 
  @Mensaje = '' declare @pasoreglas bit = 1 --1 si pasó
  --Validacion por si el usuario está atado a una compra o a una venta
  if exists (
    SELECT 
      * 
    from 
      COMPRA c 
      inner join USUARIO U on U.IdUsuario = C.IdUsuario 
    where 
      u.IdUsuario = @IdUsuario
  ) begin 
set 
  @pasoreglas = 0 
set 
  @Respuesta = 0 
set 
  @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una COMPRA\n' end if exists (
    SELECT 
      * 
    from 
      VENTA v 
      inner join USUARIO U on U.IdUsuario = v.IdUsuario 
    where 
      u.IdUsuario = @IdUsuario
  ) begin 
set 
  @pasoreglas = 0 
set 
  @Respuesta = 0 
set 
  @Mensaje = @Mensaje + 'No se puede eliminar porque el usuario se encuentra relacionado a una VENTA\n' end if (@pasoreglas = 1) begin 
delete from 
  USUARIO 
where 
  IdUsuario = @IdUsuario 
set 
  @Respuesta = 1 end end