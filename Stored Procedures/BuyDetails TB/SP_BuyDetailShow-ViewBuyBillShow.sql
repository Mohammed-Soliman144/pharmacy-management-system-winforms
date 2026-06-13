CREATE PROC SP_BuyDetailShow

AS

SELECT dbo.BuyBill.BuyBillID AS [رقم الفاتورة], dbo.BuyBill.BuyBillCustomID AS [كود الفاتورة], dbo.BuyBill.BuyBillSupplier AS [رقم المورد], dbo.Suppliers.SupplierFullName AS [اسم المورد], dbo.Suppliers.SupplierCompanyName AS [اسم شركة المورد], 
                  dbo.BuyBill.BuyBillSupplierNo AS [رقم فاتورة المورد], dbo.BuyBill.BuyBillPayType AS [نوع الدفع], dbo.BuyBill.BuyBillStore AS [رقم المخزن], dbo.Stores.StoreName AS [اسم المخزن], dbo.BuyBill.BuyBillBranch AS [رقم الفرع], 
                  dbo.Branches.BranchName AS [اسم الفرع], dbo.BuyBill.BuyBillNotes AS [ملاحظات الفاتورة], dbo.BuyBill.BuyBillInvoiceDate AS [تاريخ إصدار فاتورة الشراء], dbo.BuyBill.BuyBillTotalSaleAmount AS [اجمالى الفاتورة بسعر البيع], 
                  dbo.BuyBill.BuyBillTotalBuyAmount AS [اجمالى الفاتورة بسعر الشراء], dbo.BuyBill.BuyBillItemsCount AS [عدد الاصناف], dbo.BuyBill.BuyBillTotalEarn AS [اجمالى الربح من الفاتورة], dbo.BuyBill.BuyBillTotalTax AS [اجمالى الضريبة على الفاتورة], 
                  dbo.BuyBill.BuyBillTotalDiscound AS [اجمالى الخصم النقدى على الفاتورة], dbo.BuyBill.BuyBillTotalExpenses AS [قيمة المصروفات الاضافية], dbo.BuyBill.BuyBillTotalAmount AS [اجمالى قيمة الفاتورة], dbo.BuyBill.BuyBillTotalPaid AS [القيمة المدفوعة], 
                  dbo.BuyBill.BuyBillTotalRemain AS [القيمة المتبقية], dbo.BuyBill.BuyBillStatus AS [حالة الفاتورة], dbo.BuyBill.BuyBillDate AS [التاريخ إضافة الفاتورة], dbo.BuyBill.BuyBillTime AS [وقت إضافة الفاتورة], dbo.BuyDetails.BuyDetailID, 
                  dbo.ItemDosageForm.DosageFormID AS [رقم الشكل الدوائى], dbo.ItemDosageForm.DosageFormName AS [اسم الشكل الدوائى], dbo.ItemClassOfActions.ClassOfActionID AS [رقم القسم الطبى], 
                  dbo.ItemClassOfActions.ClassOfActionName AS [القسم الطبى], dbo.ItemGenerics.GenericID AS [رقم العلمى للدواء], dbo.ItemGenerics.GenericName AS [الاسم العلمى], dbo.BuyDetails.BuyDetailItemID AS [رقم الصنف], 
                  dbo.Items.ItemName AS [اسم الصنف], dbo.Items.ItemEnglishName AS [الصنف بالانجليزى], dbo.Items.ItemBarcode1 AS [باركود الاول للصنف], dbo.Items.ItemBarcode2 AS [الباركود الثانى للصنف], dbo.Items.ItemBarcode3 AS [الباركود الثالث], 
                  dbo.BuyDetails.BuyDetailItemUnit AS [وحدة الصنف بالفاتورة], dbo.ItemPlaces.PlaceID AS [رقم مكان الوحدة], dbo.ItemPlaces.PlaceName AS [المكان على الرف], dbo.ItemCompanies.CompanyID AS [رقم الشركة المنتجة], 
                  dbo.ItemCompanies.CompanyName AS [الشركة المنتجة], dbo.ItemGroups.GroupID AS [رقم المجموعة العلمية], dbo.ItemGroups.GroupName AS [المجموعة العلمية], dbo.ItemUnits.UnitID AS [رقم الوحدة كبرى], 
                  dbo.ItemUnits.UnitName AS [وحدة الصنف الكبرى], ItemUnits_1.UnitID AS [رقم الوحدة الوسطى], ItemUnits_1.UnitName AS [الوحدة الوسطى للصنف], ItemUnits_2.UnitID AS [رقم الوحدة الصغرى], ItemUnits_2.UnitName AS [الوحدة الصغرى للصنف], 
                  dbo.BuyDetails.BuyDetailItemBalance AS [الرصيد الحالى للصنف], dbo.BuyDetails.BuyDetailItemSalePrice AS [سعر بيع الوحدة], dbo.BuyDetails.BuyDetailItemBuyPrice AS [سعر شراء الوحدة], 
                  dbo.BuyDetails.BuyDetailBuyQuantity AS [الكمية المشتراة], dbo.BuyDetails.BuyDetailBuyExpiry AS [تاريخ صلاحية الكمية المشتراه], dbo.BuyDetails.BuyDetailTotalSale AS [اجمالى قيمة الصنف بسعر البيع], 
                  dbo.BuyDetails.BuyDetailDiscound AS [الخصم على الصنف], dbo.BuyDetails.BuyDetailTotalBuy AS [اجمالى قيمة الصنف بسعر الشراء], dbo.BuyDetails.BuyDetailItemTax AS [الضريبة على الوحدة], 
                  dbo.BuyDetails.BuyDetailTotalTax AS [اجمالى الضريبة على الصنف], dbo.BuyDetails.BuyDetailUnitEarn AS [ربح الوحدة], dbo.BuyDetails.BuyDetailTotalEarn AS [اجمالى الربح على الصنف], dbo.BuyDetails.BuyDetailNotes AS [ملاحظات الصنف], 
                  dbo.BuyDetails.BuyDetailStatus AS [حالة الصنف المشتراه], dbo.BuyDetails.BuyDetailDate AS [تاريخ إضافة الصنف], dbo.BuyDetails.BuyDetailTime AS [وقت إضافة الصنف]
