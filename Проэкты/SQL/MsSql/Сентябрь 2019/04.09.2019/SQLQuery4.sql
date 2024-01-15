select *
from Employee
begin transaction
	update Employee
	set FirstName = 'Igor'
	where EmployeeId=1
	begin transaction
		update Employee
		set LastName = 'Test'
		where EmployeeId=1
	commit
commit
select *
from Employee