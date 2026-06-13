CREATE PROC [dbo].[SP_ReSaleUpdate]

@ReSaleBillID int,
@ReSaleBillTotalSaleAmount decimal(18,3),
@ReSaleBillTotalBuyAmount decimal(18,3),
@ReSaleBillItemCount int,
@ReSaleBillNotes Nvarchar(100),
@PcNameWhoModified Nvarchar(50),
@ReSaleBillWhoModified int

AS

UPDATE ReSaleBill SET 
					ReSaleTotalSaleAmount =@ReSaleBillTotalSaleAmount, 
					ReSaleTotalBuyAmount =@ReSaleBillTotalBuyAmount, 
					ReSaleItemsCount = @ReSaleBillItemCount, 
					ReSaleNotes =@ReSaleBillNotes,
				    PCNameWhoModified = @PcNameWhoModified, 
				    ReSaleWhoModified = @ReSaleBillWhoModified
WHERE ReSaleID = @ReSaleBillID;