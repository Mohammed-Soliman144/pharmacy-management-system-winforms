CREATE PROC SP_BuyBillDelete

@BuyBillID int

AS

DELETE FROM BuyBill WHERE BuyBillID = @BuyBillID;