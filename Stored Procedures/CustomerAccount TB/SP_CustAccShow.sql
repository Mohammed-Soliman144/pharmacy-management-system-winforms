CREATE PROC [dbo].[SP_CustAccShow]

AS

SELECT dbo.CustomerAccount.CustAccID AS [رقم الحركة], dbo.CustomerAccount.CustAccCustomID AS [رقم الفاتورة الداخلى], dbo.CustomerAccount.CustAccCustomerID AS [رقم العميل], dbo.Customers.CustomerFullName AS [اسم العميل], 
                  dbo.Customers.CustomerPhoneN1 AS [رقم الهاتف الاول], dbo.Customers.CustomerPhoneN2 AS [رقم الهاتف الثانى], dbo.Customers.CustomerFax AS [فاكس العميل], dbo.Customers.CustomerAddress AS [عنوان العميل], 
                  dbo.Customers.CustomerCompanyName AS [الشرركة التابعة للعميل], dbo.Customers.CustomerEmail AS [ايميل العميل], dbo.Customers.CustomerCreditLimit AS [حد الائتمان للعميل], dbo.Customers.CustomerDiscount AS [خصم المتاح للعميل], 
                  dbo.Customers.CustomerDebitSatus AS [حالة آتاحة السحب بالآجل], dbo.Customers.CustomerType AS [نوع العميل], dbo.CustomerAccount.CustAccBillID AS [رقم الفاتورة], dbo.CustomerAccount.CustAccOperationName AS [نوع الحركة], 
                  dbo.CustomerAccount.CustAccDebit AS [القيمة المدينة], dbo.CustomerAccount.CustAccCredit AS [القيمة الدائنة], dbo.CustomerAccount.CustAccBalance AS [الرصيد الحالى], dbo.CustomerAccount.CustAccNotes AS [ملاحظات الحركة], 
                  dbo.CustomerAccount.CustAccStatus AS [حالة الحركة], dbo.CustomerAccount.CustAccTime AS [وقت إضافة الحركة], dbo.CustomerAccount.CustAccDate AS [تاريخ إضافة الحركة]
FROM     dbo.Customers INNER JOIN
                  dbo.CustomerAccount ON dbo.Customers.CustomerID = dbo.CustomerAccount.CustAccCustomerID
WHERE  (dbo.CustomerAccount.CustAccStatus = 1)
ORDER BY [رقم الحركة]