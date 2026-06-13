CREATE PROC SP_ItemDeactivate

@ID int,
@Status bit,
@PcNameWhoDeleted Nvarchar(50),
@ItemWhoDeleted int

AS

UPDATE Items SET ItemStatus = @Status,
				 PcNameWhoDeleted = @PcNameWhoDeleted,
				 ItemWhoDeleted = @ItemWhoDeleted WHERE ItemID = @ID;
				 

