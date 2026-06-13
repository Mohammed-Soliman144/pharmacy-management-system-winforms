USE [PharmacyDB]
GO

CREATE PROC SP_RuleUpdate


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

@PcNameWhoModified Nvarchar(50),
@RuleWhoModified int

AS

UPDATE Rules SET  
			
			[RuleID] = @RuleID,
			[RuleName] = @RuleName,
			[Rule_CustAdd] =@RuleCustAdd,
           [Rule_CustEdit] = @RuleCustEdit ,
           [Rule_CustDelete] =@RuleCustDelete,
           [Rule_CustSearch] = @RuleCustSearch,
           [Rule_CustPrint] =  @RuleCustPrint,
           [Rule_CustActivate] =  @RuleCustActivate,
           [Rule_CustBalReport] =  @RuleCustBalRpt,
           [Rule_SuppAdd] =  @RuleSuppAdd,
           [Rule_SuppEdit] =  @RuleSuppEdit ,
           [Rule_SuppDelete] = @RuleSuppDelete ,
           [Rule_SuppSearch] =  @RuleSuppSearch ,
           [Rule_SuppPrint] =  @RuleSuppPrint ,
           [Rule_SuppActivate] =  @RuleSuppActivate ,
           [Rule_SuppBalReport] =  @RuleSuppBalRpt ,
           [Rule_ItemAdd] =  		@RuleItemAdd ,
           [Rule_ItemEdit] =  @RuleItemEdit ,
           [Rule_ItemDelete] =  @RuleItemDelete ,
           [Rule_ItemSearch] =  @RuleItemSearch ,
           [Rule_ItemPrint] =  @RuleItemPrint ,
           [Rule_ItemActivate] =  @RuleItemActivate ,
           [Rule_StoreAdd] =  @RuleStoreAdd ,
           [Rule_StoreEdit] =  @RuleStoreEdit ,
           [Rule_StoreDelete] =  @RuleStoreDelete ,
           [Rule_StoreSearch] =  @RuleStoreSearch ,
           [Rule_StorePrint] =  @RuleStorePrint ,
           [Rule_StoreActivate] =  @RuleStoreActivate ,
           [Rule_BranchAdd] =  @RuleBranchAdd ,
           [Rule_BranchEdit] =  @RuleBranchEdit ,
           [Rule_BranchDelete] =  @RuleBranchDelete ,
           [Rule_BranchSearch] = @RuleBranchSearch ,
           [Rule_BranchPrint] =  @RuleBranchPrint,
           [Rule_BranchActivate] = @RuleBranchActivate,
           [Rule_UserAdd] =  @RuleUserAdd,
           [Rule_UserEdit] =  @RuleUserEdit,
           [Rule_UserDelete] =  @RuleUserDelete,
           [Rule_UserSearch] =  @RuleUserSearch,
           [Rule_UserPrint] =  @RuleUserPrint,
           [Rule_UserActivate] =  @RuleUserActivate,
           [Rule_POSAdd] =  @RulePOSAdd,
           [Rule_POSDelete] =  @RulePOSDelete,
           [Rule_POSActivate] =  	@RulePOSActivate,
           [Rule_BuyBillAdd] =  @RuleBuyAdd,
           [Rule_BuyBillSearch] =  @RuleBuySearch,
           [Rule_BuyBillPrint] =  	@RuleBuyPrint,
           [Rule_ReBuyBillAdd] = @RuleReBuyAdd,
           [Rule_ReBuyBillSearch] =  @RuleReBuySearch,
           [Rule_ReBuyBillPrint] = @RuleReBuyPrint,
           [Rule_SaleBillAdd] =  @RuleSaleAdd ,
           [Rule_SaleBillSearch] =@RuleSaleSearch ,
           [Rule_SaleBillPrint] =  @RuleSalePrint,
           [Rule_ReSaleBillAdd] =  @RuleReSaleAdd,
           [Rule_ReSaleBillSearch] =  @RuleReSaleSearch,
           [Rule_ReSaleBillPrint] = @RuleReSalePrint,
           [Rule_ServerSettings] =  	@RuleServer,
           [Rule_DBRestore] =  @RuleRestoreDB,
           [Rule_DBBackup] =  @RuleBackupDB,
           [Rule_RuleAdd] =  @RuleAdd,
           [Rule_RuleEdit] = @RuleEdit,
		   [Rule_RuleDelete] = @RuleDelete,
           [PCNameWhoModified] =  @PcNameWhoModified,
           [RuleWhoModified] =  @RuleWhoModified

		   WHERE RuleID = @RuleID;
			
