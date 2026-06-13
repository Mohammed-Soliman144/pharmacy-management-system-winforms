ALTER PROC [dbo].[SP_SupAccPrint]  --[SP_SupAccPrint]

/* Parameters of Stored Procedure */
@SupplierID int,
@SearchDate1 Nvarchar(100),
@SearchDate2 Nvarchar(100)


--AS Keyword
AS

/* Do not search by column Name and use IF Statement 
   but select * FROM ViewSupplierAccountShow WHERE [رقم المورد],[تاريخ إنشاء الحركة] only */
SELECT * FROM ViewSupplierAccountShow
WHERE [رقم المورد] = @SupplierID AND [تاريخ إنشاء الحركة] BETWEEN @SearchDate1 AND @SearchDate2;