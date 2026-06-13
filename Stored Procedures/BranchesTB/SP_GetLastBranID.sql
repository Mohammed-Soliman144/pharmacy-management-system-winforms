CREATE PROC SP_GetLastBranID

AS

SELECT ISNULL(MAX(BranchID) + 1, 1) FROM Branches;