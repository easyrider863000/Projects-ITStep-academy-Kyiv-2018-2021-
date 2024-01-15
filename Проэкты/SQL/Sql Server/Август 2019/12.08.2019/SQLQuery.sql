select e.FirstName, e.LastName, d.DepartmentName, ep.Salary
from dbo.Employee e inner join dbo.EmployeePosition ep 
	on e.EmployeeId=ep.EmployeeId
	
	inner join dbo.Position p
	on ep.PositionId=p.PositionId
	
	inner join dbo.Department d
	on e.DepartmentId=d.DepartmentId