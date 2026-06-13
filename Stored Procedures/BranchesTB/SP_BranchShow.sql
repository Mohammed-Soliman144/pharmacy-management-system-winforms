CREATE PROC SP_BranchShow

AS

SELECT 
	   BranchID AS 'الكود الداخلى',
	   BranchCustomCode AS 'كود الفرع',
	   BranchName AS 'اسم الفرع',
	   BranchPhoneN1 AS 'رقم المحمول الاول',
	   BranchPhoneN2 AS 'رقم المحمول الثانى',
	   BranchFax AS 'الفاكس',
	   BranchEmail AS 'الايميل', 
	   BranchAddress AS 'العنوان', 
	   BranchManager AS 'مدير الفرع',
	   BranchStatus AS 'حالة الفرع', 
	   BranchDate AS 'التاريخ', 
	   BranchTime AS 'الوقت'

FROM Branches;