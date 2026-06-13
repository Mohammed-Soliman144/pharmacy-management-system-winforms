CREATE PROC SP_ItemOperationsDelete

@OperID int

AS

DELETE FROM ItemOperations WHERE ItemOperID = @OperID;