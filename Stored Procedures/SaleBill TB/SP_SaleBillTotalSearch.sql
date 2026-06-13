CREATE PROC [dbo].[SP_SaleBillTotalSearch]

@ColumnName Nvarchar(25),
@SearchKey Nvarchar(100),
@CheckSearchDate bit,
@SearchDate1 Nvarchar(50),
@SearchDate2 Nvarchar(50)

AS

--Case 1 Search by @ColumnName is SaleBillCustomID And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 and @ColumnName = 'SaleBillCustomID'

BEGIN

SELECT * FROM ViewSaleBillTotalShow WHERE [كود الفاتورة] = @SearchKey;

END

--Case 2 Search by @ColumnName is SaleBillID And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 AND @ColumnName = 'SaleBillPayType'

BEGIN

SELECT * FROM ViewSaleBillTotalShow WHERE [نوع التحصيل] =  @SearchKey;

END

--Case 3 Search by @ColumnName is SaleBillID @SearchKey = 1 (with SearchDate = True)
IF @CheckSearchDate = 1 AND @ColumnName = 'SaleBillPayType'

BEGIN

SELECT * FROM ViewSaleBillTotalShow WHERE [نوع التحصيل] =  @SearchKey AND [تاريخ إصدار فاتورة البيع] BETWEEN @SearchDate1 AND @SearchDate2;

END


--Case 4 Search by @ColumnName is SaleBillInvoiceDate And @CheckSearchDate = 1 (with SearchDate = True)
IF @CheckSearchDate = 1 AND @ColumnName = 'SaleBillInvoiceDate'

BEGIN

SELECT * FROM ViewSaleBillTotalShow WHERE [تاريخ إصدار فاتورة البيع] BETWEEN @SearchDate1 AND @SearchDate2;

END


--Case 5 Search by @ColumnName is StoreName And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 AND @ColumnName = 'StoreName'

BEGIN

SELECT * FROM ViewSaleBillTotalShow WHERE [اسم المخزن] =  @SearchKey;

END


--Case 6 Search by @ColumnName is StoreName And @CheckSearchDate = 1 (with SearchDate = True)
IF @CheckSearchDate = 1 AND @ColumnName = 'StoreName'

BEGIN

SELECT * FROM ViewSaleBillTotalShow WHERE [اسم المخزن] =  @SearchKey AND [تاريخ إصدار فاتورة البيع] BETWEEN @SearchDate1 AND @SearchDate2;

END



--Case 7 Search by @ColumnName is BranchName And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 AND @ColumnName = 'BranchName'

BEGIN

SELECT * FROM ViewSaleBillTotalShow WHERE [اسم الفرع] =  @SearchKey;

END


--Case 8 Search by @ColumnName is BranchName And @CheckSearchDate = 1 (with SearchDate = True)
IF @CheckSearchDate = 1 AND @ColumnName = 'BranchName'

BEGIN

SELECT * FROM ViewSaleBillTotalShow WHERE [اسم الفرع] =  @SearchKey AND [تاريخ إصدار فاتورة البيع] BETWEEN @SearchDate1 AND @SearchDate2;

END



--Case 10 Search by @ColumnName is SupplierFullName And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 AND @ColumnName = 'CustomerFullName'

BEGIN

SELECT * FROM ViewSaleBillTotalShow WHERE [اسم العميل] =  @SearchKey;

END


--Case 11 Search by @ColumnName is SupplierFullName And @CheckSearchDate = 1 (with SearchDate = True)
IF @CheckSearchDate = 1 AND @ColumnName = 'CustomerFullName'

BEGIN

SELECT * FROM ViewSaleBillTotalShow WHERE [اسم العميل] =  @SearchKey AND [تاريخ إصدار فاتورة البيع] BETWEEN @SearchDate1 AND @SearchDate2;

END