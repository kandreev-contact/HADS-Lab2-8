CREATE PROCEDURE getTareas
	@codigoTarea nvarchar(50)
AS

	SELECT count(*) 
	FROM EstudianteTarea
	WHERE codTarea=@codigoTarea