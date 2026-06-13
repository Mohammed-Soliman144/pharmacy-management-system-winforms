CREATE PROC SP_BuyBillDeactivate

@BuyBillID int,
@BuyBillStatus bit,
@PcNameWhoDeleted Nvarchar(50),
@BuyBillWhoDeleted int


AS

UPDATE BuyBill SET BuyBillStatus = @BuyBillStatus,
				   PCNameWhoDeleted = @PcNameWhoDeleted,
				   BuyBillWhoDeleted = @BuyBillWhoDeleted 

WHERE BuyBillID = @BuyBillID;