	--............Tipo cliente....................--
	drop table TIPOCLIENTE

	create table TIPOCLIENTE(
	IdTipoCliente int not null identity primary key,
	Descripcion nvarchar(50),
	Estado bit,
	FechaRegistro datetime default getdate()
	);

	select * from TIPOCLIENTE

	insert into TIPOCLIENTE(Descripcion, Estado, FechaRegistro)
	values
	('Persona natural',1, GETDATE()), ('Persona jur�dica',1,GETDATE())

	--............L�nea (Categor�a)....................--
	create table Linea(
	IdLinea int primary key identity,
	Descripcion varchar(100),
	Estado bit,
	FechaRegistro datetime default getdate()
	);

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

	--............PRODUCTO ....................--
	create table Producto(
	IdProducto int
	
	
	);

	--............Tipo documento....................--
	drop table TIPODOCUMENTO

	create table TIPODOCUMENTO(
	IdTipoDocumento int not null identity primary key,
	CodigoTipo int,
	Descripcion nvarchar(50),
	Estado bit not null default 1,
	FechaRegistro datetime default getdate()
	);

	select * from TIPODOCUMENTO

	insert into TIPODOCUMENTO (CodigoTipo, Descripcion)
	values
	(1,'DNI'), (4,'Carnet extranjer�a'), (6,'Reg. �nico de contribuyentes'), (7,'Pasaporte')





	--............Cliente....................--

	drop table CLIENTE

	create table CLIENTE(
	IdCliente int primary key identity not null,
	CodigoCliente  AS('CL' + RIGHT('000000000'+ CONVERT(VARCHAR, IdCliente),(7))),  --New
	Documento varchar(50) unique, --dni
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
	CMP varchar(7) unique,
	RazonSocial varchar(100),
	RUC varchar(20) unique,
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
	--IdEspecialidad int references ESPECIALIDAD(IdEspecialidad)
	);
	go

	
	use EXCELLENCE5
	select * from clientes

	use DBSISTEMA_EXCELLENCE
	select * from cliente
	delete from cliente
	select * from Departamento

	alter table cliente alter column IdDepartamento nvarchar(50)

	
	alter table cliente drop column IdProvincia
	alter table cliente drop column IdDistrito
	alter table cliente drop column IdDepartamentoComercial
	alter table cliente drop column IdProvinciaComercial
	alter table cliente drop column IdDistritoComercial

	alter table cliente add Departamento nvarchar(50)
	alter table cliente add Provincia nvarchar(50)
	alter table cliente add Distrito nvarchar(50)
	alter table cliente add DepartamentoComercial nvarchar(50)
	alter table cliente add ProvinciaComercial nvarchar(50)
	alter table cliente add DistritoComercial nvarchar(50)


	--............Especialidad.............--

	drop table ESPECIALIDAD

	create table ESPECIALIDAD(
	IdEspecialidad int primary key identity not null,
	Descripcion varchar(50),
	Estado bit,
	FechaRegistro datetime default getdate()
	);

	select * from ESPECIALIDAD
	
	insert into ESPECIALIDAD(Descripcion,Estado) values 
	('Dermatolog�a', 1),('Cirug�a est�tica',1)




	-------------------------------------INSERT INTO----------------------------------------------


insert into ROL(Descripcion)
values 
('Administrador'),('Marketing'),('Contabilidad'),('Servicio t�cnico')

insert into USUARIO(Documento, NombreCompleto,Correo,Clave,IdRol,Estado)
values 
('admin','admin_name','admin@admin.com','admin',1,1),
('admin2','admin2_name','admin2@admin.com','admin',2,1),
('admin3','admin3_name','admin3@admin.com','admin',3,1)

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



insert into CATEGORIA(Descripcion, Estado) values 
('Depilaci�n',1),
('Exfoliaci�n',1)

insert into PRODUCTO(Codigo, Nombre, Descripcion, IdCategoria)values
('F001', 'M�quina1', 'Depiladora',5)

select * from CLIENTE

select IdCliente, CodigoCliente, td.IdTipoDocumento, td.Descripcion[Documentos], Documento, RUC, RazonSocial, tc.IdTipoCliente, tc.Descripcion[TipoCliente], NombreCompleto, Direccion,CMP,e.IdEspecialidad, e.Descripcion[Especialidad],NombreComercial, DireccionComercial, Correo1,Telefono1,Correo2,Telefono2, Departamento,  c.Estado from CLIENTE c
inner join ESPECIALIDAD e on e.IdEspecialidad = c.IdEspecialidad
inner join TIPODOCUMENTO td on td.IdTipoDocumento = c.IdTipoDocumento
inner join TIPOCLIENTE tc on tc.IdTipoCliente = c.IdTipoCliente
inner join Departamento d on d.Descripcion = c.Departamento

select * from VW_PRODUCTO ORDER BY tdescripcionproducto