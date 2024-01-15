create view dbo.viewEmployeeFullInfo
as
select e.FirstName+' '+e.LastName FullName, e.BirthDay, p.HireDate,
	j.NameJobTitle,p.Salary,em.MilitaryNumber,em.MilitarySpecial
from dbo.Employee e left join dbo.EmployeeMilitary em
	on e.EmployeeId=em.EmployeeId left join dbo.Promotion p
	on e.EmployeeId=p.EmployeeId left join dbo.JobTitle j
	on p.JobTitleId=j.JobTitleId

SELECT FullName, BirthDay, HireDate, NameJobTitle, Salary, MilitaryNumber, MilitarySpecial
FROM     viewEmployeeFullInfo

drop view dbo.viewEmployeeFullInfo
