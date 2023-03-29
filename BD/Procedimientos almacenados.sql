-------------------------------------PROCEDIMIENTOS ALMACENADOS----------------------------------------------

--..........................................Mantenimiento de  usuario..............................................--

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


--Test
	declare @idusuariogenerado int
	declare @mensaje varchar(500)
	exec SP_REGISTRARUSUARIO  'admin4','admin4_name','admin4@gmail.com','admin',2,1, @idusuariogenerado output, @mensaje output --user test

	select @idusuariogenerado
	select @mensaje


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



--.................................................Mantenimiento de  categoria...........................................--

--Guardar categoría
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
  @Mensaje = 'No se puede repetir la descripción de una categoría' end go



--Editar categoría
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
  @Mensaje = 'No se puede repetir la descripción de una categoría' end end go


--Eliminar categoria

CREATE PROC SP_EliminarCategoria(
  @IdCategoria int, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 1 if not exists (
    --Validando si existe un vínculo entre categoría y un producto (si hay un producto registrado con cierta categoría)
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
  IdCategoria = @IdCategoria --top(1) para eliminar sólo un registro
  end ELSE begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'La categoría se encuentra relacionada a un producto' end end go


--...........................................Mantenimiento de  productos.................................................--

--Registrar producto

create proc SP_RegistrarProducto(
  @Codigo varchar(50), 
  @Nombre varchar(50), 
  @Descripcion varchar(50), 
  @IdCategoria int, 
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
    Codigo, Nombre, Descripcion, IdCategoria, 
    Estado
  ) 
VALUES 
  (
    @Codigo, @Nombre, @Descripcion, @IdCategoria, 
    @Estado
  ) 
SET 
  @Resultado = SCOPE_IDENTITY() end else 
set 
  @Mensaje = 'Ya existe un producto con el mismo código' end go


--Editar producto

create proc SP_ModificarProducto(
  @IdProducto int, 
  @Codigo varchar(50), 
  @Nombre varchar(50), 
  @Descripcion varchar(50), 
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
  IdCategoria = @IdCategoria, 
  Estado = @Estado 
where 
  IdProducto = @IdProducto else begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'No se puede repetir la descripción de un producto' end end

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


--...............................................Mantenimiento de especialidades........................................--

--Guardar especialidad
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




--..........................................Mantenimiento de cliente..................................................--

--Registrar cliente

drop proc SP_RegistrarCliente
create proc SP_RegistrarCliente(
	@Documento varchar(50), 
	@DocumentoContacto varchar(50),
	 @NombreCompleto varchar(50),
	 @NombreComercial varchar(50),
	 @NombreContacto varchar(50),
	 @Direccion nvarchar(50),
	 @DireccionComercial nvarchar(50),--New
	 @DireccionContacto nvarchar(50),
	 @IdTipoCliente int, --New
	 @IdTipoDocumento int, --New
	@Departamento nvarchar(50),
	@Provincia nvarchar(50),
	@Distrito nvarchar(50),
	@DepartamentoComercial nvarchar(50),
	@ProvinciaComercial nvarchar(50),
	@DistritoComercial nvarchar(50),--New new 
	@DepartamentoContacto nvarchar(50),--New
	@ProvinciaContacto nvarchar(50),--New
	@DistritoContacto nvarchar(50),--New
	@Correo1 varchar(50),
	@Correo2 varchar(50),
	@CorreoContacto varchar(50),
	@Telefono1 varchar(50),
	@Telefono2 varchar(50),
	@TelefonofijoContacto varchar(50),
	@CelularContacto varchar(50), --New
	@CMP varchar(7),
	@RazonSocial varchar(100), 
  @RUC varchar(20),
  @RUCContacto varchar(20),
  
  @Estado bit, 

  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 0 declare @IdPersona int if not exists (
    select 
      * 
    from 
      CLIENTE 
    where 
      Documento = @Documento
  ) begin insert into CLIENTE(
    Documento,DocumentoContacto, NombreCompleto,NombreComercial,NombreContacto, Direccion,DireccionComercial,DireccionContacto,IdTipoCliente,IdTipoDocumento,Departamento, Provincia, Distrito,DepartamentoComercial, ProvinciaComercial, DistritoComercial,DepartamentoContacto, ProvinciaContacto, DistritoContacto, Correo1,Correo2,CorreoContacto, Telefono1,Telefono2,TelefonofijoContacto,CelularContacto, CMP,RazonSocial, RUC,RUCContacto, Estado
  ) 
values 
  (
    @Documento,@DocumentoContacto, @NombreCompleto,@NombreComercial,@NombreContacto, @Direccion,@DireccionComercial,@DireccionContacto,@IdTipoCliente,@IdTipoDocumento, @Departamento, @Provincia, @Distrito,@DepartamentoComercial, @ProvinciaComercial, @DistritoComercial,@DepartamentoContacto, @ProvinciaContacto, @DistritoContacto, @Correo1,@Correo2,@CorreoContacto,@Telefono1,@Telefono2,@TelefonofijoContacto,@CelularContacto, @CMP,@RazonSocial, @RUC,@RUCContacto, @Estado
  ) 
set 
  @Resultado = SCOPE_IDENTITY() end else 
set 
  @Mensaje = 'El número de documento ya existe' end 

  select * from CLIENTE

--Modificar cliente

create proc SP_ModificarCliente(
  @IdCliente int, 
@Documento varchar(50), 
	@DocumentoContacto varchar(50),
	 @NombreCompleto varchar(50),
	 @NombreComercial varchar(50),
	 @NombreContacto varchar(50),
	 @Direccion nvarchar(50),
	 @DireccionComercial nvarchar(50),--New
	 @DireccionContacto nvarchar(50),
	 @IdTipoCliente int, --New
	 @IdTipoDocumento int, --New
	@Departamento nvarchar(50),
	@Provincia nvarchar(50),
	@Distrito nvarchar(50),
	@DepartamentoComercial nvarchar(50),
	@ProvinciaComercial nvarchar(50),
	@DistritoComercial nvarchar(50),--New new 
	@DepartamentoContacto nvarchar(50),--New
	@ProvinciaContacto nvarchar(50),--New
	@DistritoContacto nvarchar(50),--New
	@Correo1 varchar(50),
	@Correo2 varchar(50),
	@CorreoContacto varchar(50),
	@Telefono1 varchar(50),
	@Telefono2 varchar(50),
	@TelefonofijoContacto varchar(50),
	@CelularContacto varchar(50), --New
	@CMP varchar(7),
	@RazonSocial varchar(100), 
  @RUC varchar(20),
  @RUCContacto varchar(20),
  
  @Estado bit, 
  @Resultado int output, 
  @Mensaje varchar(500) output
) as begin 
set 
  @Resultado = 1 declare @IDPERSONA INT if not exists(
    select 
      * 
    from 
      CLIENTE 
    WHERE 
      Documento = @Documento 
      and IdCliente != @IdCliente
  ) begin 
update 
  CLIENTE 
set 
  Documento = @Documento, 
  NombreCompleto = @NombreCompleto, 
  NombreComercial = @NombreComercial,
  Direccion = @Direccion,
  DireccionComercial = @DireccionComercial,
  IdTipoCliente = @IdTipoCliente,
  IdTipoDocumento = @IdTipoDocumento,
  Departamento = @Departamento,
  Provincia = @Provincia,
  Distrito = @Distrito,
  DepartamentoComercial = @DepartamentoComercial,
  ProvinciaComercial = @ProvinciaComercial,
  DistritoComercial = @DistritoComercial,
  Correo1 = @Correo1, 
  Correo2 = @Correo2, 
  Telefono1 = @Telefono1, 
  Telefono2 = @Telefono2, 
  CMP = @CMP, 
  RazonSocial = @RazonSocial, 
  RUC = @RUC, 
  IdEspecialidad = @IdEspecialidad,
  Estado = @Estado 
where 
  IdCliente = @IdCliente end else begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'El número de documento ya existe' end end

 

  --...............................................STORED PRECEDURES........................................--


  CREATE PROC SP_ObtenerDepartamento
  as
  begin
  select IdDepartamento, Descripcion from Departamento where Estado = 1
  end
  go

  create proc SP_ObtenerProvincia(@IdDepartamento int)
  as
  begin
  select IdProvincia, Descripcion from Provincia where Estado = 1 and IdDepartamento = @IdDepartamento
  end
  go

  create proc SP_ObtenerDistrito(@IdProvincia int)
  as
  begin
  select IdDistrito, Descripcion from Distrito where Estado = 1 and IdProvincia = @IdProvincia
  end
  go


  exec SP_ObtenerDepartamento

  exec SP_ObtenerProvincia 1

  exec SP_ObtenerDistrito 1


  delete from CLIENTE
















---------------------------------------------TEST------------------------------------------------------------

select p.IdRol,p.NombreMenu from PERMISO p
inner join ROL r ON r.IdRol = p.IdRol
inner join USUARIO u on u.IdRol = r.IdRol
where u.IdUsuario = 1

select u.IdUsuario, u.Documento, u.NombreCompleto, u.Correo, u.Clave, u.Estado, r.IdRol, r.Descripcion from usuario u
inner join Rol r on r.IdRol = u.IdRol
	
select * from PRODUCTO
	select IdProducto, Codigo, Nombre, p.Descripcion, c.IdCategoria,C.Descripcion[DescripcionCategoria], Stock, PrecioCompra, PrecioVenta, p.Estado from PRODUCTO p
	inner join CATEGORIA c on c.IdCategoria = p.IdCategoria

	select IdCliente, Documento, NombreCompleto, Correo1,Correo2,Telefono1,Telefono2, CMP,RazonSocial, RUC,e.IdEspecialidad, e.Descripcion[Especialidad], c.Estado from CLIENTE c
	inner join ESPECIALIDAD e on e.IdEspecialidad = c.IdEspecialidad

	select IdProducto, Codigo, Nombre, p.Descripcion, c.IdCategoria,C.Descripcion[DescripcionCategoria], Stock, PrecioCompra, PrecioVenta, p.Estado from PRODUCTO p
    inner join CATEGORIA c on c.IdCategoria = p.IdCategoria

	select IdTipoCliente, Descripcion, Estado from TIPOCLIENTE

	select * from cliente

select IdCliente,  td.IdTipoDocumento, td.Descripcion, Documento, RUC, RazonSocial, tc.IdTipoCliente, tc.Descripcion, NombreCompleto, Direccion,CMP,e.IdEspecialidad, e.Descripcion[Especialidad],NombreComercial, DireccionComercial, Correo1,Telefono1,Correo2,Telefono2,  c.Estado from CLIENTE c
inner join ESPECIALIDAD e on e.IdEspecialidad = c.IdEspecialidad
inner join TIPODOCUMENTO td on td.IdTipoDocumento = c.IdTipoDocumento
inner join TIPOCLIENTE tc on tc.IdTipoCliente = c.IdTipoCliente

delete from CLIENTE where IdCliente=4

select * from ESPECIALIDAD

select * from Departamento

select IdDepartamento, Descripcion, Estado from Departamento