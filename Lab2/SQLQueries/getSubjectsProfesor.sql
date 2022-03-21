CREATE PROCEDURE getSubjectsProfesor
	@email nvarchar(50)
AS
	SELECT GrupoClase.codigoAsig 
	FROM GrupoClase INNER JOIN ProfesorGrupo ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo 
	WHERE (ProfesorGrupo.email = @email)
