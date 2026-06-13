CREATE PROC [dbo].[SP_ReSaleBillTotalSearch]

@ColumnName Nvarchar(25),
@SearchKey Nvarchar(100)

AS

--Case 1 Search by @ColumnName is ReSaleID
IF @ColumnName = 'ReSaleID'

BEGIN

SELECT * FROM ViewReSaleTotalShow WHERE [رقم فاتورة مرتجع البيع] = CONVERT(int, @SearchKey);

END