CREATE PROC SP_ItemCompanyDelete

@ID int

AS

DELETE FROM ItemCompanies WHERE CompanyID = @ID;