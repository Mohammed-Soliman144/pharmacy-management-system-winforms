CREATE PROC [dbo].[SP_CustomerPreBalance]

/* Parameters of Stored Procedure */

@SearchKey Nvarchar(100),
@SearchDate1 Nvarchar(100)

--AS Keyword
AS

SELECT * FROM ViewCustomerAccountShow
WHERE [رقم العميل] = CONVERT(int,@SearchKey) AND [تاريخ إضافة الحركة] < @SearchDate1;