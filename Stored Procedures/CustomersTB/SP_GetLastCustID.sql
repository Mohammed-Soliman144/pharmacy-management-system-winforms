CREATE PROC SP_GetLastCustID

--wit out any parameters of stored procedure

AS -- AS Keyword

SELECT ISNULL(MAX(CustomerID) + 1, 1) FROM Customers;

