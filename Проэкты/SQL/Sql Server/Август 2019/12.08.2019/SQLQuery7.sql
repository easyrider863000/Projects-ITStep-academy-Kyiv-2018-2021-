if OBJECT_ID('Number','U') is not null
	drop table Number;
create table Number(nomer int not null primary key);

insert into Number(nomer)
values(1),(2),(3),(4),(5),(6),(7),(8),(9),(10),(11);


select *
from dbo.Person cross join dbo.Number
where dbo.Number.nomer<=5
order by PersonId