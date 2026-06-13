CREATE PROC [dbo].[SP_GetLastReSaleID]

AS

SELECT ISNULL(MAX(ReSaleID) + 1,1) FROM ReSaleBill;