CREATE PROC SP_POSUpdate

@ID	int,
@POSName Nvarchar(50),
@POSBalance	decimal(18,3),
@PCNameWhoModified Nvarchar(50),
@POSWhoModified int


AS

UPDATE POS SET POSName = @POSName,
			   POSBalance = @POSBalance,
			   PCNameWhoModified = @PCNameWhoModified,
			   POSWhoModified = @POSWhoModified

			   WHERE POSID = @ID;