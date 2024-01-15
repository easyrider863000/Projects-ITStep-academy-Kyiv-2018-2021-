select e.NoSotr,e.Surname,d.NoOtd,d.NumberPh,p.NoProj,p.ProjName,t.NoTask
from dbo.Employees e inner join dbo.SotrOtd so
	on e.NoSotr=so.NoSotr inner join dbo.Department d
	on d.NoOtd=so.NoOtd inner join dbo.Task t
	on t.NoSotr=e.NoSotr inner join dbo.Project p
	on p.NoProj=t.NoProj