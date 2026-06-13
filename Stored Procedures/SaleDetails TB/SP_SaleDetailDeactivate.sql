CREATE PROC [dbo].[SP_SaleDetailDeactivate]

@SaleDetailID int,
@SaleDetailStatus bit,
@PcNameWhoDeleted Nvarchar(50),
@SaleDetailWhoDeleted int


AS

UPDATE SaleDetails SET SaleDetailStatus = @SaleDetailStatus,
					   PCNameWhoDeleted = @PcNameWhoDeleted,
				       SaleDetailWhoDeleted = @SaleDetailWhoDeleted 

WHERE SaleDetailID = @SaleDetailID;