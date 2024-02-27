CREATE OR ALTER PROCEDURE GetUsuario
(
   @UsuarioID  INT
)
AS
BEGIN 
   SELECT * FROM tb_teste
   WHERE Id = @UsuarioID; -- Use semicolon to terminate statement
END