CREATE PROC SP_ItemUnitDelete

@ID int

AS

DELETE FROM ItemUnits WHERE UnitID = @ID;