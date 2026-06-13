CREATE PROC SP_UserDelete

@ID int

AS

DELETE FROM Users WHERE UserID = @ID;
