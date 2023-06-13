--............Tipo cliente ....................--
	create table TIPOCLIENTE(
	IdTipoCliente int not null identity primary key,
	Descripcion nvarchar(50),
	Estado bit,
	FechaRegistro datetime default getdate()
	);

	insert into TIPOCLIENTE(Descripcion, Estado, FechaRegistro)
	values
	('Persona natural',1, GETDATE()), ('Persona jurídica',1,GETDATE())

--............Rol....................--
	create table ROL(
	IdRol int primary key identity,
	Descripcion varchar(50),
	FechaCreacion datetime default getdate()
	)

	insert into ROL(Descripcion)
values 
('Administrador'),('Marketing'),('Contabilidad'),('Servicio técnico')

--............Tipo Comprobante....................--
create table TIPO_COMPROBANTE
(
IdTipoComprobante	int primary key identity,
TipoComprobante		nvarchar(20)
)
--............Permiso....................--
create table PERMISO(
IdPermiso int primary key identity,
IdRol int references ROL(IdRol),
NombreMenu varchar(100),
FechaCreacion datetime default getdate()
)

insert into PERMISO(IdRol, NombreMenu)
values 
(2,'menuClientes'),
(2,'menuProveedores'),
(2,'menuReportes'),
(2,'menuAcercade'),
(3,'menuVentas'),
(3,'menuCompras'),
(3,'menuClientes'),
(3,'menuProveedores'),
(3,'menuReportes'),
(3,'menuAcercade')

--............Monedas....................--
	create table monedas(
	IdMoneda int primary key identity,
	Descripcion varchar(100),
	Estado bit,
	FechaRegistro datetime default getdate()
	);

--............SI / NO....................--

	create table OpcionSino(
	IdOpcion int primary key identity,
	Descripcion varchar(100),
	Estado bit,
	FechaRegistro datetime default getdate()
	);

	--............TIPO DE CAMBIO....................--

	create table Tipodecambio(
	IdTC int primary key identity,
	FechaRegistro datetime default getdate(),
	Compra decimal(18,3),
	Venta decimal(18,3)
	);


	--............Tipo documento....................--
	create table TIPODOCUMENTO(
	IdTipoDocumento int not null identity primary key,
	CodigoTipo int,
	Descripcion nvarchar(50),
	Estado bit not null default 1,
	FechaRegistro datetime default getdate()
	);

	insert into TIPODOCUMENTO (CodigoTipo, Descripcion)
	values
	(1,'DNI'), (4,'Carnet extranjería'), (6,'Reg. Único de contribuyentes'), (7,'Pasaporte')

	-----------------NEGOCIO-------------------------
	create table NEGOCIO
	(
	IdNegocio int primary key,
	Nombre varchar(60),
	RUC varchar(60),
	Direccion varchar(60),
	Logo varbinary(max) NULL,
	NombreComercial nvarchar(150),
	RazonSocial nvarchar(150),
	NumeroRegistro nvarchar(50)
	);
	go

	insert into NEGOCIO (IdNegocio,Nombre,RUC,Direccion) values (1,'GRUPO DE INVERSIONES Y DROGUERIAS MONSALVE SAC','20602438881','AV. JUAN DE ALIAGA NRO. 455 INT. 701A URB. SAN FELIPE LIMA')


	CREATE TABLE EMPRESA(
IdEmpresa	int PRIMARY KEY,
Documento	varchar(50),
RazonSocial varchar(50),
Correo		varchar(50),
Telefono	varchar(50)
)

go
	-----------------EstadoEquipo-------------------------
	drop table EstadoEquipo

	create table Estadoequipo(
	IdEstadoEquipo int primary key identity,
	Descripcion varchar(50),
	Estado bit,
	FechaRegistro date default getdate()
	);

	insert into Estadoequipo(Descripcion,Estado) values
	('Disponible',1),('Vendido',1),('Mantenimiento',1),('NoDisponible',1)