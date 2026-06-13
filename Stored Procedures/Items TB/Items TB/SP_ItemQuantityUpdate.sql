ALTER PROC SP_ItemQuantityUpdate

@ItemID int,
@ItemLUnitQTY Decimal(18,3),
@ItemMUnitQTY Decimal(18,3),
@ItemSUnitQTY Decimal(18,3),
@PcNameModified Nvarchar(50),
@ItemWhoModified int

AS

UPDATE Items SET ItemLargeUnitQuantity = @ItemLUnitQTY,
				 ItemMediumUnitQuantity = @ItemMUnitQTY,
				 ItemSmallUnitQuantity = @ItemSUnitQTY,
				 PCNameWhoModified =  @PcNameModified,
				 ItemWhoModified = @ItemWhoModified
				 
				 WHERE ItemID = @ItemID;