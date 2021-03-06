/****** Script for SelectTopNRows command from SSMS  ******/
SELECT d100.RevisionPair_Id
      ,d100.Matching.value('count(/Matches/Match)', 'int') as m100
      ,d325.Matching.value('count(/Matches/Match)', 'int') as m325
      ,d550.Matching.value('count(/Matches/Match)', 'int') as m550
      ,d775.Matching.value('count(/Matches/Match)', 'int') as m775
      ,d1000.Matching.value('count(/Matches/Match)', 'int') as m1000
      ,d1225.Matching.value('count(/Matches/Match)', 'int') as m1225
      ,d1450.Matching.value('count(/Matches/Match)', 'int') as m1450
      ,d1675.Matching.value('count(/Matches/Match)', 'int') as m1675
      ,d1900.Matching.value('count(/Matches/Match)', 'int') as m1900
  FROM (select Id, RevisionPair_Id, Matching from [dbo].Deltas where Approach = 10) as d1000
  inner join (select Id, RevisionPair_Id, Matching from [dbo].Deltas where Approach = 12) as d100 on d100.RevisionPair_Id = d1000.RevisionPair_Id 
  inner join (select Id, RevisionPair_Id, Matching from [dbo].Deltas where Approach = 13) as d325 on d325.RevisionPair_Id = d1000.RevisionPair_Id 
  inner join (select Id, RevisionPair_Id, Matching from [dbo].Deltas where Approach = 14) as d550 on d550.RevisionPair_Id = d1000.RevisionPair_Id 
  inner join (select Id, RevisionPair_Id, Matching from [dbo].Deltas where Approach = 15) as d775 on d775.RevisionPair_Id = d1000.RevisionPair_Id 
  inner join (select Id, RevisionPair_Id, Matching from [dbo].Deltas where Approach = 16) as d1225 on d1225.RevisionPair_Id = d1000.RevisionPair_Id 
  inner join (select Id, RevisionPair_Id, Matching from [dbo].Deltas where Approach = 17) as d1450 on d1450.RevisionPair_Id = d1000.RevisionPair_Id 
  inner join (select Id, RevisionPair_Id, Matching from [dbo].Deltas where Approach = 18) as d1675 on d1675.RevisionPair_Id = d1000.RevisionPair_Id 
  inner join (select Id, RevisionPair_Id, Matching from [dbo].Deltas where Approach = 19) as d1900 on d1900.RevisionPair_Id = d1000.RevisionPair_Id
  where 
  (d1000.Matching.value('count(/Matches/Match)', 'int') != d100.Matching.value('count(/Matches/Match)', 'int')) or
        (d1000.Matching.value('count(/Matches/Match)', 'int') != d325.Matching.value('count(/Matches/Match)', 'int')) or
		(d1000.Matching.value('count(/Matches/Match)', 'int') != d550.Matching.value('count(/Matches/Match)', 'int')) or
		(d1000.Matching.value('count(/Matches/Match)', 'int') != d775.Matching.value('count(/Matches/Match)', 'int')) or
		(d1000.Matching.value('count(/Matches/Match)', 'int') != d1225.Matching.value('count(/Matches/Match)', 'int')) or
		(d1000.Matching.value('count(/Matches/Match)', 'int') != d1450.Matching.value('count(/Matches/Match)', 'int')) or
		(d1000.Matching.value('count(/Matches/Match)', 'int') != d1675.Matching.value('count(/Matches/Match)', 'int')) or
		(d1000.Matching.value('count(/Matches/Match)', 'int') != d1900.Matching.value('count(/Matches/Match)', 'int'))
   --Matching.value('count(/Matches/Match)', 'int') )