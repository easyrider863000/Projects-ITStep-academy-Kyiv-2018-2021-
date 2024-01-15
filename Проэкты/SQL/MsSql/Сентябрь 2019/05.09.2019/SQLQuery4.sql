insert into tbl1(name)
values ('Test1'),('Test2'),('Test3')

delete from tbl1
where id>3

update tbl1
set name = 'test'
where id in (1,3)

select *
from tbl1