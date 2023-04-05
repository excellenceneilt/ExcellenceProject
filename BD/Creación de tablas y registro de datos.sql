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
	--............Recepcion servicio tecnico....................--

	drop table IngresoRecepcionEquipos
	

	create table IngresoRecepcionEquipos(
	IdResete int primary key identity,
	CodResete AS('RST' + RIGHT('000000000'+ CONVERT(VARCHAR, IdResete),(7))),
	FechaResete  date default getdate() ,
	FechaRegistroVenta date,
	OST varchar(8),
	Cliente nvarchar(50),
	RUC nvarchar(50),
	Contacto nvarchar(50),
	Correo nvarchar(50),
	TelefonoContacto nvarchar(50),
	Deja nvarchar(50),
	DocumentoContacto nvarchar(50),
	Linea nvarchar(50),
	Modelo nvarchar(50),
	Serie nvarchar(50),
	FechaCompra smalldatetime,
	Garantia nvarchar(50),
	Costorev nvarchar(50),
	Costo float,
	Enciende nvarchar(50),
	Situacion nvarchar(50),
	Accesorios nvarchar(50),
	Observaciones nvarchar(50),
	Moneda nvarchar(50),
	Hora datetime,
	Hora1 nvarchar(50),
	Codequipo int
	);


	--............Línea (Categoría)....................--
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
	(1,'DNI'), (4,'Carnet extranjería'), (6,'Reg. Único de contribuyentes'), (7,'Pasaporte')





	--............Cliente....................--

	drop table CLIENTE
	select * from cliente
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
	--IdEspecialidad int references ESPECIALIDAD(IdEspecialidad)
	);
	go

	select * from PRODUCTO
	
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
	('Dermatología', 1),('Cirugía estética',1)

	
	-----------------NEGOCIO-------------------------
	create table NEGOCIO
	(
	IdNegocio int primary key,
	Nombre varchar(60),
	RUC varchar(60),
	Direccion varchar(60),
	Logo varbinary(max) NULL
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

	-----------------EQUIPO-------------------------
	drop table equipo
	create table Equipo(
	IdEquipo int primary key identity,
	CodigoEquipo int foreign key references Producto(IdProducto),
	Modelo varchar(50),
	SerialNumber varchar(50),
	IdCategoria int foreign key references Categoria(IdCategoria),
	IdEstadoEquipo  int foreign key references EstadoEquipo(IdEstadoEquipo),
	Estado bit,
	FechaRegistro date default getdate()
	);



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

select IdCliente, CodigoCliente, td.IdTipoDocumento, td.Descripcion[Documentos], Documento, RUC, RazonSocial, tc.IdTipoCliente, tc.Descripcion[TipoCliente], NombreCompleto, Direccion,CMP,e.IdEspecialidad, e.Descripcion[Especialidad],NombreComercial, DireccionComercial, Correo1,Telefono1,Correo2,Telefono2, Departamento,  c.Estado from CLIENTE c
inner join ESPECIALIDAD e on e.IdEspecialidad = c.IdEspecialidad
inner join TIPODOCUMENTO td on td.IdTipoDocumento = c.IdTipoDocumento
inner join TIPOCLIENTE tc on tc.IdTipoCliente = c.IdTipoCliente
inner join Departamento d on d.Descripcion = c.Departamento

select * from VW_PRODUCTO ORDER BY tdescripcionproducto

insert into NEGOCIO (IdNegocio,Nombre,RUC,Direccion) values (1,'GRUPO DE INVERSIONES Y DROGUERIAS MONSALVE SAC','20602438881','AV. JUAN DE ALIAGA NRO. 455 INT. 701A URB. SAN FELIPE LIMA')