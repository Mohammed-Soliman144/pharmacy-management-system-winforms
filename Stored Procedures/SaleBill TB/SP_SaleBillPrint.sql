CREATE PROC [dbo].[SP_SaleBillPrint]

@SearchKey int

AS

SELECT * FROM ViewSaleBillShow WHERE [رقم الفاتورة] = @SearchKey;