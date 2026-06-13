CREATE PROC SP_BuyBillTotalSearch

@ColumnName Nvarchar(25),
@SearchKey Nvarchar(100),
@CheckSearchDate bit,
@SearchDate1 Nvarchar(50),
@SearchDate2 Nvarchar(50)

AS

--Case 1 Search by @ColumnName is BuyBillCustomID And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 and @ColumnName = 'BuyBillCustomID'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [كود الفاتورة] = @SearchKey;

END

--Case 2 Search by @ColumnName is BuyBillID And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 AND @ColumnName = 'BuyBillPayType'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [نوع الدفع] =  @SearchKey;

END

--Case 3 Search by @ColumnName is BuyBillID @SearchKey = 1 (with SearchDate = True)
IF @CheckSearchDate = 1 AND @ColumnName = 'BuyBillPayType'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [نوع الدفع] =  @SearchKey AND [تاريخ إصدار فاتورة الشراء] BETWEEN @SearchDate1 AND @SearchDate2;

END


--Case 4 Search by @ColumnName is BuyBillInvoiceDate And @CheckSearchDate = 1 (with SearchDate = True)
IF @CheckSearchDate = 1 AND @ColumnName = 'BuyBillInvoiceDate'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [تاريخ إصدار فاتورة الشراء] BETWEEN @SearchDate1 AND @SearchDate2;

END


--Case 5 Search by @ColumnName is StoreName And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 AND @ColumnName = 'StoreName'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [اسم المخزن] =  @SearchKey;

END


--Case 6 Search by @ColumnName is StoreName And @CheckSearchDate = 1 (with SearchDate = True)
IF @CheckSearchDate = 1 AND @ColumnName = 'StoreName'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [اسم المخزن] =  @SearchKey AND [تاريخ إصدار فاتورة الشراء] BETWEEN @SearchDate1 AND @SearchDate2;

END



--Case 7 Search by @ColumnName is BranchName And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 AND @ColumnName = 'BranchName'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [اسم الفرع] =  @SearchKey;

END


--Case 8 Search by @ColumnName is BranchName And @CheckSearchDate = 1 (with SearchDate = True)
IF @CheckSearchDate = 1 AND @ColumnName = 'BranchName'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [اسم الفرع] =  @SearchKey AND [تاريخ إصدار فاتورة الشراء] BETWEEN @SearchDate1 AND @SearchDate2;

END


--Case 9 Search by @ColumnName is BuyBillSupplierNo And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 and @ColumnName = 'BuyBillSupplierNo'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [رقم فاتورة المورد] = @SearchKey;

END



--Case 10 Search by @ColumnName is SupplierFullName And @CheckSearchDate = 0 (without SearchDate = False)
IF @CheckSearchDate = 0 AND @ColumnName = 'SupplierFullName'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [اسم المورد] =  @SearchKey;

END


--Case 11 Search by @ColumnName is SupplierFullName And @CheckSearchDate = 1 (with SearchDate = True)
IF @CheckSearchDate = 1 AND @ColumnName = 'SupplierFullName'

BEGIN

SELECT * FROM ViewBuyBillTotalShow WHERE [اسم المورد] =  @SearchKey AND [تاريخ إصدار فاتورة الشراء] BETWEEN @SearchDate1 AND @SearchDate2;

END


