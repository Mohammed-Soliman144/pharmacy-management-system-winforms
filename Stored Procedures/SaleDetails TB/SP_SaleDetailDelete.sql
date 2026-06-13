CREATE PROC [dbo].[SP_SaleDetailDelete]

@SaleDetailID int

AS

DELETE FROM SaleDetails WHERE SaleDetailID = @SaleDetailID;