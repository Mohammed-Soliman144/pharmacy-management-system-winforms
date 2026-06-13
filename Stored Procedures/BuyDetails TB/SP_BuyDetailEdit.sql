CREATE PROC SP_BuyDetailEdit

@BuyDetailID int,
@BuyDetailBuyID int,
@BuyDetailItemID int,
@BuyDetailItemUnit Nvarchar(50),
@BuyDetailItemBalance decimal (18,3),
@BuyDetailItemSalePrice decimal (18,3),
@BuyDetailItemBuyPrice  decimal (18,3),
@BuyDetailBuyQuantity  decimal (18,3),
@BuyDetailBuyExpiry Nvarchar(50),
@BuyDetailTotalSale  decimal (18,3),
@BuyDetailDiscound  decimal (18,3),
@BuyDetailTotalBuy  decimal (18,3),
@BuyDetailItemTax decimal (18,3),
@BuyDetailTotalTax  decimal (18,3),
@BuyDetailUnitEarn  decimal (18,3),
@BuyDetailTotalEarn  decimal (18,3),
@BuyDetailNotes Nvarchar(50),
@PCNameWhoAdded Nvarchar(50),
@BuyDetailWhoAdded int,
@BuyDetailDate Nvarchar(50),
@BuyDetailTime Nvarchar(50)

AS



INSERT INTO BuyDetails (BuyDetailID,BuyDetailBuyID,BuyDetailItemID,BuyDetailItemUnit,BuyDetailItemBalance,BuyDetailItemSalePrice
						,BuyDetailItemBuyPrice,BuyDetailBuyQuantity,BuyDetailBuyExpiry,BuyDetailTotalSale,BuyDetailDiscound,BuyDetailTotalBuy,BuyDetailItemTax
						,BuyDetailTotalTax,BuyDetailUnitEarn,BuyDetailTotalEarn,BuyDetailReBuyItem,BuyDetailNotes
						,PCNameWhoAdded,BuyDetailWhoAdded,BuyDetailStatus,BuyDetailDate,BuyDetailTime)


VALUES (@BuyDetailID ,@BuyDetailBuyID ,@BuyDetailItemID ,@BuyDetailItemUnit ,@BuyDetailItemBalance  ,@BuyDetailItemSalePrice ,
	    @BuyDetailItemBuyPrice,@BuyDetailBuyQuantity ,@BuyDetailBuyExpiry,@BuyDetailTotalSale,@BuyDetailDiscound  ,@BuyDetailTotalBuy  ,
		@BuyDetailItemTax ,@BuyDetailTotalTax  ,@BuyDetailUnitEarn  ,@BuyDetailTotalEarn  ,0,@BuyDetailNotes ,@PCNameWhoAdded ,
		@BuyDetailWhoAdded ,1,@BuyDetailDate ,@BuyDetailTime);
