DECLARE @name VARCHAR(50) -- database name  
DECLARE @path VARCHAR(256) -- path for backup files  
DECLARE @fileName VARCHAR(256) -- filename for backup 
 
-- specify database backup directory
SET @path = 'F:\Backups\'
--SET @path = 'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLENT2014\MSSQL\Backup\'  
 
DECLARE db_cursor CURSOR READ_ONLY FOR  
SELECT name 
FROM master.dbo.sysdatabases 
WHERE name NOT IN ('master','model','msdb','tempdb', 'ReportServer$SQLENT2014', 'ReportServer$SQLENT2014TempDB', 'GitRepository')  -- exclude these databases
 
OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @name   
 
WHILE @@FETCH_STATUS = 0   
BEGIN   
   SET @fileName = @path + @name + '.BAK'  
   BACKUP DATABASE @name TO DISK = @fileName WITH FORMAT;
 
   FETCH NEXT FROM db_cursor INTO @name   
END   

 
CLOSE db_cursor   
DEALLOCATE db_cursor