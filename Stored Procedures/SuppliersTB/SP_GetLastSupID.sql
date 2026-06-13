CREATE PROC SP_GetLastSupID

AS


SELECT ISNULL(MAX(SupplierID) + 1,1) FROM Suppliers;