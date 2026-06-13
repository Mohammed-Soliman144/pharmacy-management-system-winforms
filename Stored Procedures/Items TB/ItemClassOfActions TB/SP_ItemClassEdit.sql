CREATE PROC SP_ItemClassEdit

@ClassName Nvarchar(100),
@PcNameAdded Nvarchar(50),
@ClassWhoAdded Nvarchar(50),
@ClassStatus bit,
@Date Nvarchar(50),
@Time Nvarchar(50)

AS

INSERT INTO ItemClassOfActions (ClassOfActionName,PCNameWhoAdded,ClassOfActionWhoAdded,ClassOfActionStatus,ClassOfActionDate,ClassOfActionTime)
					VALUES (@ClassName,@PcNameAdded,@ClassWhoAdded,@ClassStatus,@Date,@Time);