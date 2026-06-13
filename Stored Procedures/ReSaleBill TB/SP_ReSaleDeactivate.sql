CREATE PROC [dbo].[SP_ReSaleDeactivate]

@ReSaleBillID int,
@ReSaleBillStatus bit,
@PcNameWhoDeleted Nvarchar(50),
@ReSaleBillWhoDeleted int


AS

UPDATE ReSaleBill SET ReSaleStatus = @ReSaleBillStatus,
				   PCNameWhoDeleted = @PcNameWhoDeleted,
				   ReSaleWhoDeleted = @ReSaleBillWhoDeleted 

WHERE ReSaleID = @ReSaleBillID;