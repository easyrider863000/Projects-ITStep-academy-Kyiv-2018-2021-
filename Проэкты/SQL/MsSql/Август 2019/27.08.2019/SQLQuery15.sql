--declare @d date = '20100101'

create procedure GetSalary
@EmployeeId int, @HireDate date
as
select e.LastName, j.NameJobTitle, p.Salary, p.HireDate
from dbo.Promotion p right join dbo.Employee e
	on e.Employeeid=p.EmployeeId left join JobTitle j
	on j.JobTitleId=p.JobTitleId
where e.EmployeeId=1 and p.HireDate=
(select max(HireDate)
from dbo.Promotion
	where EmployeeId=1 and HireDate<=@HireDate)
	or p.HireDate is null



execute GetSalary 1 '20190827'
--'20100101'