FROM     dbo.ItemPlaces INNER JOIN
                  dbo.BuyBill INNER JOIN
                  dbo.BuyDetails ON dbo.BuyBill.BuyBillID = dbo.BuyDetails.BuyDetailBuyID INNER JOIN
                  dbo.Items ON dbo.BuyDetails.BuyDetailItemID = dbo.Items.ItemID INNER JOIN
                  dbo.ItemGroups ON dbo.Items.ItemGroup = dbo.ItemGroups.GroupID INNER JOIN
                  dbo.ItemCompanies ON dbo.Items.ItemCompany = dbo.ItemCompanies.CompanyID ON dbo.ItemPlaces.PlaceID = dbo.Items.ItemPlace INNER JOIN
                  dbo.ItemUnits ON dbo.Items.ItemLargeUnit = dbo.ItemUnits.UnitID INNER JOIN
                  dbo.ItemUnits AS ItemUnits_1 ON dbo.Items.ItemMediumUnit = ItemUnits_1.UnitID INNER JOIN
                  dbo.ItemUnits AS ItemUnits_2 ON dbo.Items.ItemSmallUnit = ItemUnits_2.UnitID INNER JOIN
                  dbo.Suppliers ON dbo.BuyBill.BuyBillSupplier = dbo.Suppliers.SupplierID INNER JOIN
                  dbo.Stores ON dbo.BuyBill.BuyBillStore = dbo.Stores.StoreID INNER JOIN
                  dbo.Branches ON dbo.BuyBill.BuyBillBranch = dbo.Branches.BranchID INNER JOIN
                  dbo.ItemDosageForm ON dbo.Items.ItemDosageForm = dbo.ItemDosageForm.DosageFormID INNER JOIN
                  dbo.ItemClassOfActions ON dbo.Items.ItemClassOfAction = dbo.ItemClassOfActions.ClassOfActionID INNER JOIN
                  dbo.ItemGenerics ON dbo.Items.ItemGeneric = dbo.ItemGenerics.GenericID;