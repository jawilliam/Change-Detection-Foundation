--/****** Script for SelectTopNRows command from SSMS  ******/
--SELECT bs.[Pattern]
--      ,bs.[Left_Parent4IDU_Original4U_Element_Type]
--      ,bs.[Left_Parent4IDU_Original4U_Element_Id]
--      ,bs.[Left_Parent4IDU_Original4U_Element_Hint]
--      ,bs.[Left_Parent4IDU_Original4U_ScopeHint]
--      ,bs.[Left_Element4IDM_Modified4U_Element_Type]
--      ,bs.[Left_Element4IDM_Modified4U_Element_Id]
--      ,bs.[Left_Element4IDM_Modified4U_Element_Hint]
--      ,bs.[Left_Element4IDM_Modified4U_ScopeHint]
--      ,bs.[Left_PartName]
--      ,bs.[Left_Operation]
--      ,bs.[Right_Parent4IDU_Original4U_Element_Type]
--      ,bs.[Right_Parent4IDU_Original4U_Element_Id]
--      ,bs.[Right_Parent4IDU_Original4U_Element_Hint]
--      ,bs.[Right_Parent4IDU_Original4U_ScopeHint]
--      ,bs.[Right_Element4IDM_Modified4U_Element_Type]
--      ,bs.[Right_Element4IDM_Modified4U_Element_Id]
--      ,bs.[Right_Element4IDM_Modified4U_Element_Hint]
--      ,bs.[Right_Element4IDM_Modified4U_ScopeHint]
--      ,bs.[Right_PartName]
--      ,bs.[Right_Operation]
--      ,bs.[DivergentLeft_Parent4IDU_Original4U_Element_Type]
--      ,bs.[DivergentLeft_Parent4IDU_Original4U_Element_Id]
--      ,bs.[DivergentLeft_Parent4IDU_Original4U_Element_Hint]
--      ,bs.[DivergentLeft_Parent4IDU_Original4U_ScopeHint]
--      ,bs.[DivergentLeft_Element4IDM_Modified4U_Element_Type]
--      ,bs.[DivergentLeft_Element4IDM_Modified4U_Element_Id]
--      ,bs.[DivergentLeft_Element4IDM_Modified4U_Element_Hint]
--      ,bs.[DivergentLeft_Element4IDM_Modified4U_ScopeHint]
--      ,bs.[DivergentLeft_PartName]
--      ,bs.[DivergentLeft_Operation]
--      ,bs.[DivergentRight_Parent4IDU_Original4U_Element_Type]
--      ,bs.[DivergentRight_Parent4IDU_Original4U_Element_Id]
--      ,bs.[DivergentRight_Parent4IDU_Original4U_Element_Hint]
--      ,bs.[DivergentRight_Parent4IDU_Original4U_ScopeHint]
--      ,bs.[DivergentRight_Element4IDM_Modified4U_Element_Type]
--      ,bs.[DivergentRight_Element4IDM_Modified4U_Element_Id]
--      ,bs.[DivergentRight_Element4IDM_Modified4U_Element_Hint]
--      ,bs.[DivergentRight_Element4IDM_Modified4U_ScopeHint]
--      ,bs.[DivergentRight_PartName]
--      ,bs.[DivergentRight_Operation]
--      ,bs.[Id]
--      ,bs.[Left_PartApproach]
--      ,bs.[Right_PartApproach]
--      ,bs.[DivergentLeft_PartApproach]
--      ,bs.[DivergentRight_PartApproach]
--  FROM [dbo].[Symptoms_BetweenSymptom] as bs inner join [dbo].Symptoms_BetweenSymptom as sbs on bs.Id = sbs.Id
--  where

