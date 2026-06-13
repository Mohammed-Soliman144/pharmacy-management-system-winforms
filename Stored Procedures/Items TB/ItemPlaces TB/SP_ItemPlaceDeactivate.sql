CREATE PROC SP_ItemPlaceDeactivate

@ID int,
@Status bit

AS

UPDATE ItemPlaces SET PlaceStatus = @Status WHERE PlaceID = @ID;