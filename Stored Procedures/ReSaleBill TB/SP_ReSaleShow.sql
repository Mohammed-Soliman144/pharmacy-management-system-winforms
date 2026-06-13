CREATE PROC [dbo].[SP_ReSaleShow]

AS

SELECT dbo.SaleBill.SaleBillID AS [رقم الفاتورة], dbo.SaleBill.SaleBillCustomID AS [كود الفاتورة], dbo.SaleBill.SaleBillCustomer AS [رقم العميل], dbo.SaleBill.SaleBillPayType AS [نوع الدفع], dbo.SaleBill.SaleBillStore AS [رقم المخزن], 
                  dbo.SaleBill.SaleBillBranch AS [رقم الفرع], dbo.SaleBill.SaleBillNotes AS [ملاحظات الفاتورة], dbo.SaleBill.SaleBillInvoiceDate AS [تاريخ إصدار فاتورة البيع], dbo.SaleBill.SaleBillTotalSaleAmount AS [اجمالى الفاتورة بسعر البيع], 
                  dbo.SaleBill.SaleBillTotalFreeSaleAmount AS [صافى الفاتورة بسعر البيع], dbo.SaleBill.SaleBillTotalBuyAmount AS [اجمالى الفاتورة بسعر الشراء], dbo.SaleBill.SaleBillItemsCount AS [عدد الاصناف], 
                  dbo.SaleBill.SaleBillTotalEarn AS [اجمالى الربح من الفاتورة], dbo.SaleBill.SaleBillTotalTax AS [اجمالى الضريبة على الفاتورة], dbo.SaleBill.SaleBillTotalDiscound AS [اجمالى الخصم النقدى على الفاتورة], 
                  dbo.SaleBill.SaleBillTotalExpenses AS [قيمة المصروفات الاضافية], dbo.SaleBill.SaleBillTotalAmount AS [اجمالى قيمة الفاتورة], dbo.SaleBill.SaleBillTotalPaid AS [القيمة المدفوعة], dbo.SaleBill.SaleBillTotalRemain AS [القيمة المتبقية], 
                  dbo.SaleBill.SaleBillStatus AS [حالة الفاتورة], dbo.SaleBill.SaleBillDate AS [تاريخ إضافة الفاتورة], dbo.SaleBill.SaleBillTime AS [وقت إضافة الفاتورة], dbo.SaleDetails.SaleDetailID, dbo.SaleDetails.SaleDetailItemID AS [رقم الصنف], 
                  dbo.Items.ItemCustomCode AS [كود الصنف], dbo.Items.ItemName AS [اسم الصنف], dbo.Items.ItemEnglishName AS [الصنف بالانجليزى], dbo.Items.ItemBarcode1 AS [باركود الاول للصنف], dbo.Items.ItemBarcode2 AS [الباركود الثانى للصنف], 
                  dbo.Items.ItemBarcode3 AS [الباركود الثالث], dbo.ItemUnits.UnitID AS [رقم الوحدة كبرى], dbo.ItemUnits.UnitName AS [وحدة الصنف الكبرى], dbo.Items.ItemLargeUnitQuantity AS [رصيد الوحدات الكبرى], ItemUnits_1.UnitID AS [رقم الوحدة الوسطى], 
                  ItemUnits_1.UnitName AS [الوحدة الوسطى للصنف], dbo.Items.ItemMediumUnitQuantity AS [رصيد الوحدات الوسطى], ItemUnits_2.UnitID AS [رقم الوحدة الصغرى], ItemUnits_2.UnitName AS [الوحدة الصغرى للصنف], 
                  dbo.Items.ItemSmallUnitQuantity AS [رصيد الوحدات الصغرى], dbo.ItemOperations.ItemOperID AS [رقم حركة الصنف], dbo.ItemOperations.ItemOperName AS [اسم الفاتورة], dbo.ItemOperations.ItemOperBuyID AS [رقم فاتورة الشراء], 
                  dbo.ItemOperations.ItemOperReBuyID AS [رقم مرتجع الشراء], dbo.ItemOperations.ItemOperSaleID AS [رقم فاتورة البيع], dbo.ItemOperations.ItemOperReSaleID AS [رقم مرتجع البيع], 
                  dbo.ItemOperations.ItemOperSupplierID AS [رقم المورد بحركة الصنف], dbo.ItemOperations.ItemOperCustomerID AS [رقم العميل بحركة الصنف], dbo.ItemOperations.ItemOperBranchID AS [رقم الفرع بحركة الصنف], 
                  dbo.ItemOperations.ItemOperStoreID AS [رقم المخزن بحركة الصنف], dbo.ItemOperations.ItemOperItemBalance AS [رصيد الصنف بحركة الصنف], dbo.ItemOperations.ItemOperQuantityLarge AS [رصيد الوحدة الكبرى بحركة الصنف], 
                  dbo.ItemOperations.ItemOperQuantityMedium AS [رصيد الوحدة الوسطى بحركة الصنف], dbo.ItemOperations.ItemOperQuantitySmall AS [رصيد الوحدة الصغرى بحركة الصنف], dbo.ItemOperations.ItemOperExpiry AS [صلاحية الصنف بحركة الصنف], 
                  dbo.ItemOperations.ItemOperQuantityExpity AS [الرصيد المتاح وفقا للصلاحية], dbo.ItemOperations.ItemOperSalePrice AS [سعر بيع الصنف بالحركة], dbo.ItemOperations.ItemOperBuyPrice AS [سعر شراء الصنف بالحركة], 
                  dbo.ItemOperations.ItemOperDiscound AS [خصم الصنف بالحركة], dbo.ItemOperations.ItemOperTaxUnit AS [ضريبة الوحدة من الصنف بالحركة], dbo.ItemOperations.ItemOperEarnUnit AS [ربح الوحدة من الصنف بالحركة], 
                  dbo.ItemDosageForm.DosageFormID AS [رقم الشكل الدوائى], dbo.ItemDosageForm.DosageFormName AS [اسم الشكل الدوائى], dbo.ItemGenerics.GenericID AS [رقم العلمى للدواء], dbo.ItemGenerics.GenericName AS [الاسم العلمى], 
                  dbo.ItemClassOfActions.ClassOfActionID AS [رقم القسم الطبى], dbo.ItemClassOfActions.ClassOfActionName AS [القسم الطبى], dbo.ItemGroups.GroupID AS [رقم المجموعة العلمية], dbo.ItemGroups.GroupName AS [المجموعة العلمية], 
                  dbo.ItemCompanies.CompanyID AS [رقم الشركة المنتجة], dbo.ItemCompanies.CompanyName AS [الشركة المنتجة], dbo.ItemPlaces.PlaceID AS [رقم مكان الوحدة], dbo.ItemPlaces.PlaceName AS [المكان على الرف], 
                  dbo.Customers.CustCustomCode AS [كود العميل], dbo.Customers.CustomerFullName AS [اسم العميل], dbo.Customers.CustomerPhoneN1 AS [رقم هاتف العميل الاول], dbo.Customers.CustomerPhoneN2 AS [رقم هاتف العميل الثانى], 
                  dbo.Customers.CustomerFax AS [فاكس العميل], dbo.Customers.CustomerAddress AS [عنوان العميل], dbo.Customers.CustomerEmail AS [ايميل العميل], dbo.Customers.CustomerType AS [نوع العميل], 
                  dbo.Customers.CustomerCompanyName AS [شركة تابعة لها العميل], dbo.Customers.CustomerCreditLimit AS [حد ائتمان العميل], dbo.Customers.CustomerDiscount AS [خصم العميل], dbo.Customers.CustomerBalance AS [رصيد العميل], 
                  dbo.Customers.CustomerDebitSatus AS [حالة رصيد العميل], dbo.Branches.BranchCustomCode AS [كود الفرع], dbo.Branches.BranchName AS [اسم الفرع], dbo.Branches.BranchPhoneN1 AS [رقم هاتف الفرع], 
                  dbo.Branches.BranchAddress AS [عنوان الفرع], dbo.Branches.BranchFax AS [فاكس الفرع], dbo.Stores.StoreCustomCode AS [كود المخزن], dbo.Stores.StoreName AS [اسم المخزن], dbo.Stores.StorePhone AS [رقم هاتف المخزن], 
                  dbo.Stores.StoreAddress AS [عنوان المخزن], dbo.Stores.StoreType AS [نوع المخزن], dbo.SaleDetails.SaleDetailItemUnit AS [وحدة الصنف بالفاتورة], dbo.SaleDetails.SaleDetailItemBalance AS [رصيد الصنف بالفاتورة], 
                  dbo.SaleDetails.SaleDetailItemSalePrice AS [سعر بيع بالفاتورة], dbo.SaleDetails.SaleDetailItemFreeSalePrice AS [صافى سعر البيع بالفاتورة], dbo.SaleDetails.SaleDetailItemBuyPrice AS [سعر شراء بالفاتورة], 
                  dbo.SaleDetails.SaleDetailSaleQuantity AS [الكمية المباعة بالفاتورة], dbo.SaleDetails.SaleDetailSaleExpiryDate AS [تاريح صلاحية الصنف بالفاتورة], dbo.SaleDetails.SaleDetailSaleExpiryQuantity AS [الكمية المتاحة وفقا للصلاحية بالفاتورة], 
                  dbo.SaleDetails.SaleDetailTotalSale AS [اجمالى الصنف بسعر البيع], dbo.SaleDetails.SaleDetailNetSale AS [صافى الصنف بسعر البيع], dbo.SaleDetails.SaleDetailTotalBuy AS [اجمالى الصنف بسعر الشراء], 
                  dbo.SaleDetails.SaleDetailDiscound AS [اجمالى خصم الصنف], dbo.SaleDetails.SaleDetailUnitTax AS [ضريبة الوحدة من الصنف], dbo.SaleDetails.SaleDetailTotalTax AS [اجمالى ضريبة الصنف], 
                  dbo.SaleDetails.SaleDetailUnitEarn AS [ربح الوحدة من الصنف], dbo.SaleDetails.SaleDetailTotalEarn AS [اجمالى ربح الصنف], dbo.SaleDetails.SaleDetailNotes AS [ملاحظات الصنف], 
                  dbo.SaleDetails.SaleDetailReSaleQuantity AS [الكمية المرتجعة من الصنف], dbo.SaleDetails.SaleDetailReSalePrice AS [سعر بيع المرتجع], dbo.SaleDetails.SaleDetailReSaleTotalSale AS [اجمالى المرتجع بسعر البيع], 
                  dbo.SaleDetails.SaleDetailReSaleTotalBuy AS [اجمالى المرتجع بسعر الشراء], dbo.SaleDetails.SaleDetailReSaleNotes AS [ملاحظات المرتجع], dbo.SaleDetails.SaleDetailReSaleItem AS [حالة الصنف المرتجع], 
                  dbo.SaleDetails.SaleDetailStatus AS [حالة الصنف], dbo.SaleDetails.SaleDetailDate AS [تاريخ اضافة الصنف], dbo.SaleDetails.SaleDetailTime AS [وقت اضافة الصنف], dbo.ReSaleBill.ReSaleID AS [رقم فاتورة مرتجع البيع], 
                  dbo.ReSaleBill.ReSaleCustomID AS [كود فاتورة مرتجع البيع], dbo.ReSaleBill.ReSaleTotalBuyAmount AS [اجمالى فاتورة المرتجع بسعر البيع], dbo.ReSaleBill.ReSaleItemsCount AS [اجمالى فاتورة المرتجع بسعر الشراء], 
                  dbo.ReSaleBill.ReSaleTotalAmount AS [القيمة المطلوبة من فاتورة المرتجع], dbo.ReSaleBill.ReSaleTotalPaid AS [القيمة المدفوعة من فاتورة المرتجع], dbo.ReSaleBill.ReSaleTotalRemain AS [القيمة المتبقية من فاتورة المرتجع], 
                  dbo.ReSaleBill.ReSaleNotes AS [ملاحظات فاتورة المرتجع], dbo.ReSaleBill.ReSaleStatus AS [حالة فاتورة مرتجع البيع], dbo.ReSaleBill.ReSaleDate AS [تاريخ فاتورة مرتجع البيع], dbo.ReSaleBill.ReSaleTime AS [وقت فاتورة مرتجع البيع]
