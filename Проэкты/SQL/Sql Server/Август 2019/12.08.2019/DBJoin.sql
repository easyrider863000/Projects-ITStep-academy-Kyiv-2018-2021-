use [19p31norm]

if OBJECT_ID('TableA','U') is not null
	drop table TableA

create table TableA
(
	id int not null primary key,
	name nvarchar(24)
)

insert into TableA(id,name)
values
(1,'Pirate'),(3,'Monkey'),(4,'Ninja'),
(5,'Test'),(7,'Vasja'),(10,null)



if OBJECT_ID('TableB','U') is not null
	drop table TableB

create table TableB
(
	id int not null,
	name nvarchar(24)
)

insert into TableB(id,name)
values
(1,'Masha'),(2,'VAsja'),(3,'Monkey'),(11,'Test')
