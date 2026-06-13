CREATE PROC [dbo].[SP_GetLastSaleDetailID]

AS

SELECT ISNULL(MAX(SaleDetailID) + 1,1) FROM SaleDetails;