select (SELECT count(distinct s.Delta_Id)
	    FROM [dbo].[Symptoms_BetweenSymptom] as sbs inner join [dbo].Symptoms as s on sbs.Id = s.Id
        WHERE (sbs.Left_PartApproach = 10 or sbs.Right_PartApproach = 10 or sbs.DivergentLeft_PartApproach = 10 or sbs.DivergentRight_PartApproach = 10) and
              (sbs.Left_PartApproach = 12 or sbs.Right_PartApproach = 12 or sbs.DivergentLeft_PartApproach = 12 or sbs.DivergentRight_PartApproach = 12)) as d100,
		(SELECT count(distinct s.Delta_Id)
        FROM [dbo].[Symptoms_BetweenSymptom] as sbs inner join [dbo].Symptoms as s on sbs.Id = s.Id
        WHERE (sbs.Left_PartApproach = 10 or sbs.Right_PartApproach = 10 or sbs.DivergentLeft_PartApproach = 10 or sbs.DivergentRight_PartApproach = 10) and
              (sbs.Left_PartApproach = 13 or sbs.Right_PartApproach = 13 or sbs.DivergentLeft_PartApproach = 13 or sbs.DivergentRight_PartApproach = 13)) as d325,
		(SELECT count(distinct s.Delta_Id)
        FROM [dbo].[Symptoms_BetweenSymptom] as sbs inner join [dbo].Symptoms as s on sbs.Id = s.Id
        WHERE (sbs.Left_PartApproach = 10 or sbs.Right_PartApproach = 10 or sbs.DivergentLeft_PartApproach = 10 or sbs.DivergentRight_PartApproach = 10) and
              (sbs.Left_PartApproach = 14 or sbs.Right_PartApproach = 14 or sbs.DivergentLeft_PartApproach = 14 or sbs.DivergentRight_PartApproach = 14)) as d550,
		(SELECT count(distinct s.Delta_Id)
        FROM [dbo].[Symptoms_BetweenSymptom] as sbs inner join [dbo].Symptoms as s on sbs.Id = s.Id
        WHERE (sbs.Left_PartApproach = 10 or sbs.Right_PartApproach = 10 or sbs.DivergentLeft_PartApproach = 10 or sbs.DivergentRight_PartApproach = 10) and
              (sbs.Left_PartApproach = 15 or sbs.Right_PartApproach = 15 or sbs.DivergentLeft_PartApproach = 15 or sbs.DivergentRight_PartApproach = 15)) as d775,
		(SELECT count(distinct s.Delta_Id)
        FROM [dbo].[Symptoms_BetweenSymptom] as sbs inner join [dbo].Symptoms as s on sbs.Id = s.Id
        WHERE (sbs.Left_PartApproach = 10 or sbs.Right_PartApproach = 10 or sbs.DivergentLeft_PartApproach = 10 or sbs.DivergentRight_PartApproach = 10) and
              (sbs.Left_PartApproach = 16 or sbs.Right_PartApproach = 16 or sbs.DivergentLeft_PartApproach = 16 or sbs.DivergentRight_PartApproach = 16)) as d1225,
		(SELECT count(distinct s.Delta_Id)
        FROM [dbo].[Symptoms_BetweenSymptom] as sbs inner join [dbo].Symptoms as s on sbs.Id = s.Id
        WHERE (sbs.Left_PartApproach = 10 or sbs.Right_PartApproach = 10 or sbs.DivergentLeft_PartApproach = 10 or sbs.DivergentRight_PartApproach = 10) and
              (sbs.Left_PartApproach = 17 or sbs.Right_PartApproach = 17 or sbs.DivergentLeft_PartApproach = 17 or sbs.DivergentRight_PartApproach = 17)) as d1450,
		(SELECT count(distinct s.Delta_Id)
        FROM [dbo].[Symptoms_BetweenSymptom] as sbs inner join [dbo].Symptoms as s on sbs.Id = s.Id
        WHERE (sbs.Left_PartApproach = 10 or sbs.Right_PartApproach = 10 or sbs.DivergentLeft_PartApproach = 10 or sbs.DivergentRight_PartApproach = 10) and
              (sbs.Left_PartApproach = 18 or sbs.Right_PartApproach = 18 or sbs.DivergentLeft_PartApproach = 18 or sbs.DivergentRight_PartApproach = 18)) as d1675,
		(SELECT count(distinct s.Delta_Id)
        FROM [dbo].[Symptoms_BetweenSymptom] as sbs inner join [dbo].Symptoms as s on sbs.Id = s.Id
        WHERE (sbs.Left_PartApproach = 10 or sbs.Right_PartApproach = 10 or sbs.DivergentLeft_PartApproach = 10 or sbs.DivergentRight_PartApproach = 10) and
              (sbs.Left_PartApproach = 19 or sbs.Right_PartApproach = 19 or sbs.DivergentLeft_PartApproach = 19 or sbs.DivergentRight_PartApproach = 19)) as d1900

--SELECT sum(case when (sbs.Left_PartApproach = 12 or sbs.Right_PartApproach = 12 or sbs.DivergentLeft_PartApproach = 12 or sbs.DivergentRight_PartApproach = 12) then 1 else 0 end) as d100
--      ,sum(case when (sbs.Left_PartApproach = 13 or sbs.Right_PartApproach = 13 or sbs.DivergentLeft_PartApproach = 13 or sbs.DivergentRight_PartApproach = 13) then 1 else 0 end) as d325
--      ,sum(case when (sbs.Left_PartApproach = 14 or sbs.Right_PartApproach = 14 or sbs.DivergentLeft_PartApproach = 14 or sbs.DivergentRight_PartApproach = 14) then 1 else 0 end) as d550
--      ,sum(case when (sbs.Left_PartApproach = 15 or sbs.Right_PartApproach = 15 or sbs.DivergentLeft_PartApproach = 15 or sbs.DivergentRight_PartApproach = 15) then 1 else 0 end) as d775
--      ,sum(case when (sbs.Left_PartApproach = 16 or sbs.Right_PartApproach = 16 or sbs.DivergentLeft_PartApproach = 16 or sbs.DivergentRight_PartApproach = 16) then 1 else 0 end) as d1225
--      ,sum(case when (sbs.Left_PartApproach = 17 or sbs.Right_PartApproach = 17 or sbs.DivergentLeft_PartApproach = 17 or sbs.DivergentRight_PartApproach = 17) then 1 else 0 end) as d1450
--      ,sum(case when (sbs.Left_PartApproach = 18 or sbs.Right_PartApproach = 18 or sbs.DivergentLeft_PartApproach = 18 or sbs.DivergentRight_PartApproach = 18) then 1 else 0 end) as d675
--      ,sum(case when (sbs.Left_PartApproach = 19 or sbs.Right_PartApproach = 19 or sbs.DivergentLeft_PartApproach = 19 or sbs.DivergentRight_PartApproach = 19) then 1 else 0 end) as d1900
--  FROM [dbo].[Symptoms_BetweenSymptom] as sbs inner join [dbo].Symptoms as s on sbs.Id = s.Id
--  where sbs.Left_PartApproach = 10 or sbs.Right_PartApproach = 10 or sbs.DivergentLeft_PartApproach = 10 or sbs.DivergentRight_PartApproach = 10
   --Matching.value('count(/Matches/Match)', 'int') )