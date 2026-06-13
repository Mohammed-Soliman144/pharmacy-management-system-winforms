CREATE PROC SP_BranchDELETE

@ID int

AS

DELETE FROM Branches WHERE BranchID = @ID;