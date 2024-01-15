if OBJECT_ID('Sotr') is null
	USE master
	GO
	CREATE DATABASE Sotr
	GO

USE Sotr
GO

drop table Department
go
drop table Employees
go
drop table Project
go
drop table Task
go
drop table SotrOtd
go

--CREATE TABLE SotrData(
--	NoSotr int
--	,Surname nvarchar(100)
--	,NoOtd int
--	,NumberPh varchar(15)
--	,NoProj int
--	,Project nvarchar(100)
--	,NoTask int)
--GO
--INSERT SotrData VALUES
--(1, 'Иванов', 1, '11-22-33', 1, 'Космос',1)
--,(1, 'Иванов', 1, '11-22-33', 2, 'Климат',1)
--,(2, 'Петров', 1, '11-22-33', 1, 'Космос',2)
--,(3, 'Сидоров', 2, '33-22-11', 1, 'Космос',3)
--,(3, 'Сидоров', 2, '33-22-11', 2, 'Климат',2)
--GO
--SELECT * FROM SotrData 
--GO





CREATE TABLE Employees(
	NoSotr int not null primary key
	,Surname varchar(100))
GO
INSERT Employees VALUES
(1, 'Иванов')
,(2, 'Петров')
,(3, 'Сидоров')
GO


CREATE TABLE Department(
	NoOtd int not null primary key
	,NumberPh varchar(15)
	)
GO
INSERT Department VALUES
(1, '11-22-33')
,(2, '33-22-11')
GO


CREATE TABLE Project(
	NoProj int not null primary key identity
	,ProjName varchar(15)
	)
GO
INSERT Project VALUES
(1, 'Космос')
,(2, 'Климат')
GO


CREATE TABLE Task(
	NoTask int not null
	,NoProj int not null
	,NoSotr int
	)
GO
INSERT Task VALUES
(1, 1 ,1)
,(1,2,1)
,(2,1,2)
,(3,1,3)
,(2,2,3)
GO


CREATE TABLE SotrOtd(
	NoSotr int not null
	,NoOtd int not null
	)
GO
INSERT SotrOtd VALUES
(1, 1)
,(2,1)
,(3,2)
GO


select *
from Employees
select *
from Department
select *
from Project
select *
from Task
select *
from SotrOtd
