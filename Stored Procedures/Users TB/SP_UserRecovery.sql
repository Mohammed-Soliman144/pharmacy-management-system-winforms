CREATE PROC SP_UserRecovery

@Phone Nvarchar(25)

AS

SELECT 
		UserName,
		UserPassword

FROM USERS WHERE UserPhone = @Phone;