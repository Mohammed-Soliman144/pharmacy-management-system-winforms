CREATE PROC SP_BuyDetailDeactivate

@BuyDetailID int,
@BuyDetailStatus bit,
@PcNameWhoDeleted Nvarchar(50),
@BuyDetailWhoDeleted int


AS

UPDATE BuyDetails SET BuyDetailStatus = @BuyDetailStatus,
				   PCNameWhoDeleted = @PcNameWhoDeleted,
				   BuyDetailWhoDeleted = @BuyDetailWhoDeleted 

WHERE BuyDetailID = @BuyDetailID;