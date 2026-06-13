CREATE PROC SP_ShowException

AS

SELECT [Exceptions].ExceptionID AS 'رقم الخطأ',
	   [Exceptions].ExceptionMsg AS 'رسالة الخطأ',
	   [Exceptions].ExceptionType AS 'نوع الخطأ',
	   [Exceptions].ExceptionStackTrace AS 'مكان الخطأ',
	   [Exceptions].ExceotionDate AS 'تاريخ الخطأ' FROM Exceptions;