declare @t1 table (tid int, tname nvarchar(80))
insert into @t1
select EmployeeId, FirstName+' '+LastName
from dbo.Employee

select *
from @t1 t left join dbo.Promotion p
	on t.empid=p.EmployeeId

--insert into @t1 values (10, 'Test1');
--insert into @t1 values (20, 'Test2');
--insert into @t1 values (30, 'Test3');
--insert into @t1 values (40, 'Test4');
--select tid, tname from @t1;
