CREATE PROC SP_ItemCompanyDeactivate

@ID int,
@Status bit

AS

UPDATE ItemCompanies SET CompanyStatus = @Status WHERE CompanyID = @ID;