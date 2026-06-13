CREATE PROC [dbo].[SP_GetLastCustAccID]

AS

SELECT ISNULL(MAX(CustAccID) + 1, 1) FROM CustomerAccount;