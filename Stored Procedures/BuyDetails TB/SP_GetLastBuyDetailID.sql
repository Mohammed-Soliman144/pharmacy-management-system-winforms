CREATE PROC SP_GetLastBuyDetailID

AS

SELECT ISNULL(MAX(BuyDetailID) + 1,1) FROM BuyDetails;