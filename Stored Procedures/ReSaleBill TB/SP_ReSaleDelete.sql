CREATE PROC [dbo].[SP_ReSaleDelete]

@ReSaleBillID int

AS

DELETE FROM ReSaleBill WHERE ReSaleID = @ReSaleBillID;