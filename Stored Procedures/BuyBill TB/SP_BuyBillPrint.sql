CREATE PROC SP_BuyBillPrint

@SearchKey int

AS

SELECT * FROM ViewBuyBillShow WHERE [رقم الفاتورة] = @SearchKey;