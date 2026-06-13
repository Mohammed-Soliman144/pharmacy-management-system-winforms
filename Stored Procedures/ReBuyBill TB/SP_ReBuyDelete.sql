CREATE PROC SP_ReBuyDelete

@ReBuyBillID int

AS

DELETE FROM ReBuyBill WHERE ReBuyID = @ReBuyBillID;