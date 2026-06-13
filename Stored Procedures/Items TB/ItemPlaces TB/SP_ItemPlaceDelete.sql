CREATE PROC SP_ItemPlaceDelete

@ID int

AS

DELETE FROM ItemPlaces WHERE PlaceID = @ID;