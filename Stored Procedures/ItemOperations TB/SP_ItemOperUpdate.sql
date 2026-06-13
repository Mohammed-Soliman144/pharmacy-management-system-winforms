CREATE PROC SP_ItemOperationsUpdate

@OperID int,
@OperName Nvarchar(50),
@OperBuyID	int,
@OperReBuyID int,
@OperSaleID	int,
@OperReSaleID int,
@OperSupplierID int,
@OperCustomerID int,
@OperBranchID int,
@OperStoreID int,
@OperItemID int,
@OperItemName Nvarchar(50),
@OperItemBalance decimal(18,3),
@OperItemQtyLarge decimal(18,3),
@OperItemQtyMedium decimal(18,3),
@OperItemQtySmall decimal(18,3),
@OperItemExpiry Nvarchar(50),
@OperItemQtyExpiry decimal(18,3),
@OperItemSalePrice decimal(18,3),
@OperItemNetSalePrice decimal(18,3),
@OperItemTotalSalePrice decimal(18,3),
@OperItemTotalNetSalePrice decimal(18,3),
@OperItemBuyPrice decimal(18,3),
@OperItemTotalBuyPrice decimal(18,3),
@OperItemDiscound decimal(18,3),
@OperItemEarn decimal(18,3),
@OperItemTotalEarn decimal(18,3),
@OperItemTax decimal(18,3),
@OperItemTotalTax decimal(18,3),
@OperItemNotes Nvarchar(50),
@PcNameWhoModified Nvarchar(50),
@ItemOperWhoModified int

AS

/* شاشة المشتريات */
IF @OperName = 'شاشة المشتريات' 

BEGIN

UPDATE ItemOperations SET 


	 --ItemOperID = ,
	 ItemOperName= @OperName,
	 ItemOperBuyID = @OperBuyID,
	 ItemOperSupplierID =@OperSupplierID,
	 ItemOperBranchID =@OperBranchID,
	 ItemOperStoreID =@OperStoreID,
	 ItemOperItemID =@OperItemID,
	 ItemOperUnitName =@OperItemName,
	 ItemOperItemBalance =@OperItemBalance,
	 ItemOperQuantityLarge =@OperItemQtyLarge,
	 ItemOperQuantityMedium =@OperItemQtyMedium,
	 ItemOperQuantitySmall =@OperItemQtySmall,
	 ItemOperExpiry =@OperItemExpiry,
	 ItemOperSalePrice =@OperItemSalePrice,
	 ItemOperTotalSalePrice =@OperItemTotalSalePrice,
	 ItemOperBuyPrice =@OperItemBuyPrice,
	 ItemOperTotalBuyPrice =@OperItemTotalBuyPrice,
	 ItemOperDiscound =@OperItemDiscound,
	 ItemOperEarnUnit =@OperItemEarn,
	 ItemOperTotalEarn =@OperItemTotalEarn,
	 ItemOperTaxUnit =@OperItemTax,
	 ItemOperTotalTax =@OperItemTotalTax,
	 ItemOperNotes = @OperItemNotes,
	 PCNameWhoModified = @PcNameWhoModified,
	 ItemOperWhoModified = @ItemOperWhoModified

WHERE ItemOperID = @OperID;


END
