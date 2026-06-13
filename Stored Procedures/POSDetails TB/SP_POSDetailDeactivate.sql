CREATE PROC SP_POSDetailDeactivate

@POSDetailID int,
@POSDetailStatus bit,
@PCNameWhoDeleted Nvarchar(50),
@POSDetailWhoDeleted int

AS

UPDATE POSDetails SET POSDetailStatus = @POSDetailStatus, 
					  PCNameWhoDeleted = @PCNameWhoDeleted,
					  POSDetailWhoDeleted = @POSDetailWhoDeleted 
               WHERE  POSDetailID = @POSDetailID;