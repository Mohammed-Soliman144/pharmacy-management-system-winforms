CREATE PROC SP_ItemClassDeactivate

@ID int,
@Status bit

AS

UPDATE ItemClassOfActions SET ClassOfActionStatus = @Status WHERE ClassOfActionID = @ID;