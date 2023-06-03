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
	Marca		nvarchar(100),	--Equi
	Modelo		nvarchar(100),	--Equi
	Serial		nvarchar(100),	--Equi
	IdEstEqui	int references Estadoequipo(IdEstadoEquipo),	--estadoequipo
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

select * from IngresoRecepcionEquipos

set dateformat dmy

select IdIre,CodOst,Deja,DniDeja,Telefono,
IdCliente,Ruc,Contacto,Correo,IdEquipo,
Marca,Modelo,Serial,IdEstEqui,Fecha,
Garantia,IdMoneda,Costo,Enciende,Situacion,
Accesorios,Observaciones,FechaRegistro
from IngresoRecepcionEquipos

--PROCEDIMIENTOS ALMACENADOS
drop proc SP_RegistrarIre
create proc SP_RegistrarIre
(
	--@IdIre		int,
	@CodOst		varchar(15),
	@Deja		nvarchar(150),
	@DniDeja    nvarchar(20),
	@Telefono	nvarchar(20),
	@IdCliente	int,
	@Ruc		nvarchar(20),
	@Contacto	nvarchar(150),
	@Correo		nvarchar(150),
	@IdEquipo	int,
	@Marca		nvarchar(100),
	@Modelo		nvarchar(100),
	@Serial		nvarchar(100),
	@IdEstEqui	int,
	@Fecha		nvarchar(50),
	@Garantia	bit,
	@IdMoneda	int,
	@Costo		float,
	@Enciende	bit,
	@Situacion		nvarchar(1000),
	@Accesorios		nvarchar(1000),
	@Observaciones	nvarchar(1000),
	@FechaRegistro datetime,

	@Resultado int output,
	@Mensaje varchar(500) output
)
as begin
	set @Resultado = 0 declare @IdIre int 
	set dateformat dmy;
	if not exists(select * from IngresoRecepcionEquipos where CodOst = @CodOst)
		begin
			insert into IngresoRecepcionEquipos
			(
				Deja,DniDeja,Telefono,IdCliente,Ruc,Contacto,Correo,IdEquipo,Marca,Modelo,Serial,IdEstEqui,Fecha,Garantia,IdMoneda,Costo,Enciende,Situacion,Accesorios,Observaciones,FechaRegistro
			)
			values
			(
				@Deja,@DniDeja,@Telefono,@IdCliente,@Ruc,@Contacto,@Correo,@IdEquipo,@Marca,@Modelo,@Serial,3,@Fecha,@Garantia,@IdMoneda,@Costo,@Enciende,@Situacion,@Accesorios,@Observaciones,@FechaRegistro
			)
			update Equipo set IdEstadoEquipo = 3 where IdEquipo = @IdEquipo
		set
			@Resultado = SCOPE_IDENTITY() end else
		set
			@Mensaje = 'El OST ya existe' end
go

 drop proc SP_ModificarIre
create proc SP_ModificarIre
(
	--@IdIre		int,
	@CodOst		varchar(15),
	@Deja		nvarchar(150),
	@DniDeja    nvarchar(20),
	@Telefono	nvarchar(20),
	@IdCliente	int,
	@Ruc		nvarchar(20),
	@Contacto	nvarchar(150),
	@Correo		nvarchar(150),
	@IdEquipo	int,
	@Marca		nvarchar(100),
	@Modelo		nvarchar(100),
	@Serial		nvarchar(100),
	--@IdEstEqui	int,
	@Fecha		nvarchar(50),
	@Garantia	bit,
	@IdMoneda	int,
	@Costo		float,
	@Enciende	bit,
	@Situacion		nvarchar(1000),
	@Accesorios		nvarchar(1000),
	@Observaciones	nvarchar(1000),
	@FechaRegistro datetime,

	@Resultado int output,
	@Mensaje varchar(500) output
) as begin
set dateformat dmy;
set
	@Resultado = 1
	declare @IdIre int 
	if not exists (select * from IngresoRecepcionEquipos where CodOst = @CodOst and IdIre = @IdIre)
	begin
		update IngresoRecepcionEquipos
		set	Deja = @Deja,
			DniDeja = @DniDeja,
			Telefono = @Telefono,
			IdCliente = @IdCliente,
			Ruc = @Ruc,
			Contacto = @Contacto,
			Correo = @Correo,
			IdEquipo = @IdEquipo,
			Marca = @Marca,
			Modelo = @Modelo,
			Serial = @Serial,
			--IdEstEqui = @IdEstEqui,
			Fecha = @Fecha,
			Garantia = @Garantia,
			IdMoneda = @IdMoneda,
			Costo = @Costo,
			Enciende = @Enciende,
			Situacion = @Situacion,
			Accesorios = @Accesorios,
			Observaciones = @Observaciones,
			FechaRegistro = @FechaRegistro
		where
			IdIre = @IdIre end
	else 
	begin
		set @Resultado = 0
		set @Mensaje = 'El OST ya existe'
	end
	end
go

select CodOst from IngresoRecepcionEquipos where IdIre = 5