FROM     dbo.Stores INNER JOIN
                  dbo.ItemPlaces INNER JOIN
                  dbo.ItemOperations INNER JOIN
                  dbo.ItemUnits AS ItemUnits_2 INNER JOIN
                  dbo.ItemUnits INNER JOIN
                  dbo.SaleBill INNER JOIN
                  dbo.SaleDetails ON dbo.SaleBill.SaleBillID = dbo.SaleDetails.SaleDetailSaleID INNER JOIN
                  dbo.Items ON dbo.SaleDetails.SaleDetailItemID = dbo.Items.ItemID ON dbo.ItemUnits.UnitID = dbo.Items.ItemLargeUnit INNER JOIN
                  dbo.ItemUnits AS ItemUnits_1 ON dbo.Items.ItemMediumUnit = ItemUnits_1.UnitID ON ItemUnits_2.UnitID = dbo.Items.ItemSmallUnit ON dbo.ItemOperations.ItemOperItemID = dbo.Items.ItemID INNER JOIN
                  dbo.ItemDosageForm ON dbo.Items.ItemDosageForm = dbo.ItemDosageForm.DosageFormID INNER JOIN
                  dbo.ItemGenerics ON dbo.Items.ItemGeneric = dbo.ItemGenerics.GenericID INNER JOIN
                  dbo.ItemClassOfActions ON dbo.Items.ItemClassOfAction = dbo.ItemClassOfActions.ClassOfActionID INNER JOIN
                  dbo.ItemGroups ON dbo.Items.ItemGroup = dbo.ItemGroups.GroupID INNER JOIN
                  dbo.ItemCompanies ON dbo.Items.ItemCompany = dbo.ItemCompanies.CompanyID ON dbo.ItemPlaces.PlaceID = dbo.Items.ItemPlace INNER JOIN
                  dbo.Customers ON dbo.SaleBill.SaleBillCustomer = dbo.Customers.CustomerID INNER JOIN
                  dbo.Branches ON dbo.SaleBill.SaleBillBranch = dbo.Branches.BranchID ON dbo.Stores.StoreID = dbo.SaleBill.SaleBillStore INNER JOIN
                  dbo.ReSaleBill ON dbo.SaleDetails.SaleDetailReSaleID = dbo.ReSaleBill.ReSaleID;