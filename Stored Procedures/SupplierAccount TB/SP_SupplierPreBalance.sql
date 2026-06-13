CREATE PROC SP_SupplierPreBalance

/* Parameters of Stored Procedure */

@SearchKey Nvarchar(100),
@SearchDate1 Nvarchar(100)

--AS Keyword
AS

SELECT * FROM ViewSupplierAccountShow
WHERE [رقم المورد] = CONVERT(int,@SearchKey) AND [تاريخ إنشاء الحركة] < @SearchDate1;