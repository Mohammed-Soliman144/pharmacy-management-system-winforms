CREATE PROC [dbo].[SP_CustAccPrint]  --[SP_CustAccPrint]

/* Parameters of Stored Procedure */
@CustomerID int,
@SearchDate1 Nvarchar(100),
@SearchDate2 Nvarchar(100)


--AS Keyword
AS

/* Do not search by column Name and use IF Statement 
   but select * FROM ViewCustomerAccountShow WHERE [رقم المورد],[تاريخ إنشاء الحركة] only */
SELECT * FROM ViewCustomerAccountShow
WHERE [رقم العميل] = @CustomerID AND [تاريخ إضافة الحركة] BETWEEN @SearchDate1 AND @SearchDate2;