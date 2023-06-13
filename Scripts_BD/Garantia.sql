create table Garantia
(
	IdGarantia	int primary key identity,
	IdEquipo	int references Equipo (IdEquipo),
	CodigoE		nvarchar(50),
	Marca		nvarchar(50),
	Modelo		nvarchar(50),
	ProductoManual	nvarchar(100),
	SerialNumber	nvarchar(50),
	Ruc nvarchar(20),
	IdCliente	int references Cliente(IdCliente),
	RazonSocial	nvarchar(150),
	Documento	nvarchar(50),
	IdVenta		int references Venta(IdVenta),
	NumeroDocumentoVenta	nvarchar(50),
	NumeroDocumentoVentaManual	nvarchar(50),
	FechaVenta	date,
	AniosGarantia	int,
	VigenciaInicio	date,
	VigenciaFin		date,
	FechaEmisionGarantia	date	
)
