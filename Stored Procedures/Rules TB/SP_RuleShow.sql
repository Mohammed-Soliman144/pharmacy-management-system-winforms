Use PharmacyDB 
GO

CREATE PROC SP_RuleShow 

AS

SELECT dbo.Rules.RuleID, dbo.Rules.RuleName, dbo.Rules.Rule_CustAdd, dbo.Rules.Rule_CustEdit, dbo.Rules.Rule_CustDelete, dbo.Rules.Rule_CustSearch, dbo.Rules.Rule_CustPrint, dbo.Rules.Rule_CustActivate, 
                  dbo.Rules.Rule_CustBalReport, dbo.Rules.Rule_SuppAdd, dbo.Rules.Rule_SuppEdit, dbo.Rules.Rule_SuppDelete, dbo.Rules.Rule_SuppSearch, dbo.Rules.Rule_SuppPrint, dbo.Rules.Rule_SuppActivate, dbo.Rules.Rule_SuppBalReport, 
                  dbo.Rules.Rule_ItemAdd, dbo.Rules.Rule_ItemEdit, dbo.Rules.Rule_ItemDelete, dbo.Rules.Rule_ItemSearch, dbo.Rules.Rule_ItemPrint, dbo.Rules.Rule_ItemActivate, dbo.Rules.Rule_StoreAdd, dbo.Rules.Rule_StoreEdit, 
                  dbo.Rules.Rule_StoreDelete, dbo.Rules.Rule_StoreSearch, dbo.Rules.Rule_StorePrint, dbo.Rules.Rule_StoreActivate, dbo.Rules.Rule_BranchAdd, dbo.Rules.Rule_BranchEdit, dbo.Rules.Rule_BranchDelete, 
                  dbo.Rules.Rule_BranchSearch, dbo.Rules.RuleDate, dbo.Rules.RuleTime, dbo.Rules.Rule_RuleDelete, dbo.Rules.Rule_RuleEdit, dbo.Rules.Rule_RuleAdd, dbo.Rules.Rule_DBBackup, dbo.Rules.Rule_DBRestore, 
                  dbo.Rules.Rule_ServerSettings, dbo.Rules.Rule_ReSaleBillPrint, dbo.Rules.Rule_ReSaleBillSearch, dbo.Rules.Rule_ReSaleBillAdd, dbo.Rules.Rule_SaleBillPrint, dbo.Rules.Rule_SaleBillSearch, dbo.Rules.Rule_SaleBillAdd, 
                  dbo.Rules.Rule_ReBuyBillPrint, dbo.Rules.Rule_ReBuyBillSearch, dbo.Rules.Rule_ReBuyBillAdd, dbo.Rules.Rule_BuyBillPrint, dbo.Rules.Rule_BuyBillSearch, dbo.Rules.Rule_BuyBillAdd, dbo.Rules.Rule_POSActivate, 
                  dbo.Rules.Rule_POSDelete, dbo.Rules.Rule_POSAdd, dbo.Rules.Rule_UserActivate, dbo.Rules.Rule_UserPrint, dbo.Rules.Rule_UserSearch, dbo.Rules.Rule_UserDelete, dbo.Rules.Rule_UserEdit, dbo.Rules.Rule_UserAdd, 
                  dbo.Rules.Rule_BranchActivate, dbo.Rules.Rule_BranchPrint, dbo.Users.UserID, dbo.Users.UserCustomCode, dbo.Users.UserFullName, dbo.Users.UserPhone, dbo.Users.UserJob, dbo.Users.UserGender, dbo.Users.UserAddress, 
                  dbo.Users.UserIdentificationNo, dbo.Users.UserForProgram, dbo.Users.UserName, dbo.Users.UserPassword, dbo.Users.UserImage
FROM     dbo.Rules INNER JOIN
                  dbo.Users ON dbo.Rules.RuleID = dbo.Users.UserRule;
