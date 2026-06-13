CREATE PROC SP_ItemDosageFormEdit

@DosageFormName Nvarchar(100),
@PcNameAdded Nvarchar(50),
@DosageWhoAdded Nvarchar(50),
@DosageStatus bit,
@Date Nvarchar(50),
@Time Nvarchar(50)

AS

INSERT INTO ItemDosageForm (DosageFormName,PCNameWhoAdded,DosageFormWhoAdded,DosageFormStatus,DosageFormDate,DosageFormTime)
					VALUES (@DosageFormName,@PcNameAdded,@DosageWhoAdded,@DosageStatus,@Date,@Time);