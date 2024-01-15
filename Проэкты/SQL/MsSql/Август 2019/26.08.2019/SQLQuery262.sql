create view dbo.viewEmployee
as

select id, FirstName,LastName, BirthDay, Inn
from Employee
order by FirstName

select *
from dbo.viewEmployee


update dbo.viewEmployee
set
FirstName=FirstName+' Test',LastName=LastName+' Test'
where id=4




insert into Employee(FirstName, LastName, BirthDay, Inn)
values('Mahmud','Ivanov','1995.13.12','')