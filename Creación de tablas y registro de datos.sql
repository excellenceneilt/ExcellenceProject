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
	('Persona natural',1, GETDATE()), ('Persona jurídica',1,GETDATE())



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
	(1,'DNI'), (4,'Carnet extranjería'), (6,'Reg. Único de contribuyentes'), (7,'Pasaporte')





	--............Cliente....................--

	drop table CLIENTE

	create table CLIENTE(
	IdCliente int primary key identity not null,
	CodigoCliente  AS('CL' + RIGHT('000000000'+ CONVERT(VARCHAR, IdCliente),(4))),  --New
	Documento varchar(50), --dni
	NombreCompleto nvarchar(50),
	NombreComercial nvarchar(50), --New
	Direccion nvarchar(50), --New
	DireccionComercial nvarchar(50),--New
	Correo1 varchar(50),
	Correo2 varchar(50),
	Telefono1 varchar(50),
	Telefono2 varchar(50),
	CMP varchar(7),
	RazonSocial varchar(100),
	RUC varchar(20),
	IdDepartamento int,--New
	IdProvincia int,--New
	IdDistrito int,--New
	IdDepartamentoComercial nvarchar(50),--New
	IdProvinciaComercial nvarchar(50),--New
	IdDistritoComercial nvarchar(50),--New
	Estado bit,
	FechaRegistro datetime default getdate(),
	IdTipoCliente int references TIPOCLIENTE(IdTipoCliente), --New
	IdTipoDocumento int references TIPODOCUMENTO(IdTipoDocumento),
	IdEspecialidad int references ESPECIALIDAD(IdEspecialidad)
	);
	go

	
	select * from cliente
	
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
	('Dermatología', 1),('Cirugía estética',1)




	-------------------------------------INSERT INTO----------------------------------------------


insert into ROL(Descripcion)
values 
('Administrador'),('Marketing'),('Contabilidad'),('Servicio técnico')

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
('Depilación',1),
('Exfoliación',1)

insert into PRODUCTO(Codigo, Nombre, Descripcion, IdCategoria)values
('F001', 'Máquina1', 'Depiladora',5)

select * from CLIENTE