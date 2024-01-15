use db_index
go
if OBJECT_ID('dbo.Customers', 'U') is not null
  drop table dbo.Customers
go
create table dbo.Customers
(
	CustomerId int not null identity(1,1), -- primary key,
	FirstName  varchar(64) not null,
	LastName varchar(128) not null,
	Phone varchar(32) null,
	Placeholder char(200) not null
		constraint PK_Customers_Placeholder
		default 'This is the placeholder'
)
go

create unique clustered index IDX_Customers_CustomerId
on dbo.Customers(CustomerId)
go


;with FirstNames(FirstName)
as
(
	select Names.Name
	from 
	(
		values('Andrew'),('Andy'),('Anton'),('Ashley'),('Boris'),
		('Brian'),('Cristopher'),('Cathy'),('Daniel'),('Donny'),
		('Edward'),('Eddy'),('Emy'),('Frank'),('George'),('Harry'),
		('Henry'),('Ida'),('John'),('Jimmy'),('Jenny'),('Jack'),
		('Kathy'),('Kim'),('Larry'),('Mary'),('Max'),('Nancy'),
		('Olivia'),('Olga'),('Peter'),('Patrick'),('Robert'),
		('Ron'),('Steve'),('Shawn'),('Tom'),('Timothy'),
		('Uri'),('Vincent')
	) Names(Name)
)
,LastNames(LastName)
as
(
	select Names.Name
	from 
	(
		values('Smith'),('Johnson'),('Williams'),('Jones'),('Brown'),
			('Davis'),('Miller'),('Wilson'),('Moore'),('Taylor'),
			('Anderson'),('Jackson'),('White'),('Harris')
	) Names(Name)
)
insert into dbo.Customers(LastName, FirstName)
	select LastName, FirstName
	from FirstNames cross join LastNames 		
go 50 --кол-во повторений пакета!!!!!!!

insert into dbo.Customers(LastName, FirstName)
values('Korotkevitch','Dmitri')
go	

select *
from dbo.Customers
where FirstName = 'Brian'
go

create nonclustered index IDX_Customers_LastName_FirstName
on dbo.Customers(LastName, FirstName)
go

drop index IDX_Customers_LastName_FirstName on dbo.Customers

create nonclustered index IDX_Customers_LastName_FirstName
on dbo.Customers(FirstName, LastName)
go

select *
from dbo.Customers
where LastName = N'Wilson'
go


set statistics io on
set statistics time on
select *
from dbo.Customers
where FirstName = N'Brian'
set statistics time off
set statistics io off
go
