create table CLIENTE(
	IdCliente int primary key identity not null,
	CodigoCliente  AS('CL' + RIGHT('000000000'+ CONVERT(VARCHAR, IdCliente),(7))),  --New
	Documento varchar(50) , --dni
	DocumentoContacto varchar(50), --new
	NombreCompleto nvarchar(50),
	NombreComercial nvarchar(50), --New
	NombreContacto nvarchar(50), --New
	Direccion nvarchar(50), --New
	DireccionComercial nvarchar(50),--New
	DireccionContacto nvarchar(50), --New
	Correo1 varchar(50),
	Correo2 varchar(50),
	CorreoContacto varchar(50),
	Telefono1 varchar(50),
	Telefono2 varchar(50),
	TelefonofijoContacto varchar(50),
	CelularContacto varchar(50), --New
	CMP varchar(7) ,
	RazonSocial varchar(100),
	RUC varchar(20) ,
	RUCContacto varchar(20),
	Departamento nvarchar(50),--New
	Provincia nvarchar(50),--New
	Distrito nvarchar(50),--New
	DepartamentoComercial nvarchar(50),--New
	ProvinciaComercial nvarchar(50),--New
	DistritoComercial nvarchar(50),--New
	DepartamentoContacto nvarchar(50),--New
	ProvinciaContacto nvarchar(50),--New
	DistritoContacto nvarchar(50),--New
	Estado bit,
	FechaRegistro datetime default getdate(),
	IdTipoCliente int references TIPOCLIENTE(IdTipoCliente), --New
	IdTipoDocumento int references TIPODOCUMENTO(IdTipoDocumento),
	
	);


--Procedimientos almacenados---------------------------------
--Registrar cliente

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
  @Resultado = 1 declare @IDCLIENTE INT if not exists(
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
  DocumentoContacto = @DocumentoContacto,
  NombreCompleto = @NombreCompleto, 
  NombreComercial = @NombreComercial,
  NombreContacto = @NombreContacto,
  Direccion = @Direccion,
  DireccionComercial = @DireccionComercial,
  DireccionContacto = @DireccionContacto,
  IdTipoCliente = @IdTipoCliente,
  IdTipoDocumento = @IdTipoDocumento,
  Departamento = @Departamento,
  Provincia = @Provincia,
  Distrito = @Distrito,
  DepartamentoComercial = @DepartamentoComercial,
  ProvinciaComercial = @ProvinciaComercial,
  DistritoComercial = @DistritoComercial,
  DepartamentoContacto = @DepartamentoContacto,
  ProvinciaContacto = @ProvinciaContacto,
  DistritoContacto = @DistritoContacto,
  Correo1 = @Correo1, 
  Correo2 = @Correo2,
  CorreoContacto = @CorreoContacto, 
  Telefono1 = @Telefono1, 
  Telefono2 = @Telefono2, 
  TelefonofijoContacto = @TelefonofijoContacto,
  CelularContacto = @CelularContacto,
  CMP = @CMP, 
  RazonSocial = @RazonSocial, 
  RUC = @RUC, 
  Estado = @Estado 
where 
  IdCliente = @IdCliente end else begin 
set 
  @Resultado = 0 
set 
  @Mensaje = 'El número de documento ya existe' end end