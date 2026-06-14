SELECT * FROM SYS.SERVERS;


SELECT * FROM SYS.DATABASES WHERE NAME NOT IN ('Master','Model','MSDB','TempDB','ReportServer','ReportServerTempDB');