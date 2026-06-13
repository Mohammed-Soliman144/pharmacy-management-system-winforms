CREATE PROC SP_StoreDeactivate

@ID int,
@Status bit,
@PCNameWhoDeleted nvarchar (50),
@StoreWhoDeleted int

AS

UPDATE STORES SET StoreStatus = @Status,
				  PCNameWhoDeleted = @PCNameWhoDeleted,
				  StoreWhoDeleted = @StoreWhoDeleted

				  WHERE StoreID = @ID;