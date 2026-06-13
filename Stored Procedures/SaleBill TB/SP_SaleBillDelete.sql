CREATE PROC [dbo].[SP_SaleBillDelete]

@SaleBillID int

AS

DELETE FROM SaleBill WHERE SaleBillID = @SaleBillID;