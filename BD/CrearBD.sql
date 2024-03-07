use master
Create DataBase BD_RepositorioDigital
use BD_RepositorioDigital

Create table [Usuario] (
	[IdUsuario] Integer IDENTITY(1,1) NOT NULL,
	[NombreUsuario] Nvarchar(100) NULL,
	[CorreoUsuario] Nvarchar(100) NULL,
	[ContraUsuario] [varbinary](max) NULL,
	[IdTipoUsuario] Integer NOT NULL,
	[ActivoUsuario] bit,
Primary Key  ([IdUsuario])
) 
go

Create table [TipoUsuario] (
	[IdTipoUsuario] Integer IDENTITY(1,1) NOT NULL,
	[TipoUsuario] Nvarchar(30) NULL,
Primary Key  ([IdTipoUsuario])
) 
go

Create table [Archivo] (
	[IdArchivo] Integer IDENTITY(1,1) NOT NULL,
	[TituloArchivo] Nvarchar(100) NULL,
	[MateriaArchivo] Nvarchar(100) NULL,
	[CarreraArchivo] Nvarchar(100) NULL,
	[AutorArchivo] Nvarchar(100) NULL,
	[TipoArchivo] Nvarchar(100) NULL,
	[RutaArchivo] Nvarchar(max) NULL,
	[IdUsuario] Integer NOT NULL,
	[ActivoArchivo] bit,
Primary Key  ([IdArchivo])
) 
go


Alter table [Archivo] add  foreign key([IdUsuario]) references [Usuario] ([IdUsuario]) 
go
Alter table [Usuario] add  foreign key([IdTipoUsuario]) references [TipoUsuario] ([IdTipoUsuario]) 
go
