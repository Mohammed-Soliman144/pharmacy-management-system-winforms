USE [PharmacyDB]
GO

CREATE PROC SP_RuleSearch

@ColumnName Nvarchar(25),
@SearchKey Nvarchar(100)

AS

IF @ColumnName = 'RuleID'

BEGIN

SELECT * FROM [dbo].[Rules] WHERE RuleID = Convert(int,@SearchKey);

END


IF @ColumnName = 'RuleName'

BEGIN

SELECT * FROM [dbo].[Rules] WHERE RuleName = @SearchKey;

END





