CREATE PROC SP_UserSelectedPrint

@ID int

AS

SELECT * FROM Users WHERE UserID = @ID;
