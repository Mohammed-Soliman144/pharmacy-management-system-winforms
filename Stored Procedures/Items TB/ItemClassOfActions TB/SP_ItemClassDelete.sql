CREATE PROC SP_ItemClassDelete

@ID int

AS

DELETE FROM ItemClassOfActions WHERE ClassOfActionID = @ID;