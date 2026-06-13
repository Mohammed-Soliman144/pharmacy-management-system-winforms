CREATE PROC SP_ItemOperationsDeactivate

@OperID int,
@OperStatus bit,
@PcNameWhoDeleted Nvarchar(50),
@ItemOperWhoDeleted int

AS

UPDATE ItemOperations SET ItemOperStatus = @OperStatus,
						  PCNameWhoDeleted = @PcNameWhoDeleted,
						  ItemOperWhoDeleted = @ItemOperWhoDeleted

						  WHERE ItemOperID = @OperID;