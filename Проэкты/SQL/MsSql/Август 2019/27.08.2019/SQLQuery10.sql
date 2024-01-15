--declare @s1 nvarchar(100)
--declare @a int = 100
--declare @b int

---- 1 set
--set @s1 = 'Test set'
--set @b = 21


---- 2 select
--select @s1 = 'Test set'
--select @b = 21


--print isnull(@s1, 'Null')
--print isnull(@a, 'Null')
--print coalesce(@b, 0)

--declare @s1 nvarchar(1000)
--set @s1=''
--select @s1 = @s1 + e.firstname+' '+e.LastName+';'
--from dbo.Employee e
----where e.EmployeeId=1
--select @s1


--select sum(p.Salary)
--from dbo.Promotion p
--declare @salary money = 0
--select @salary=@salary+p.salary
--from dbo.Promotion p
--select @salary









