use master 
go

if DB_ID('hr19p31') is not null
	drop database hr19p31
go

create database hr19p31
go

use hr19p31
go
if OBJECT_ID('Employee','U') is not null
	drop table Employee
go

create table Employee(
	id int,
	FirstName nvarchar(32),
	LastName nvarchar(32),
	BirthDay Date,
	Inn char(12),
	HireDate Date,
	Salary money,
	NameJobTitle nvarchar(32),
	Reservist bit,
	MilitaryNumber nchar(9),
	MilitarySpecial nvarchar(64)
)
go

set dateformat dmy

--1				2000	
insert into Employee values(1,'Igor','Krivonos','16.08.1972','112233445566','01.07.2000',2000,'engineer',1,'vc-212121','Saper')
insert into Employee values(1,'Igor','Krivonos','16.08.1972','112233445566','16.12.2007',3000,'programmer',1,'vc-212121','Saper')
insert into Employee values(1,'Igor','Krivonos','16.08.1972','112233445566','21.10.2009',7000,'senior programmer',1,'vc-212121','Saper')
insert into Employee values(1,'Igor','Krivonos','16.08.1972','112233445566','12.09.2013',6500,'director',1,'vc-212121','Saper')
insert into Employee values(2,'Ivan','Darda','22.04.1980','222233445566','21.10.2012',7500,'senior programmer',0,null,null)
insert into Employee values(3,'Petr','Sivoy','17.03.1989','332233445566','21.10.2010',3500,'programmer',1,'nv-234567','Operator')
insert into Employee values(3,'Petr','Sivoy','17.03.1989','332233445566','21.10.2010',3500,'programmer',1,'nv-234567','Operator')
insert into Employee values(4,'Dasha','Snejko','10.12.1995','442233445566','21.10.2012',3200,'engineer',0,null,null)
insert into Employee values(4,'Dasha','Snejko','10.12.1995','442233445566','01.10.2013',3700,'senior engineer',0,null,null)
go




select *
from dbo.Employee









create table EmployeeN(
	Employeeid int not null identity(1,1),
	FirstName nvarchar(32) not null,
	LastName nvarchar(32) not null,
	BirthDay Date not null,
	Inn char(12) null,
	primary key(Employeeid)
)
go

--set identity_insert dbo.EmployeeN on
insert into Employee(id,FirstName,LastName,Birthday,Inn)
select distinct e.id, e.FirstName,e.LastName,e.Birthday,e.Inn
from dbo.Employee e

set identity_insert dbo.EmployeeN off


select *
from dbo.EmployeeN
go


if OBJECT_ID('EmployeeMilitary','U') is not null
	drop table EmployeeMilitary

go
create table EmployeeMilitary(
	EmployeeId int not null primary key foreign key references dbo.EmployeeN(Employeeid)
	,MilitaryNumber nchar(9) not null
	,MilitarySpecial nvarchar(64) not null
)

select distinct e.id,e.MilitaryNumber,e.MilitarySpecial
from dbo.Employee e




if OBJECT_ID('JobTitle','U') is not null
	drop table JobTitle
go
create table JobTitle(
	JobTitleId int identity primary key,
	NameJobTitle nvarchar(32) not null,
)
insert into JobTitle(NameJobTitle)
select distinct e.NameJobTitle
from dbo.Employee e

select *
from JobTitle



if OBJECT_ID('Promotion','U') is not null
	drop table Promotion
go

create table Promotion(
	PromotionId int identity primary key,
	EmployeeId int not null foreign key references dbo.EmployeeN(Employeeid),
	HireDate DAtetime not null default(GetDate()),
	Salary money not null default(0) check(Salary>=0 and Salary<100000),
	JobTitleId int not null foreign key references dbo.JobTitle(JobTitleId)
)

select e.id,e.HireDate,e.Salary,j.JobTitleId
from dbo.Employee e inner join dbo.JobTitle j
	on e.NameJobTitle=j.NameJobTitle