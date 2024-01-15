if object_id('dbo.fnGetSalaryEmployees','TF')
	drop dbo.fnGetSalaryEmployees
create function dbo.fnGetSalaryEmployees
(
	@eventdate date
)
returns @t table(EmployeeId int, Salary money)
as
begin
	insert into @t(EmployeeId, Salary)
	select EmployeeId, dbo.fnGetSalaryScalar(EmployeeId,'15.08.2015')
	from dbo.Employee
	return
end
go