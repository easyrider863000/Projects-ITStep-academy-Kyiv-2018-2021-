drop table dbo.Countries
go
drop table dbo.Disks
go
drop table dbo.Publishers
go
drop table dbo.Songers
go
drop table dbo.Songs
go
drop table dbo.Styles
go



create table Songs
(
	SongId int not null primary key,
	DiskId int not null,
	SongName nvarchar(100), 
	SongLength float,
)
INSERT Songs VALUES
(1,1, 'The ringer',5.38) 
,(2,1, 'Greatest',3.47) 
,(3,1, 'Lucky You',4.05) 
,(4,2, 'Live Wire',6.37) 
,(5,2, 'Problem Child',4.27) 
,(6,2, 'Sin City',5.21) 
,(7,2, '305 Anthem',4.14) 
,(8,2, 'Culo',3.39) 
,(9,2, 'She`s Freakly',3.20) 
 
GO
--create database Music
--go

create table Songers
(
	SongerId int not null primary key
	,Sname nvarchar(30)
)
GO
INSERT Songers VALUES
(1, 'Eminem') 
,(2, 'ACDC') 
,(3, 'Pitbull') 
GO

create table Countries
(
	CountryId int not null primary key,
	Cname nvarchar(30)
)
go

insert Countries values
(1, 'USA') 
,(2, 'Australia')  
GO


create table Publishers
(
	PublisherId int not null primary key
	,Pname nvarchar(100)
	,CountryId int
)
GO
INSERT Publishers VALUES
(1, 'Interscope Records', 1) 
,(2, 'Firefly',2) 
,(3, 'TVT Records',1) 
GO


create table Styles
(
	StyleId int not null primary key,
	SName nvarchar(30)
)
INSERT Styles VALUES
(1, 'Pop') 
,(2, 'Rock') 
,(3, 'Rap') 
GO


create table Disks
(
	DiskId int not null primary key,
	DiskName nvarchar(150),
	SongerId int not null,
	DateOfIssue date,
	StyleId int not null,
	PublisherId int not null
)
INSERT Disks VALUES
(1, 'Eminem - Kamikaze',1,'20180831',3,1) 
,(2, 'AC/DC - Kicked in the teeth',2,'20190427',2,2) 
,(3, 'MySolo',3,'20040824',1,3) 
 
GO








select *
from dbo.Publishers
select *
from dbo.Songers






