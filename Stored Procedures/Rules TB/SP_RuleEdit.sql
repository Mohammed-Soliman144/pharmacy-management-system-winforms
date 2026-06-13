USE [PharmacyDB]
GO

CREATE PROC SP_RuleEdit


@RuleID int,
@RuleName Nvarchar(100),

--Rules of Customers
@RuleCustAdd bit,
@RuleCustEdit bit,
@RuleCustDelete bit,
@RuleCustSearch bit,
@RuleCustPrint bit,
@RuleCustActivate bit,
@RuleCustBalRpt bit,
--Rules of Suppliers
@RuleSuppAdd bit,
@RuleSuppEdit bit,
@RuleSuppDelete bit,
@RuleSuppSearch bit,
@RuleSuppPrint bit,
@RuleSuppActivate bit,
@RuleSuppBalRpt bit,
--Rules of Items
@RuleItemAdd bit,
@RuleItemEdit bit,
@RuleItemDelete bit,
@RuleItemSearch bit,
@RuleItemPrint bit,
@RuleItemActivate bit,
--Rules of Stores
@RuleStoreAdd bit,
@RuleStoreEdit bit,
@RuleStoreDelete bit,
@RuleStoreSearch bit,
@RuleStorePrint bit,
@RuleStoreActivate bit,
--Rules of Branch
@RuleBranchAdd bit,
@RuleBranchEdit bit,
@RuleBranchDelete bit,
@RuleBranchSearch bit,
@RuleBranchPrint bit,
@RuleBranchActivate bit,
--Rules of Users
@RuleUserAdd bit,
@RuleUserEdit bit,
@RuleUserDelete bit,
@RuleUserSearch bit,
@RuleUserPrint bit,
@RuleUserActivate bit,
--Rules of POS
@RulePOSAdd bit,
@RulePOSDelete bit,
@RulePOSActivate bit,
--Rules of BuyBill
@RuleBuyAdd bit,
@RuleBuySearch bit,
@RuleBuyPrint bit,
--Rules of ReBuyBill
@RuleReBuyAdd bit,
@RuleReBuySearch bit,
@RuleReBuyPrint bit,
--Rules of Sales
@RuleSaleAdd bit,
@RuleSaleSearch bit,
@RuleSalePrint bit,
--Rules of ReSales
@RuleReSaleAdd bit,
@RuleReSaleSearch bit,
@RuleReSalePrint bit,
--Rules of Settings
@RuleServer bit,
@RuleBackupDB bit,
@RuleRestoreDB bit,

--Rules of RulesTB
@RuleAdd bit,
@RuleEdit bit,
@RuleDelete bit,

@PcNameWhoAdded Nvarchar(50),
@RuleWhoAdded int,
@RuleDate Nvarchar(50),
@RuleTime Nvarchar(50)

AS

INSERT INTO Rules   
			([RuleID]
           ,[RuleName]
           ,[Rule_CustAdd]
           ,[Rule_CustEdit]
           ,[Rule_CustDelete]
           ,[Rule_CustSearch]
           ,[Rule_CustPrint]
           ,[Rule_CustActivate]
           ,[Rule_CustBalReport]
           ,[Rule_SuppAdd]
           ,[Rule_SuppEdit]
           ,[Rule_SuppDelete]
           ,[Rule_SuppSearch]
           ,[Rule_SuppPrint]
           ,[Rule_SuppActivate]
           ,[Rule_SuppBalReport]
           ,[Rule_ItemAdd]
           ,[Rule_ItemEdit]
           ,[Rule_ItemDelete]
           ,[Rule_ItemSearch]
           ,[Rule_ItemPrint]
           ,[Rule_ItemActivate]
           ,[Rule_StoreAdd]
           ,[Rule_StoreEdit]
           ,[Rule_StoreDelete]
           ,[Rule_StoreSearch]
           ,[Rule_StorePrint]
           ,[Rule_StoreActivate]
           ,[Rule_BranchAdd]
           ,[Rule_BranchEdit]
           ,[Rule_BranchDelete]
           ,[Rule_BranchSearch]
           ,[Rule_BranchPrint]
           ,[Rule_BranchActivate]
           ,[Rule_UserAdd]
           ,[Rule_UserEdit]
           ,[Rule_UserDelete]
           ,[Rule_UserSearch]
           ,[Rule_UserPrint]
           ,[Rule_UserActivate]
           ,[Rule_POSAdd]
           ,[Rule_POSDelete]
           ,[Rule_POSActivate]
           ,[Rule_BuyBillAdd]
           ,[Rule_BuyBillSearch]
           ,[Rule_BuyBillPrint]
           ,[Rule_ReBuyBillAdd]
           ,[Rule_ReBuyBillSearch]
           ,[Rule_ReBuyBillPrint]
           ,[Rule_SaleBillAdd]
           ,[Rule_SaleBillSearch]
           ,[Rule_SaleBillPrint]
           ,[Rule_ReSaleBillAdd]
           ,[Rule_ReSaleBillSearch]
           ,[Rule_ReSaleBillPrint]
           ,[Rule_ServerSettings]
           ,[Rule_DBRestore]
           ,[Rule_DBBackup]
           ,[Rule_RuleAdd]
           ,[Rule_RuleEdit]
		   ,[Rule_RuleDelete]
           ,[PCNameWhoAdded]
           ,[RuleWhoAdded]
           ,[RuleDate]
           ,[RuleTime])
			
VALUES  
			(@RuleID ,
			@RuleName,
			--Rules of Customers
			@RuleCustAdd ,
			@RuleCustEdit ,
			@RuleCustDelete ,
			@RuleCustSearch ,
			@RuleCustPrint ,
			@RuleCustActivate ,
			@RuleCustBalRpt ,
			--Rules of Suppliers
			@RuleSuppAdd ,
			@RuleSuppEdit ,
			@RuleSuppDelete ,
			@RuleSuppSearch ,
			@RuleSuppPrint ,
			@RuleSuppActivate ,
			@RuleSuppBalRpt ,
			--Rules of Items
			@RuleItemAdd ,
			@RuleItemEdit ,
			@RuleItemDelete ,
			@RuleItemSearch ,
			@RuleItemPrint ,
			@RuleItemActivate ,
			--Rules of Stores
			@RuleStoreAdd ,
			@RuleStoreEdit ,
			@RuleStoreDelete ,
			@RuleStoreSearch ,
			@RuleStorePrint ,
			@RuleStoreActivate ,
			--Rules of Branch
			@RuleBranchAdd ,
			@RuleBranchEdit ,
			@RuleBranchDelete ,
			@RuleBranchSearch ,
			@RuleBranchPrint,
			@RuleBranchActivate,
			@RuleUserAdd,
			@RuleUserEdit,
			@RuleUserDelete,
			@RuleUserSearch,
			@RuleUserPrint,
			@RuleUserActivate,
			@RulePOSAdd,
			@RulePOSDelete,
			@RulePOSActivate,
			@RuleBuyAdd,
			@RuleBuySearch,
			@RuleBuyPrint,
			@RuleReBuyAdd,
			@RuleReBuySearch,
			@RuleReBuyPrint,
			@RuleSaleAdd ,
			@RuleSaleSearch ,
			@RuleSalePrint,
			@RuleReSaleAdd,
			@RuleReSaleSearch,
			@RuleReSalePrint,
			@RuleServer,
			@RuleBackupDB,
			@RuleRestoreDB,
			@RuleAdd,
			@RuleEdit,
			@RuleDelete,
			@PcNameWhoAdded,
			@RuleWhoAdded,
			@RuleDate,
			@RuleTime);