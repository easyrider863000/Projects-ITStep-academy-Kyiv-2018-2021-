use hr19p31
go
if object_id('tbl1','U') is not null
	drop table tbl1
go
create table tbl1(id int identity primary key, name nvarchar(100))
GO

if object_id('tbl1','TR') is not null
	drop trigger Trigger_tbl1_after
go
create TRIGGER Trigger_tbl1_after
    ON [dbo].[tbl1]
    --after insert
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
       SET NOCOUNT ON
	   declare @RecordInserted int = (select count(*) from inserted)
	   declare @RecordDeleted int = (select count(*) from deleted)
		print '@RecordInserted = '+cast(@RecordInserted as varchar(5))
		print '@RecordDeleted = '+cast(@RecordDeleted as varchar(5))
		select * from inserted
		select * from deleted
	END
	go
create TRIGGER Trigger_tbl1_insteadof
    ON [dbo].[tbl1]
    --after insert
    instead of DELETE, INSERT, UPDATE
    AS
    BEGIN
       SET NOCOUNT ON
	   declare @RecordInserted int = (select count(*) from inserted)
	   declare @RecordDeleted int = (select count(*) from deleted)
		print '@RecordInserted = '+cast(@RecordInserted as varchar(5))
		print '@RecordDeleted = '+cast(@RecordDeleted as varchar(5))
		select * from inserted
		select * from deleted
		if (@RecordDeleted=0)
		begin
			insert into tbl1(name)
			select name from inserted
		end
	END


insert into tbl1(name)
values ('Test1'),('Test2'),('Test3')

delete from tbl1
where id>3

update tbl1
set name = 'test'
where id in (1,3)

select *
from tbl1