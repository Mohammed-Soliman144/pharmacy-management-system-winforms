CREATE PROC SP_POSShow

AS

SELECT

	POSID AS 'الكود الداخلى',
	POSCustomCode AS 'كود نقطة البيع',
	POSName AS 'اسم نقطة البيع',
	POSBalance AS 'الرصيد الحالى',
	POSStatus AS 'حالة نقطة البيع',
	POSDate AS 'التاريخ',
	POSTime AS 'الوقت'

FROM POS;