USE [PharmacyDB]
GO

CREATE PROC SP_RuleDelete

@RuleID int


AS


DELETE FROM Rules WHERE RuleID = @RuleID;