CREATE PROC [dbo].[SP_SaleDetailUpdate]

@SaleDetailID int,
@SaleDetailItemID int,
@SaleDetailItemUnit Nvarchar(50),
@SaleDetailItemBalance decimal (18,3),
@SaleDetailItemSalePrice decimal (18,3),
@SaleDetailItemNetSalePrice decimal (18,3),
@SaleDetailItemBuyPrice  decimal (18,3),
@SaleDetailSaleQuantity  decimal (18,3),
@SaleDetailSaleExpiryDate Nvarchar(50),

@SaleDetailSaleExpiryQty  decimal (18,3),
@SaleDetailTotalSale  decimal (18,3),
@SaleDetailNetSale  decimal (18,3),

@SaleDetailDiscound  decimal (18,3),
@SaleDetailTotalBuy  decimal (18,3),
@SaleDetailUnitTax decimal (18,3),
@SaleDetailTotalTax  decimal (18,3),
@SaleDetailUnitEarn  decimal (18,3),
@SaleDetailTotalEarn  decimal (18,3),
@SaleDetailNotes Nvarchar(50),
@PCNameWhoModified Nvarchar(50),
@SaleDetailWhoModified int

AS



UPDATE SaleDetails SET SaleDetailItemID = @SaleDetailItemID,
					   SaleDetailItemUnit = @SaleDetailItemUnit,
					   SaleDetailItemBalance = @SaleDetailItemBalance,
					   SaleDetailItemSalePrice = @SaleDetailItemSalePrice,
					   SaleDetailItemFreeSalePrice = @SaleDetailItemNetSalePrice,
					   SaleDetailSaleQuantity = @SaleDetailSaleQuantity,
					   SaleDetailSaleExpiryDate = @SaleDetailSaleExpiryDate, 
					   SaleDetailSaleExpiryQuantity = @SaleDetailSaleExpiryQty,
					   SaleDetailTotalSale =@SaleDetailTotalSale,
					   SaleDetailNetSale =@SaleDetailNetSale,
					   SaleDetailDiscound =@SaleDetailDiscound,
					   SaleDetailTotalBuy =@SaleDetailTotalBuy,
					   SaleDetailUnitTax =@SaleDetailUnitTax,
					   SaleDetailTotalTax =@SaleDetailTotalTax,
					   SaleDetailUnitEarn =@SaleDetailUnitEarn,
					   SaleDetailTotalEarn =@SaleDetailTotalEarn,
					   SaleDetailNotes = @SaleDetailNotes,
					   PCNameWhoModified = @PCNameWhoModified,
					   SaleDetailWhoModified = @SaleDetailWhoModified

		WHERE SaleDetailID = @SaleDetailID;

		