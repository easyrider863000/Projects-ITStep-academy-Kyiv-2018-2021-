if object_id('AddEmployee','P') is not null
	drop procedure AddEmployee
go
create procedure AddEmployee
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DateBirthday date,
	@INN int,
	@MilitaryNumber nvarchar(50),
	@MilitarySpecial nvarchar(50)
as
begin
	begin tran
	begin try
		insert into dbo.Employee (FirstName, LastName, Birthday, INN)
		values
		(@FirstName, @LastName, @DateBirthday, @INN)
		declare @EmployeeId int = scope_identity()
		insert into dbo.EmployeeMilitary (EmployeeId,MilitaryNumber,MilitarySpecial)
		values (@EmployeeId, @MilitaryNumber,@MilitarySpecial)
		commit
	end try
	begin catch
		rollback
	end catch
end
go

--select *
--from dbo.Employee e inner join dbo.EmployeeMilitary em
--	on e.EmployeeId=em.EmployeeId

--exec AddEmployee 'Vasya', 'Ivanov','20000120',123456789,'as-123456','Strelok'

--select *
--from dbo.Employee e inner join dbo.EmployeeMilitary em
--	on e.EmployeeId=em.EmployeeId