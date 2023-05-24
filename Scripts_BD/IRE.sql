create table IngresoRecepcionEquipos
(
	IdIre		int primary key identity,	--IRE
	CodOst		AS('RST' + RIGHT('000000000'+ CONVERT(VARCHAR, IdIre),(7))),	--IRE
	Deja		nvarchar(150),	--IRE
	DniDeja		nvarchar(20),	--IRE
	Telefono	nvarchar(20),	--IRE
	IdCliente	int references Cliente(IdCliente),	--Cli
	Ruc			nvarchar(20),	--Cli
	Contacto	nvarchar(150),	--Cli
	Correo		nvarchar(150),	--Cli
	IdEquipo	int references Equipo(IdEquipo),	--Equi
	Codigo		nvarchar(100),	--Equi
	Marca		nvarchar(100),	--Equi
	Modelo		nvarchar(100),	--Equi
	Serial		nvarchar(100),	--Equi
	IdEstEqui	int references Estadoequipo(IdEstadoEquipo),	--estadoequipo
	Estado		bit,	--Equi
	IdProducto	int,	--Equi
	IdCompra	int,	--Equi
	IdDetalleC	int,	--Equi
	Fecha		nvarchar(50),	--Venta
	Garantia	bit,	--IRE
	IdMoneda	int references monedas(IdMoneda),	--Moneda
	Costo		float,	--IRE
	Enciende	bit,	--IRE
	Situacion	nvarchar(1000),		--IRE
	Accesorios	nvarchar(1000),		--IRE
	Observaciones	nvarchar(1000),	--IRE
	FechaRegistro datetime default getdate()	--IRE
);

