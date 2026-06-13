CREATE PROC SP_GetLastSupAccID

AS

SELECT ISNULL(MAX(SupAccID) + 1, 1) FROM SupplierAccount;