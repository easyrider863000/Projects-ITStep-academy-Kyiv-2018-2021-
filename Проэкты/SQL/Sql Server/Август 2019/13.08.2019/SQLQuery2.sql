select mgr.firstname, mgr.lastname, emp.firstname, emp.lastname
from HR.Employees mgr inner join hr.Employees emp
	on mgr.empid=emp.mgrid
order by mgr.empid

