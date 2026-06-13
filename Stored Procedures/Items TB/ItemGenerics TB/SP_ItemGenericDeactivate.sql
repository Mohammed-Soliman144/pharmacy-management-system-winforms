CREATE PROC SP_ItemGenericDeactivate

@ID int,
@Status bit

AS

UPDATE ItemGenerics SET GenericStatus = @Status WHERE GenericID = @ID;