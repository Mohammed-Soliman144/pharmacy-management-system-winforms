CREATE PROC SP_GetLastUserID

--With out Parameters of Stored Procedure

AS --AS KeyWord

--Function ISNULL in SQL Used To Check if Column is null if null Which Value Want to return it ISNULL(Expression,Replacement value if Null)
--Function Max in SQL Max(ColumnName) used to get the last Value in ColumnName
SELECT ISNULL(MAX(UserID) + 1 ,1) FROM Users;