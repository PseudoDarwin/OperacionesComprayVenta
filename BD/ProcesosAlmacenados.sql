use  BD_RepositorioDigital

create procedure CrearUsuario
@nombreUsuario nvarchar(100),
@correo nvarchar(100),
@contra nvarchar(max)
as
begin
	insert into Usuario (NombreUsuario,CorreoUsuario,ContraUsuario,IdTipoUsuario, ActivoUsuario) values (@nombreUsuario,@correo,PWDENCRYPT(@contra),1,1)
end
go

create procedure EditarUsuario
@idUsuario integer,
@nombreUsuario nvarchar(100),
@correo nvarchar(100)
as
begin
	update Usuario set NombreUsuario=@nombreUsuario, CorreoUsuario=@correo where IdUsuario=@idUsuario
end
go


create procedure EliminarUsuario
@idUsuario integer
as
begin
	update Usuario set ActivoUsuario=0 where IdUsuario=@idUsuario
end
go

create procedure CambiarContra
@idUsuario integer,
@contra nvarchar(max)
as
begin
	update Usuario set ContraUsuario=PWDENCRYPT(@contra) where IdUsuario=@idUsuario
end
go

create procedure CrearArchivo
@titulo nvarchar(100),
@materia nvarchar(100),
@carrera nvarchar(100),	
@autor nvarchar(100),
@tipo nvarchar(100),
@ruta nvarchar(100),
@iduser integer
as
begin
	if((select count (IdArchivo) from Archivo where TituloArchivo=@titulo)<=0)
	begin
		insert into Archivo (TituloArchivo,MateriaArchivo,CarreraArchivo,AutorArchivo,TipoArchivo,RutaArchivo,IdUsuario,ActivoArchivo) 
		values (@titulo,@materia,@carrera,@autor,@tipo,@ruta,@iduser,1)
	end
end
go

create procedure EditarArchivo
@idarchivo integer,
@titulo nvarchar(100),
@materia nvarchar(100),
@carrera nvarchar(100),	
@autor nvarchar(100),
@tipo nvarchar(100)
as
begin
	update Archivo set TituloArchivo=@titulo,MateriaArchivo=@materia,CarreraArchivo=@carrera,AutorArchivo= @autor,
	TipoArchivo=@tipo
	where IdArchivo=@idarchivo
end
go

create procedure EliminarArchivo
@idarchivo integer
as
begin
	update Archivo set ActivoArchivo=0
	where IdArchivo=@idarchivo
end
go

create procedure IniciarSesion
@Usuario nvarchar(100),
@contra nvarchar(100)
as
begin
	select COUNT(IdUsuario) from Usuario where NombreUsuario=@Usuario and  PWDCOMPARE(@contra,ContraUsuario)=1
end
go


create view ViewArchivo as
select IdArchivo as Id, TituloArchivo as Titulo, MateriaArchivo as Materia, CarreraArchivo as Carrera, AutorArchivo as Autor, TipoArchivo as Tipo
from Archivo where ActivoArchivo=1



create view ViewUsuario as
select IdUsuario AS ID, NombreUsuario as Nombre, CorreoUsuario as Correo
from Usuario as u
join TipoUsuario as t on u.IdTipoUsuario=t.IdTipoUsuario 




insert into TipoUsuario (TipoUsuario) values ('Admin')

insert into TipoUsuario (TipoUsuario) values ('Estudiante')