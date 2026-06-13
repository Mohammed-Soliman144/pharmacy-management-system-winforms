CREATE PROC [dbo].[SP_ReSaleEdit]

@ReSaleBillID int,
@ReSaleCustomID Nvarchar(50),
@ReSaleBillTotalSaleAmount decimal(18,3),
@ReSaleBillTotalBuyAmount decimal(18,3),
@ReSaleBillItemCount int,
@ReSaleBillNotes Nvarchar(100),

@ReSaleBillTotalRequired decimal(18,3),
@ReSaleBillTotalPaid decimal(18,3),
@ReSaleBillTotalRemain decimal(18,3),

@PcNameWhoAdded Nvarchar(50),
@ReSaleBillWhoAdded int,
@ReSaleBillDate Nvarchar(50),
@ReSaleBillTime Nvarchar(50)

AS

INSERT INTO ReSaleBill (ReSaleID, ReSaleCustomID, ReSaleTotalSaleAmount, ReSaleTotalBuyAmount, ReSaleItemsCount, ReSaleNotes,
					   ReSaleTotalAmount,ReSaleTotalPaid,ReSaleTotalRemain, PCNameWhoAdded, ReSaleWhoAdded, ReSaleStatus, 
					   ReSaleDate, ReSaleTime)
			
			VALUES  (@ReSaleBillID,@ReSaleCustomID, @ReSaleBillTotalSaleAmount,@ReSaleBillTotalBuyAmount,@ReSaleBillItemCount,
			         @ReSaleBillNotes,@ReSaleBillTotalRequired, @ReSaleBillTotalPaid, @ReSaleBillTotalRemain,@PcNameWhoAdded,@ReSaleBillWhoAdded,
					 1,@ReSaleBillDate ,@ReSaleBillTime );