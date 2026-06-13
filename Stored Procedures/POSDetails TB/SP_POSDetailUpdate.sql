CREATE PROC SP_POSDetailUpdate

@POSDetailID int,
@PillID int,
@PillName Nvarchar(50),
@PillCustomCode Nvarchar(50),
@POSID int,
@POSDetailPayType Nvarchar(50),
@POSDetailDemanded	decimal(18,3),
@POSDetailPaid	decimal(18,3),
@POSDetailRemained	decimal(18,3),
@PCNameWhoModified Nvarchar(50),
@POSDetailWhoModified int

AS

UPDATE POSDetails SET POSDetailPillID = @PillID, 
					  POSDetailPillName = @PillName,
					  POSDetailPillCustomCode = @PillCustomCode,
					  POSDetailPOSID = @POSID, 
					  POSDetailPayType = @POSDetailPayType, 
					  POSDetailDemanded = @POSDetailDemanded,
					  POSDetailPaid = @POSDetailPaid, 
					  POSDetailRemained = @POSDetailRemained,
					  PCNameWhoModified = @PCNameWhoModified,
					  POSDetailWhoModified = @POSDetailWhoModified 
               WHERE  POSDetailID = @POSDetailID;
			  