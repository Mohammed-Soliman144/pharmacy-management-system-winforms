CREATE PROC SP_ItemDelete

@ID int

AS

DELETE FROM Items WHERE ItemID = @ID;