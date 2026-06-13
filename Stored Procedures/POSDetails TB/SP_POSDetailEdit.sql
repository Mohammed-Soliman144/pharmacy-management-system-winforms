CREATE PROC SP_POSDetailEdit

@POSDetailID int,
@PillID int,
@PillName Nvarchar(50),
@PillCustomCode Nvarchar(50),
@POSID int,
@POSDetailPayType Nvarchar(50),
@POSDetailDemanded	decimal(18,3),
@POSDetailPaid	decimal(18,3),
@POSDetailRemained	decimal(18,3),
@PCNameWhoAdded Nvarchar(50),
@POSDetailWhoAdded int,
@Date Nvarchar(50),
@Time Nvarchar(50)

AS

INSERT INTO POSDetails (POSDetailID, POSDetailPillID,POSDetailPillName,POSDetailPillCustomCode,POSDetailPOSID, POSDetailPayType, POSDetailDemanded,
						POSDetailPaid, POSDetailRemained,PCNameWhoAdded,POSDetailWhoAdded, POSDetailStatus,POSDetailDate, POSDetailTime)
			  VALUES   (@POSDetailID, @PillID, @PillName, @PillCustomCode, @POSID, @POSDetailPayType, @POSDetailDemanded, @POSDetailPaid, @POSDetailRemained, @PCNameWhoAdded, @POSDetailWhoAdded, 1, @Date, @Time);