CREATE PROC [dbo].[SP_SaleDetailReSaleUpdate]

@SaleDetailReSaleItem  bit,
@SaleDetailID int,
@SaleDetailReSaleID int,
@SaleDetailReSaleQuantity int,
@SaleDetailReSalePrice  decimal (18,3),
@SaleDetailReSaleTotalSale decimal (18,3),
@SaleDetailReSaleTotalBuy decimal (18,3),
@SaleDetailReSaleNotes Nvarchar(50),
@PCNameWhoModified Nvarchar(50),
@SaleDetailWhoModified int

AS

/* Update SaleDetails if RePurchase Invoice */ 
UPDATE SaleDetails SET 
					  SaleDetailReSaleID = @SaleDetailReSaleID,
					  SaleDetailReSalePrice = @SaleDetailReSalePrice, 
					  SaleDetailReSaleQuantity =@SaleDetailReSaleQuantity,
					  SaleDetailReSaleTotalSale = @SaleDetailReSaleTotalSale,
					  SaleDetailReSaleTotalBuy = @SaleDetailReSaleTotalBuy,
					  SaleDetailReSaleNotes = @SaleDetailReSaleNotes,
					  SaleDetailReSaleItem = 1,
					  PCNameWhoModified =@PCNameWhoModified,
					  SaleDetailWhoModified =@SaleDetailWhoModified WHERE SaleDetailID = @SaleDetailID;