CREATE PROC SP_ItemOperSearch

@ColumnName Nvarchar(25),
@SearchKey Nvarchar(100)

AS

--Case 1 Search by @ColumnName is SupplierFullName
IF @ColumnName = 'SupplierFullName'

BEGIN

SELECT * FROM ViewItemOperationShow WHERE [اسم المورد] = @SearchKey;

END

--Case 2 Search by @ColumnName is CustomerFullName
IF @ColumnName = 'CustomerFullName'

BEGIN

SELECT * FROM ViewItemOperationShow WHERE [اسم العميل] = @SearchKey;

END

--Case 3 Search by @ColumnName is ItemName
IF @ColumnName = 'ItemName'

BEGIN

SELECT * FROM ViewItemOperationShow WHERE [اسم الصنف] = @SearchKey;

END

--Case 4 Search by @ColumnName is BranchName
IF @ColumnName = 'BranchName'

BEGIN

SELECT * FROM ViewItemOperationShow WHERE [اسم الفرع] = @SearchKey;

END

--Case 5 Search by @ColumnName is StoreName
IF @ColumnName = 'StoreName'

BEGIN

SELECT * FROM ViewItemOperationShow WHERE [اسم المخزن] = @SearchKey;

END

--Case 6 Search by @ColumnName is ItemExpiryDate
IF @ColumnName = 'ItemExpiryDate'

BEGIN

SELECT * FROM ViewItemOperationShow WHERE [تاريخ صلاحية الصنف] = @SearchKey;

END

--Case 7 Search by @ColumnName is BuyBillID
IF @ColumnName = 'BuyBillID'

BEGIN

SELECT * FROM ViewItemOperationShow WHERE [رقم فاتورة الشراء] = CONVERT(int,@SearchKey);

END

--Case 8 Search by @ColumnName is SaleBillID
IF @ColumnName = 'SaleBillID'

BEGIN

SELECT * FROM ViewItemOperationShow WHERE [رقم فاتورة البيع] = CONVERT(int,@SearchKey);

END

--Case 9 Search by @ColumnName is ReBuyBillID
IF @ColumnName = 'ReBuyBillID'

BEGIN

SELECT * FROM ViewItemOperationShow WHERE [رقم فاتورة مرتجع الشراء] = CONVERT(int,@SearchKey);

END

--Case 10 Search by @ColumnName is ReSaleBillID
IF @ColumnName = 'ReSaleBillID'

BEGIN

SELECT * FROM ViewItemOperationShow WHERE [رقم فاتورة مرتجع البيع] = CONVERT(int,@SearchKey);

END
