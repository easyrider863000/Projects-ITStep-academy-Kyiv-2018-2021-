declare @i int;
if object_id('dbo.procGetEmployee','P') is not null
	drop procedure dbo.procGetEmployee
go
create procedure dbo.procGetEmployee
	@EmployeeId int = null
as
	select EmployeeId
	, FirstName+' '+LastName FullName
	, Birthday
	from dbo.Employee
	where EmployeeId=@EmployeeId or @EmployeeId is null
go

execute dbo.procGetEmployee 2