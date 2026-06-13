USE PharmacyDB
GO

CREATE PROC SP_GetLastRuleID

AS

SELECT ISNULL( MAX(RuleID) + 1, 1) FROM Rules;