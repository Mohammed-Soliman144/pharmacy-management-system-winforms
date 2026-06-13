CREATE PROC SP_GetLastRegID

AS

SELECT ISNULL(MAX(RegisterID) + 1, 1) FROM Register;