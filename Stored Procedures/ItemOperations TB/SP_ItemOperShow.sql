CREATE PROC SP_ItemOperationsShow

AS

SELECT        dbo.ItemOperations.ItemOperID AS [رقم حركة الصنف], dbo.ItemOperations.ItemOperName AS [اسم الحركة], dbo.ItemOperations.ItemOperBuyID AS [رقم فاتورة الشراء], 
                         dbo.ItemOperations.ItemOperReBuyID AS [رقم فاتورة مرتجع الشراء], dbo.ItemOperations.ItemOperSaleID AS [رقم فاتورة البيع], dbo.ItemOperations.ItemOperReSaleID AS [رقم فاتورة مرتجع البيع], 
                         dbo.ItemOperations.ItemOperSupplierID AS [رقم المورد], dbo.Suppliers.SupplierFullName AS [اسم المورد], dbo.ItemOperations.ItemOperCustomerID AS [رقم العميل], dbo.Customers.CustomerFullName AS [اسم العميل], 
                         dbo.ItemOperations.ItemOperBranchID AS [رقم الفرع], dbo.Branches.BranchName AS [اسم الفرع], dbo.ItemOperations.ItemOperStoreID AS [رقم المخزن], dbo.Stores.StoreName AS [اسم المخزن], 
                         dbo.ItemOperations.ItemOperItemID AS [رقم الصنف], dbo.Items.ItemName AS [اسم الصنف], dbo.ItemOperations.ItemOperUnitName AS [اسم وحدة الصنف], dbo.ItemOperations.ItemOperItemBalance AS [الرصيد الحالى للصنف], 
                         dbo.ItemOperations.ItemOperQuantityLarge AS [الكمية من الوحدة الكبرى], dbo.ItemOperations.ItemOperQuantityMedium AS [الكمية من الوحدة الوسطى], dbo.ItemOperations.ItemOperQuantitySmall AS [الكمية من الوحدة الصغرى], 
                         dbo.ItemOperations.ItemOperExpiry AS [تاريخ صلاحية الصنف], dbo.ItemOperations.ItemOperQuantityExpity AS [كية الصنف المتاحة من الصلاحية], dbo.ItemOperations.ItemOperSalePrice AS [سعر البيع], 
                         dbo.ItemOperations.ItemOperNetSalePrice AS [سعر بيع بعد الخصم], dbo.ItemOperations.ItemOperTotalSalePrice AS [اجمالى الجمهور بسعر البيع], dbo.ItemOperations.ItemOperTotalNetSalePrice AS [اجمالى الجمهور بسعر البيع بعد الخصم], 
                         dbo.ItemOperations.ItemOperBuyPrice AS [سعر الشراء], dbo.ItemOperations.ItemOperTotalBuyPrice AS [اجمالى الشراء], dbo.ItemOperations.ItemOperDiscound AS [خصم الصنف], dbo.ItemOperations.ItemOperEarnUnit AS [ربح الوحدة], 
                         dbo.ItemOperations.ItemOperTotalEarn AS [اجمالى ربح الصنف], dbo.ItemOperations.ItemOperTaxUnit AS [ضريبة الوحدة], dbo.ItemOperations.ItemOperTotalTax AS [اجمالى ضريبة الصنف], 
                         dbo.ItemOperations.ItemOperNotes AS [ملاحظات الصنف], dbo.ItemOperations.ItemOperStatus AS [حالة الصنف], dbo.ItemOperations.ItemOperDate AS [تاريخ إضافة الحركة], 
                         dbo.ItemOperations.ItemOperTime AS [وقت إضافة الحركة]
FROM            dbo.ItemOperations INNER JOIN
                         dbo.BuyBill ON dbo.ItemOperations.ItemOperBuyID = dbo.BuyBill.BuyBillID INNER JOIN
                         dbo.Customers ON dbo.ItemOperations.ItemOperCustomerID = dbo.Customers.CustomerID INNER JOIN
                         dbo.Branches ON dbo.ItemOperations.ItemOperBranchID = dbo.Branches.BranchID INNER JOIN
                         dbo.Suppliers ON dbo.ItemOperations.ItemOperSupplierID = dbo.Suppliers.SupplierID INNER JOIN
                         dbo.Stores ON dbo.ItemOperations.ItemOperStoreID = dbo.Stores.StoreID INNER JOIN
                         dbo.ReBuyBill ON dbo.ItemOperations.ItemOperReBuyID = dbo.ReBuyBill.ReBuyID INNER JOIN
                         dbo.Items ON dbo.ItemOperations.ItemOperItemID = dbo.Items.ItemID;