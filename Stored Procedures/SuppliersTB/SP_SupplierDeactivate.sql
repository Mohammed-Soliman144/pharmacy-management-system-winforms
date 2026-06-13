CREATE PROC SP_SupplierDeactivate

@SupID int,
@SupStatus bit,
@PCNameWhoDeleted Nvarchar(50),
@SupplierWhoDeleted int

AS

UPDATE Suppliers SET SupplierStatus = @SupStatus,
					 PCNameWhoDeleted = @PCNameWhoDeleted,
					 SupplierWhoDeleted = @SupplierWhoDeleted
					 WHERE SupplierID = @SupID;