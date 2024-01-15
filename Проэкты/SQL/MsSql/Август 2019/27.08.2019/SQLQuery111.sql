--DECLARE @i int = 0;
--WHILE (@i<10)
--BEGIN
--  PRINT 'Test ' + CAST (@i as VARCHAR(10));
--  SET @i+=1;
--END


--if Object_id('contragent','U') is not null
--	drop table contragent
--create table contragent
--(
--	ContragentId int not null
--	,ContragentName nvarchar(64) not null
--)
--go


--declare @i int = 1, @tmp int;
--while ( @i<=10000)
--begin
--	set @tmp = ABS(CHECKSUM(NEWID()) % 1000)
--	insert into contragent
--	values(@tmp, 'Contragent' + cast(@tmp as varchar(5)))
--	set @i+=1
--end

--select *
--from contragent


select contragentid, contragentname
into Temp
from contragent

create table tmp
insert into tmp(contragentid, contragentname)
select distinct c.contragentid, c.contragentname
from contragent c