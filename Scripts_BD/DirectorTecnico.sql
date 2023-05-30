create table DirectorTecnico
(
	idDirectorTecnico	int primary key identity,
	grado	nvarchar(50),
	nombre	nvarchar(150),
	estado	bit,
	fechaCreacion datetime
)