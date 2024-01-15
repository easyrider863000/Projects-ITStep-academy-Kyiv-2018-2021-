--use master
--go

--if DB_ID('19p31norm') is not null
--	drop database [19p31norm]
--create database [19p31norm]
--go

use [19p31norm]
go

if OBJECT_ID('Position','U') is not null
	drop table Position
create table Position
(
	PositionId int not null identity primary key,
	PositionName nvarchar(64) not null
)
go
insert into Position(PositionName)
values ('Інженер'),('Програміст'),('Адміністратор')



if OBJECT_ID('Department','U') is not null
	drop table Department
create table Department
(
	DepartmentId int not null identity primary key,
	DepartmentName nvarchar(64) not null
)
insert into Department(DepartmentName)
values ('115'),('126'),('127')


if OBJECT_ID('DepartmentPhone','U') is not null
	drop table DepartmentPhone
create table DepartmentPhone
(
	DepartmentPhoneId int not null identity primary key,
	DepartmentId int not null,
	NumberPhone char(8)
)
go

if OBJECT_ID('Employee','U') is not null
	drop table Employee
create table Employee
(
	EmployeeId int not null identity primary key,
	DepartmentId int not null,
	FirstName nvarchar(32) not null,
	LastName nvarchar(32) not null
)
go

if OBJECT_ID('EmployeePosition','U') is not null
	drop table EmployeePosition
create table EmployeePosition
(
	EmployeeId int not null,
	PositionId int not null,
	Salary money not null default(0),
	primary key(EmployeeId, PositionId)
)
go