CREATE PROC [dbo].[SP_CustAccSearch]  --SP_CustAccSearch

/* Parameters of Stored Procedure */
@ColumnName Nvarchar(25),
@SearchKey Nvarchar(100),
@OperaName Nvarchar(100),
@SearchDate1 Nvarchar(100),
@SearchDate2 Nvarchar(100)

--AS Keyword
AS


--Case 1 Search by @ColumnName is CustomerID and CustAccDate Between two Dates (to get operations of Customer Account)
IF @ColumnName = 'SearchBetweenDates'

BEGIN

SELECT * FROM ViewCustomerAccountShow
WHERE [رقم العميل]  = CONVERT(int,@SearchKey) AND  [تاريخ إضافة الحركة] BETWEEN @SearchDate1 AND @SearchDate2;

END

--Case 2 Search by @ColumnName is CustomerID and CustAccDate is less than @SearchDate1 (to get operations of Customer Account)
IF @ColumnName = 'SearchLessDate' --CustIDCustAccDateLessThanDate

BEGIN

SELECT * FROM ViewCustomerAccountShow
WHERE [رقم العميل]  = CONVERT(int,@SearchKey) AND  [تاريخ إضافة الحركة]  < @SearchDate1;

END

--Case 3 Search by @ColumnName is CustomerID and CustAccOperationName is like '%'+ @OperaName + '%' and CustAccDate Between two Dates (to get operations of Customer Account)
IF @ColumnName = 'SearchOperBetweenDates'

BEGIN

SELECT * FROM ViewCustomerAccountShow
WHERE [رقم العميل]  = CONVERT(int,@SearchKey) AND [رقم الفاتورة الداخلى] LIKE '%' + @OperaName + '%' AND  [تاريخ إضافة الحركة]  BETWEEN @SearchDate1 AND @SearchDate2;

END


--Case 4 Search by @ColumnName is CustomerID and CustAccOperationName is like '%'+ @OperaName + '%' and CustAccDate is less than @SearchDate1 (to get operations of Customer Account)
IF @ColumnName = 'SearchOperLessDate'

BEGIN

SELECT * FROM ViewCustomerAccountShow
WHERE [رقم العميل]  = CONVERT(int,@SearchKey) AND [رقم الفاتورة الداخلى] LIKE '%' + @OperaName + '%' AND [تاريخ إضافة الحركة] < @SearchDate1;

END

--Case 5 Search by @ColumnName is CustomerID (to get operations of Customer Account)
IF @ColumnName = 'CustomerID'

BEGIN

SELECT * FROM ViewCustomerAccountShow
WHERE [رقم العميل] = CONVERT(int,@SearchKey);

END