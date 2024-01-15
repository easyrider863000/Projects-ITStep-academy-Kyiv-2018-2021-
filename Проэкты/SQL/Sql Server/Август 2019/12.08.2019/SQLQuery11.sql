use[19p31norm]
set dateformat dmy

if OBJECT_ID('Children','U')is not null
	drop table Children;
if OBJECT_ID('Person','U')is not null
	drop table Person;

create table Person
(
	PersonId int not null primary key,
	FirstName nvarchar(32) not null,
	LastName nvarchar(32) not null,
	BirthDay Date not null
)
go
insert into Person(PersonId,FirstName,LastName,BirthDay)
Values(1,'Vasja','Ivanov','31.12.1995'),
(2,'Semen','Kuznitsov','31.12.1993')



create table Children
(
	ChildrenId int not null primary key,
	PersonId int not null references Person(PersonId),
	FirstName nvarchar(32) not null,
	LastName nvarchar(32) not null,
	BirthDay Date not null
)
go

insert into Children(ChildrenId,PersonId,FirstName,LastName,BirthDay)
Values(21,2,'dfd','dfdfdf','31.12.1995'),
(22,1,'f','dfd','31.12.1993')

