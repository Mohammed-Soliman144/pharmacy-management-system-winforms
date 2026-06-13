CREATE PROC [dbo].[SP_SaleBillDeactivate]

@SaleBillID int,
@SaleBillStatus bit,
@PcNameWhoDeleted Nvarchar(50),
@SaleBillWhoDeleted int


AS

UPDATE SaleBill SET SaleBillStatus = @SaleBillStatus,
				   PCNameWhoDeleted = @PcNameWhoDeleted,
				   SaleBillWhoDeleted = @SaleBillWhoDeleted 

WHERE SaleBillID = @SaleBillID;