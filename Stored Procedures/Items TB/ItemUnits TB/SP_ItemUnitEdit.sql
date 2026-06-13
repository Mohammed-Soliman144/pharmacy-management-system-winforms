CREATE PROC SP_ItemUnitEdit

@UnitName Nvarchar(100),
@PcNameAdded Nvarchar(50),
@UnitWhoAdded Nvarchar(50),
@UnitStatus bit,
@Date Nvarchar(50),
@Time Nvarchar(50)

AS

INSERT INTO ItemUnits (UnitName,PCNameWhoAdded,UnitWhoAdded,UnitStatus,UnitDate,UnitTime)
					VALUES (@UnitName,@PcNameAdded,@UnitWhoAdded,@UnitStatus,@Date,@Time);