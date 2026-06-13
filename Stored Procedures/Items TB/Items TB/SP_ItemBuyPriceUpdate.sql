CREATE PROC [dbo].[SP_ItemBuyPriceUpdate]

@ItemID int,
@ItemLUnitBuyPRC Decimal(18,3),
@ItemMUnitBuyPRC Decimal(18,3),
@ItemSUnitBuyPRC Decimal(18,3),
@PcNameModified Nvarchar(50),
@ItemWhoModified int

AS

UPDATE Items SET ItemLargeUnitBuyPrice = @ItemLUnitBuyPRC,
				 ItemMediumUnitBuyPrice = @ItemMUnitBuyPRC,
				 ItemSmallUnitBuyPrice = @ItemSUnitBuyPRC,
				 PCNameWhoModified =  @PcNameModified,
				 ItemWhoModified = @ItemWhoModified
				 
				 WHERE ItemID = @ItemID;