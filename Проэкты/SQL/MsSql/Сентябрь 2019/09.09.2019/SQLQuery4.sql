create table dbo.Books
(
	BookId int identity(1,1) not null,
	Title nvarchar(256) not null,
	-- International Standard Book Number
	ISBN char(14) not null, 
	Placeholder char(100) null
)
go

create unique clustered index IDX_Books_BookId
on dbo.Books(BookId)
go

-- 1,252,000 rows
;with Prefix(Prefix)
as
(
	select 100 
	union all
	select Prefix + 1
	from Prefix
	where Prefix < 600
)
,Postfix(Postfix)
as
(
	select 100000001
	union all
	select Postfix + 1
	from Postfix
	where Postfix < 100002500
)
insert into dbo.Books(ISBN, Title)
	select 
		CONVERT(char(3), Prefix) + '-0' + CONVERT(char(9),Postfix)
		,'Title for ISBN' + CONVERT(char(3), Prefix) + '-0' + CONVERT(char(9),Postfix)
	from Prefix cross join Postfix
option (maxrecursion 0);

create nonclustered index IDX_Books_ISBN on dbo.Books(ISBN);
go

-- How data looks like
select top 10 * from dbo.Books order by BookId
select top 10 * from dbo.Books order by ISBN
go


set statistics io on	
select * from dbo.Books where ISBN like '21[0-4]%' -- 12,500
select * from dbo.Books with (index = IDX_BOOKS_ISBN) where ISBN like '21[0-4]%' 
set statistics io off
go


select *
from dbo.Books
where BookId=12507
