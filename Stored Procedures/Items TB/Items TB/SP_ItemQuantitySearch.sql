CREATE PROC SP_ItemQuantitySearch

@ColumnName Nvarchar(25),
@SearchKey Nvarchar(100)

AS

--Case 1 Search by @ColumnName is ItemID
IF @ColumnName = 'ItemID'

BEGIN

SELECT * FROM ViewItemQuantity
WHERE ItemID = CONVERT(int,@SearchKey);

END