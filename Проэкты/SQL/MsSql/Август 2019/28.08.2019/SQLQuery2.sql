
if OBJECT_ID('dbo.uspInsertEmployeeAndMilitary','P') is not null
	drop procedure dbo.uspInsertEmployeeAndMilitary
go
create procedure dbo.uspInsertEmployeeAndMilitary
	@FirstName nvarchar(32),
	@LastName nvarchar(32),
	@Birthday date,
	@Inn char(12)=null,
	@MilitaryNumber nchar(9),
	@MilitarySpecial nvarchar(64)
as
begin
	insert into dbo.Employee(FirstName, LastName, Birthday, Inn)
	values(@FirstName, @LastName, @Birthday, @Inn)
	if @MilitaryNumber is not null
	begin
		declare @EmployeeId int = (select max(EmployeeId) from dbo.Employee)
		insert into dbo.EmployeeMilitary(EmployeeId,MilitaryNumber,MilitarySpecial)
		values(@EmployeeId, @MilitaryNumber, @MilitarySpecial)
	end
end







SELECT EmployeeId, FirstName, LastName, Birthday, Inn
FROM     Employee
SELECT EmployeeId, MilitaryNumber, MilitarySpecial
FROM     EmployeeMilitary