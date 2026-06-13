CREATE PROC SP_POSDetailDeleted

@POSDetailID int

AS

DELETE FROM POSDetails WHERE POSDetailID = @POSDetailID;