CREATE PROC SP_ReBuyUpdate

@ReBuyBillID int,
@ReBuyBillTotalSaleAmount decimal(18,3),
@ReBuyBillTotalBuyAmount decimal(18,3),
@ReBuyBillItemCount int,
@ReBuyBillNotes Nvarchar(100),
@PcNameWhoModified Nvarchar(50),
@ReBuyBillWhoModified int

AS

UPDATE ReBuyBill SET 
					ReBuyTotalSaleAmount =@ReBuyBillTotalSaleAmount, 
					ReBuyTotalBuyAmount =@ReBuyBillTotalBuyAmount, 
					ReBuyItemsCount = @ReBuyBillItemCount, 
					ReBuyNotes =@ReBuyBillNotes,
				    PCNameWhoModified = @PcNameWhoModified, 
				    ReBuyWhoModified = @ReBuyBillWhoModified
WHERE ReBuyID = @ReBuyBillID;

