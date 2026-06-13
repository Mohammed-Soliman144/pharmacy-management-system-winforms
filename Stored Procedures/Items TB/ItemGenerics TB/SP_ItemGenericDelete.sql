CREATE PROC SP_ItemGenericDelete

@ID int

AS

DELETE FROM ItemGenerics WHERE GenericID = @ID;