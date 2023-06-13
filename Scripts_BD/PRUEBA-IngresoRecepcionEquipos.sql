create table recepcionST(
	IdResete int primary key identity,
	CodRest AS('RST' + RIGHT('000000000'+ CONVERT(VARCHAR, IdResete),(7))),
	FechaR nvarchar(50),
	FechaRV  date default getdate() ,
	Cliente nvarchar(100),
	RUC nvarchar(50),
	Contacto nvarchar(50),
	Correo nvarchar(50),
	TelefonoContacto nvarchar(50),
	Deja nvarchar(50),
	DocumentoContacto nvarchar(50),
	Marca nvarchar(50),
	Modelo nvarchar(50),
	Serie nvarchar(50),
	FechaC date,
	Garantia nvarchar(50),
	Costorev nvarchar(50),
	Costo float,
	Enciende nvarchar(50),
	Situacion ntext,
	Accesorios ntext,
	Observaciones ntext,
	Moneda nvarchar(50),
	Hora datetime,
	Codequipo int
	);
go


create table ordenst(
	IdOrdst int primary key identity,
	CodOrdst AS('RST' + RIGHT('000000000'+ CONVERT(VARCHAR, IdResete),(7))),
	FechaR nvarchar(50),
	FechaRV  date default getdate() ,
	Cliente nvarchar(100),
	RUC nvarchar(50),
	Contacto nvarchar(50),
	Correo nvarchar(50),
	TelefonoContacto nvarchar(50),
	Deja nvarchar(50),
	DocumentoContacto nvarchar(50),
	Marca nvarchar(50),
	Modelo nvarchar(50),
	Serie nvarchar(50),
	FechaCompra date,
	Diagnostico ntext,
	Tiempo nvarchar(50),
	Importe float,
	Moneda nvarchar(50),
	Fechaaceptacion nvarchar(50),
	Fechaaceptacionv date,
	Informe ntext,
	Resultado nvarchar(20),
	CodRest nvarchar(11),
	sw_facturado char(1),
	id_revision char(1),
	id_mantenimiento char(1),
	id_reparacion char(1)






)



















select * from IngresoRecepcionEquipos




--NO DEBERIA EJECUTAR ESE QUERY PORQUE NO EXISTE LA TABLA CATEGORIA
	SELECT IdDetalleVenta, IdProducto, v.IdVenta, c.IdCategoria, dv.FechaRegistro  from DETALLE_VENTA dv
inner join VENTA v on v.IdVenta = dv.IdVenta
inner join CATEGORIA c on c.IdCategoria = (select IdCategoria from PRODUCTO where IdProducto = dv.IdProducto)
--inner join PRODUCTO p on p.IdProducto = dv.IdProducto
where v.DocumentoCliente = '72914361'