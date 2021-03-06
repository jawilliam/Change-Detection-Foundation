/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
--distinct symp.Delta_Id
      s.[Pattern]
      ,s.[Original_Hint]
      ,s.[Modified_Hint]
      ,s.[Original_Element_Type]
      ,s.[Modified_Element_Type]
      ,s.[Original_Element_Id]
      ,s.[Modified_Element_Id]
      ,s.[Original_Element_Hint]
      ,s.[Modified_Element_Hint]
      --,s.[Original_AncestorOfReference_Type]
      --,s.[Modified_AncestorOfReference_Type]
      --,s.[Original_AncestorOfReference_Id]
      --,s.[Modified_AncestorOfReference_Id]
      ,s.[Original_AncestorOfReference_Hint]
      ,s.[Modified_AncestorOfReference_Hint]
      --,s.[Original_CommonAncestorOfReference_Type]
      --,s.[Modified_CommonAncestorOfReference_Type]
      --,s.[Original_CommonAncestorOfReference_Id]
      --,s.[Modified_CommonAncestorOfReference_Id]
      ,s.[Original_CommonAncestorOfReference_Hint]
      ,s.[Modified_CommonAncestorOfReference_Hint]
      ,s.[Original_ScopeHint]
      ,s.[Modified_ScopeHint]
      ,s.[Id]
	  ,symp.Delta_Id
  FROM [dbo].[Symptoms_MissedNameSymptom]  as s 
       inner join [dbo].Symptoms as symp on symp.Id = s.Id
  --where Original_Element_Type = 'function'
  --where [Original_CommonAncestorOfReference_Hint] like [Original_AncestorOfReference_Hint] + '%'
  --  and [Modified_CommonAncestorOfReference_Hint] like [Modified_AncestorOfReference_Hint] + '%'

  --where [Original_AncestorOfReference_Hint] = [Original_CommonAncestorOfReference_Hint]
  --  and  [Modified_AncestorOfReference_Hint] = [Modified_CommonAncestorOfReference_Hint]

  order by symp.Delta_Id