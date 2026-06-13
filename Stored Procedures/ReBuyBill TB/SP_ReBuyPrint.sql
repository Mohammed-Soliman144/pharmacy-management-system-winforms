CREATE PROC SP_ReBuyPrint

@SearchKey int

AS

SELECT * FROM ViewReBuyShow WHERE [رقم الفاتورة مرتجع الشراء] = @SearchKey;