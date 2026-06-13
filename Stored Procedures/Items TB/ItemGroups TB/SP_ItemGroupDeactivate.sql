CREATE PROC SP_ItemGroupDeactivate

@ID int,
@Status bit

AS

UPDATE ItemGroups SET GroupStatus = @Status WHERE GroupID = @ID;