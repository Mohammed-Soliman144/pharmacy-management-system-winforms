CREATE PROC SP_ItemDosageFormDeactivate

@ID int,
@Status bit

AS

UPDATE ItemDosageForm SET DosageFormStatus = @Status WHERE DosageFormID = @ID;