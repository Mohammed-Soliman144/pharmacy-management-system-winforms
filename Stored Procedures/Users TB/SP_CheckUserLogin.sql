CREATE PROC SP_CheckUserLogin

@UserName Nvarchar(50),
@Password Nvarchar(25)

AS

SELECT * FROM USERS WHERE UserName = @UserName AND UserPassword = @Password;