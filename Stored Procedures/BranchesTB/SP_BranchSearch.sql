CREATE PROC SP_BranchSearch

@ColumnName Nvarchar(25),
@SearchKey Nvarchar(100)

AS

--Case 1 Search by @ColumnName is BranchCustomCode
IF @ColumnName = 'BranchCustomCode'

BEGIN

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

/*  Condition  WHERE ColumnName LIKE '%'+ @StoredProcedureParameterName +'%'  */
FROM Branches WHERE BranchCustomCode = @SearchKey;

END

--Case 2 Search by @ColumnName is BranchName
ELSE IF @ColumnName = 'BranchName'

BEGIN

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

/*  Condition  WHERE ColumnName LIKE '%'+ @StoredProcedureParameterName +'%'  */
FROM Branches WHERE BranchName LIKE '%'+ @SearchKey +'%';

END

--Case 3 Search by @ColumnName is BranchPhoneN1
ELSE IF @ColumnName = 'BranchPhoneN1'

BEGIN

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

/*  Condition  WHERE ColumnName LIKE '%'+ @StoredProcedureParameterName +'%'  */
FROM Branches WHERE BranchPhoneN1 = @SearchKey OR BranchPhoneN2 = @SearchKey;

END

--Case 4 Search by @ColumnName is BranchFax
ELSE IF @ColumnName = 'BranchFax'

BEGIN

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

/*  Condition  WHERE ColumnName LIKE '%'+ @StoredProcedureParameterName +'%'  */
FROM Branches WHERE BranchFax = @SearchKey;

END

--Case 5 Search by @ColumnName is BranchAddress
ELSE IF @ColumnName = 'BranchAddress'

BEGIN

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

/*  Condition  WHERE ColumnName LIKE '%'+ @StoredProcedureParameterName +'%'  */
FROM Branches WHERE BranchAddress LIKE '%'+ @SearchKey +'%';

END

--Case 6 Search by @ColumnName is BranchManager
ELSE IF @ColumnName = 'BranchManager'

BEGIN

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

/*  Condition  WHERE ColumnName LIKE '%'+ @StoredProcedureParameterName +'%'  */
FROM Branches WHERE CONVERT(Nvarchar,BranchManager) = @SearchKey;

END

--Case 7 Search by @ColumnName is BranchStatus
ELSE IF @ColumnName = 'BranchStatus'

BEGIN

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

/*  Condition  WHERE ColumnName LIKE '%'+ @StoredProcedureParameterName +'%'  */
FROM Branches WHERE CONVERT(Nvarchar,BranchStatus) = @SearchKey;

END