/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
distinct RevisionPair_Id

      -- [Id]
      --,[Kind]
      --,[Severity]
      --,[Subject]
      --,[Comments]
      --,[Topics]
      --,[Annotations]
      --,[CaseKind]
      --,[RevisionPair_Id]
  FROM [dbo].[Reviews]
  where Kind = 4 and Severity = 3
  order by RevisionPair_Id