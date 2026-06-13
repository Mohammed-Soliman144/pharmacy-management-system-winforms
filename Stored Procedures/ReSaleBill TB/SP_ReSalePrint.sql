CREATE PROC [dbo].[SP_ReSalePrint]

@SearchKey int

AS

SELECT * FROM ViewReSaleShow WHERE [رقم فاتورة مرتجع البيع] = @SearchKey;