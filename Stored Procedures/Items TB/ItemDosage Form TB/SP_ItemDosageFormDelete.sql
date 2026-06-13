CREATE PROC SP_ItemDosageFormDelete

@ID int

AS

DELETE FROM ItemDosageForm WHERE DosageFormID = @ID;