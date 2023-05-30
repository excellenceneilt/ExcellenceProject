create table CertificadoBuenFuncionamiento
(
	idCertificado	int primary key identity,
	FechaCreacion	datetime default getdate(),
	Emitido			nvarchar(1000),
	ValidezInicio	date,
	ValidezFin		date,
	Cumplir			nvarchar(1000),
	Recomendacion	nvarchar(1000),
	Observaciones	nvarchar(1000),

	idNegocio		int references Negocio(IdNegocio),
	RazonSocial		nvarchar(150),
	NombreComercial	nvarchar(150),
	NumeroRegistro	nvarchar(50),
	Ruc				nvarchar(60),
	Direccion		nvarchar(60),
	Telefono		nvarchar(20),

	idProducto		int references Producto(IdProducto),
	Modelo			nvarchar(50),--nombre
	Pais			nvarchar(80),
	RegistroSanitario	nvarchar(50),
	
	idCliente		int references Cliente(IdCliente),
	RazonSocialC	nvarchar(150),
	ContactoC		nvarchar(150),
	DireccionC		nvarchar(150),
	RucC			nvarchar(20),
	CorreoC			nvarchar(150),
	TelefonoC		nvarchar(50),

	idEquipo		int references Equipo(IdEquipo),
	Marca			nvarchar(50),
	SerialNumber	nvarchar(50),

	idUsuario		int references Usuario(IdUsuario),
	NombreUsuario	nvarchar(150),
	Firma			varbinary(max),

	idDT			int references DirectorTecnico(IdDirectorTecnico),
	NombreDT		nvarchar(150)
)
