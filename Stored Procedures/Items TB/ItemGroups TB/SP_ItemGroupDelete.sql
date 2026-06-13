CREATE PROC SP_ItemGroupDelete

@ID int

AS

DELETE FROM ItemGroups WHERE GroupID = @ID;