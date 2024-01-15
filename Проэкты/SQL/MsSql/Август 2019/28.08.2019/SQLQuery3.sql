Select @@IDENTITY
select IDENT_CURRENT('dbo.Employee')
select SCOPE_IDENTITY()

exec dbo.uspInsertEmployeeAndMilitary
	@FirstName='Test',
	@LastName='Test',
	@Birthday='30.08.1998'

delete from dbo.EmployeeMilitary
where EmployeeId>6

select *
from Employee