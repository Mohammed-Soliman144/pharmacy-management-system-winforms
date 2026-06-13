CREATE PROC SP_RegisterSearch

@PcNameWhoAdded Nvarchar(50)

AS

SELECT 
	   RegisterID,
	   RegisterUserID,
	   Register.PCNameWhoAdded,
	   RegisterDate,
	   RegisterTime,
	   UserName,
	   UserPassword

	   FROM Register INNER JOIN Users ON RegisterUserID = UserID Where Register.PCNameWhoAdded = @PcNameWhoAdded
	   ORDER BY RegisterID DESC;