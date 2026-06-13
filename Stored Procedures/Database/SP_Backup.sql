CREATE PROC SP_Backup --Create Proc StoredprocedureName

/* Storedprocedure Parameters 
	@filePath Nvarchar(150)
	@dbName Nvarchar(150)
 */
@filePath NVarchar(150),
@dbName Nvarchar(150)

--AS
AS

/* Backup SQL STATEMENT ==> BACKUP DATABASE @DatabaseName To DISK = @FilePath;*/
BACKUP DATABASE @dbName To DISK = @filePath;