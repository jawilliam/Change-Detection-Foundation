/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Id]
      ,[Annotations]
      ,[Versioning_Path]
      ,[Versioning_FromVersion]
      ,[Versioning_ToVersion]
      ,[Flags]
      ,[OneFile_CanHave_ManyRevisionPairs_FileRevisionPair_Id]
      ,[Principal_Id]
  FROM [AjaxControlToolkit].[dbo].[FileRevisionPairs]
  where Id = '3DFF9149-E090-41C1-B42D-2D882570DC2D'