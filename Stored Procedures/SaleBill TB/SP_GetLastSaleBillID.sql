CREATE PROC [dbo].[SP_GetLastSaleBillID]

AS

SELECT ISNULL(MAX(SaleBillID) + 1, 1) FROM SaleBill;