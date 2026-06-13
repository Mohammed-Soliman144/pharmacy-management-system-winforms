CREATE PROC SP_BuyDetailDelete

@BuyDetailID int

AS

DELETE FROM BuyDetails WHERE BuyDetailID = @BuyDetailID;