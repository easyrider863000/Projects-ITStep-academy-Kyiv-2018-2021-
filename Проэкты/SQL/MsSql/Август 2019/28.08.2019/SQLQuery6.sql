create procedure GetSalary
 @EmployeeId int, @HireDAte date, @Salary money output
as
begin
	set @salary = 0
	
	declare @d date=(select max(HireDate)
						from dbo.Promotion
						where EmployeeId=@EmployeeId and
						HireDate<=@HireDAte)

	if @d is null
		return
	select @Salary= p.Salary
	from dbo.Promotion p
	where EmployeeId=@EmployeeId and p.HireDate=@d
						
end