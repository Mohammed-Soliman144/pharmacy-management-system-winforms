CREATE PROC SP_SupplierDelete

@SupID int

AS

DELETE FROM Suppliers WHERE SupplierID = @SupID;