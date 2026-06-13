CREATE PROC SP_ItemUnitDeactivate

@ID int,
@Status bit

AS

UPDATE ItemUnits SET UnitStatus = @Status WHERE UnitID = @ID;