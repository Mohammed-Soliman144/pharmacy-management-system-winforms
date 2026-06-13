CREATE PROC SP_CompanyDELETE

@ID int

AS

DELETE FROM Companies WHERE CompanyID = @ID;