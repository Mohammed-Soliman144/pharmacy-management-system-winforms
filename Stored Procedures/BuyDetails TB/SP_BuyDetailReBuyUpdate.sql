CREATE PROC SP_BuyDetailReBuyUpdate

@BuyDetailReBuyItem  bit,
@BuyDetailID int,
@BuyDetailReBuyID int,
@BuyDetailReBuyQuantity int,
@BuyDetailReBuyPrice  decimal (18,3),
@BuyDetailReBuyTotalBuy decimal (18,3),
@BuyDetailReBuyTotalSale decimal (18,3),
@BuyDetailReBuyNotes Nvarchar(50),
@PCNameWhoModified Nvarchar(50),
@BuyDetailWhoModified int

AS

/* Update BuyDetails if RePurchase Invoice */ 
UPDATE BuyDetails SET 
					  BuyDetailReBuyID = @BuyDetailReBuyID,
					  BuyDetailReBuyPrice = @BuyDetailReBuyPrice, 
					  BuyDetailReBuyQuantity =@BuyDetailReBuyQuantity,
					  BuyDetailReBuyTotalBuy = @BuyDetailReBuyTotalBuy,
					  BuyDetailReBuyTotalSale = @BuyDetailReBuyTotalSale,
					  BuyDetailReBuyNotes = @BuyDetailReBuyNotes,
					  BuyDetailReBuyItem = 1,
					  PCNameWhoModified =@PCNameWhoModified,
					  BuyDetailWhoModified =@BuyDetailWhoModified WHERE BuyDetailID = @BuyDetailID;

