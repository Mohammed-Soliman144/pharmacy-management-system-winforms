CREATE PROC SP_ItemGenericEdit

@GenericName Nvarchar(100),
@PcNameAdded Nvarchar(50),
@GenericWhoAdded Nvarchar(50),
@GenericStatus bit,
@Date Nvarchar(50),
@Time Nvarchar(50)

AS

INSERT INTO ItemGenerics (GenericName,PCNameWhoAdded,GenericWhoAdded,GenericStatus,GenericDate,GenericTime)
					VALUES (@GenericName,@PcNameAdded,@GenericWhoAdded,@GenericStatus,@Date,@Time);