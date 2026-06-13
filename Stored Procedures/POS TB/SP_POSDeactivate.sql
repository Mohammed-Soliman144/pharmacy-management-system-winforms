ALTER PROC SP_POSDeactivate

@ID	int,
@POSStatus bit,
@PCNameWhoDeleted Nvarchar(50),
@POSWhoDeleted int


AS

UPDATE POS SET POSStatus = @POSStatus,
			   PCNameWhoDeleted = @PCNameWhoDeleted,
			   POSWhoDeleted = @POSWhoDeleted

			   WHERE POSID = @ID;

