CREATE PROC SP_ItemGroupEdit

@GroupName Nvarchar(100),
@PcNameAdded Nvarchar(50),
@GroupWhoAdded Nvarchar(50),
@GroupStatus bit,
@Date Nvarchar(50),
@Time Nvarchar(50)

AS

INSERT INTO ItemGroups(GroupName,PCNameWhoAdded,GroupWhoAdded,GroupStatus,GroupDate,GroupTime)
					VALUES (@GroupName,@PcNameAdded,@GroupWhoAdded,@GroupStatus,@Date,@Time);
					