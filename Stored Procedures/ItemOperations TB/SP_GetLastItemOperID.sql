CREATE PROC SP_GetLastItemOperID

AS

SELECT ISNULL(MAX(ItemOperID) + 1, 1) FROM ItemOperations;