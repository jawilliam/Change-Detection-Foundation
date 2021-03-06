/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [Id]
      ,[Matching]
      ,[Differencing]
      ,[Report]
      ,[Annotations]
      ,[Approach]
      ,[OriginalTree]
      ,[ModifiedTree]
      ,[RevisionPair_Id]
	  ,[Subcorpus]
  FROM [dbo].[Deltas]
 --where RevisionPair_Id is null
 where Approach = 3  and (Subcorpus & 1024 = 1024)
 order by RevisionPair_Id

--DECLARE @name VARCHAR(50) -- database name  
--DECLARE @path VARCHAR(256) -- path for backup files  
--DECLARE @fileName VARCHAR(256) -- filename for backup  
--DECLARE @SQL   VARCHAR(2000)
 
--DECLARE db_cursor CURSOR READ_ONLY FOR  
--SELECT name 
--FROM master.dbo.sysdatabases 
--WHERE name NOT IN ('master','model','msdb','tempdb', 'ReportServer$SQLENT2014', 'ReportServer$SQLENT2014TempDB', 'GitRepository')  -- exclude these databases
 
--OPEN db_cursor   
--FETCH NEXT FROM db_cursor INTO @name   
 
--WHILE @@FETCH_STATUS = 0   
--BEGIN   
--   SET @SQL = 'SELECT ''' + @name +                     
--					 ''' as Project, [Id]
--					 ,[Matching]
--					 ,[Differencing]
--					 ,[Report]
--					 ,[Annotations]
--					 ,[Approach]
--					 ,[OriginalTree]
--					 ,[ModifiedTree]
--					 ,[RevisionPair_Id]
--					 ,[Subcorpus]
--			  FROM ' + @name + '.[dbo].[Deltas]
--			  --where RevisionPair_Id is null
--			  where Approach = 3  and (Subcorpus & 1 = 1)
--			  order by RevisionPair_Id' 

--	EXEC(@SQL)
 
--   FETCH NEXT FROM db_cursor INTO @name   
--END   

--CLOSE db_cursor   
--DEALLOCATE db_cursor