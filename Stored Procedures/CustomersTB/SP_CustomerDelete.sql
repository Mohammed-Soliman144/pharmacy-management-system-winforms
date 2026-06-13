CREATE PROC SP_CustomerDelete

@CustID int

AS

DELETE FROM Customers WHERE CustomerID = @CustID;