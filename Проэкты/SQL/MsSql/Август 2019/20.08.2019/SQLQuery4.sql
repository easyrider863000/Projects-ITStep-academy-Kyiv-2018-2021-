

drop table Employee
go
drop table Department
go
drop table Project
go
drop table Task
go
drop table ProjectTask
go
drop table DepartmentProject
go



create table Employee(
	NoEmployee int not null primary key,
	Surname nvarchar(32),
	NoDepartment int not null
)
GO
INSERT Employee VALUES
(1, 'Иванов',1)
,(2, 'Петров',1)
,(3, 'Сидоров',2)
GO


CREATE TABLE Department(
	NoDepartment int not null primary key
	,NumberPhone varchar(15)
	)
GO
INSERT Department VALUES
(1, '11-22-33')
,(2, '33-22-11')
GO


CREATE TABLE DepartmentProject(
	NoDepartment int not null
	,NoProject int not null
	)
GO
INSERT DepartmentProject VALUES
 (1,1)
,(1,2)
,(2,1)
,(2,2)
GO


CREATE TABLE Project(
	NoProject int not null primary key
	,PName varchar(15)
	)
GO
INSERT Project VALUES
(1, 'Космос')
,(2, 'Климат')
GO


CREATE TABLE ProjectTask(
	NoProject int not null
	,NoTask int not null
	)
GO
INSERT ProjectTask VALUES
(1, 1)
,(2,1)
,(1,2)
,(1,3)
,(2,2)
GO


CREATE TABLE Task(
	NoTask int not null primary key
	,TName nvarchar(50)
	)
GO
INSERT Task VALUES
(1, null)
,(2,null)
,(3,null)
GO