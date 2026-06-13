ALTER PROC SP_SupplierBalanceUpdate

@SupID int,
@Balance decimal(18,3),
@PCNameWhoModified Nvarchar(50),
@SupWhoModified int

AS

UPDATE Suppliers SET SupplierBalance = @Balance,
					 PCNameWhoModified = @PCNameWhoModified,
					 SupplierWhoModified = @SupWhoModified
					 WHERE SupplierID = @SupID;