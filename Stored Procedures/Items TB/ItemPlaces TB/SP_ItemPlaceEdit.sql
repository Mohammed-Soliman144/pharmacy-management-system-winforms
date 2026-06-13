CREATE PROC SP_ItemPlaceEdit

@PlaceName Nvarchar(100),
@PcNameAdded Nvarchar(50),
@PlaceWhoAdded Nvarchar(50),
@PlaceStatus bit,
@Date Nvarchar(50),
@Time Nvarchar(50)

AS

INSERT INTO ItemPlaces (PlaceName,PCNameWhoAdded,PlaceWhoAdded,PlaceStatus,PlaceDate,PlaceTime)
					VALUES (@PlaceName,@PcNameAdded,@PlaceWhoAdded,@PlaceStatus,@Date,@Time);