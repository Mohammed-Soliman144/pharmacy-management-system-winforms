CREATE PROC SP_GetLastCompID

AS

SELECT ISNULL(MAX(CompanyID) + 1, 1) FROM Companies;