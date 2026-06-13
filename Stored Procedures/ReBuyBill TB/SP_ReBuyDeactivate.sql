CREATE PROC SP_ReBuyDeactivate

@ReBuyBillID int,
@ReBuyBillStatus bit,
@PcNameWhoDeleted Nvarchar(50),
@ReBuyBillWhoDeleted int


AS

UPDATE ReBuyBill SET ReBuyStatus = @ReBuyBillStatus,
				   PCNameWhoDeleted = @PcNameWhoDeleted,
				   ReBuyWhoDeleted = @ReBuyBillWhoDeleted 

WHERE ReBuyID = @ReBuyBillID;