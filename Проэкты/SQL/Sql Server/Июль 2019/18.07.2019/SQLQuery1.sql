use [19p31]

----select DB_ID('19p31norm')
--if DB_ID('19p31norm') is not null
--	drop database [19p31norm]
--create database [19p31norm]
--go 
--use [19p31norm]
--go

if OBJECT_ID('Theme','U') is not null
	drop table Theme
create table Theme
(
	ThemeId int not null identity(1,1) primary key,
	ThemeName nvarchar(64) not null
)


--insert into Theme(ThemeName)
--values('Test1')
--insert into Theme(ThemeName)
--values('Test2')
--insert into Theme(ThemeName)
--values('Test3')
--insert into Theme(ThemeName)
--values('Test4')
--insert into Theme(ThemeName)
--values('Test5')
--insert into Theme(ThemeName)
--values('Test6')
--insert into Theme(ThemeName)
--values('Test7')
--insert into Theme(ThemeName)
--values('Test8')
--insert into Theme(ThemeName)
--values('Test9')
--insert into Theme(ThemeName)
--values('Test10')
--insert into Theme(ThemeName)
--values('Test11')


--insert into Theme(ThemeName)
--values ('Test1'),('Test2'),('Test3'),('Test4'),('Test5')


insert into Theme(ThemeName)
select distinct Themes
from dbo.books

if OBJECT_ID('Category','U') is not null
	drop table Category
create table Category
(
	CategoryId int not null identity(1,1) primary key,
	CategoryName nvarchar(64) not null
)
insert into Category(CategoryName)
select distinct Category
from dbo.books
where Category is not null

if OBJECT_ID('Format','U') is not null
	drop table [Format]
create table [Format]
(
	FormatId int not null identity primary key,
	FormatName nvarchar(24)
)
go
select distinct REPLACE(Format, '/','\')
from dbo.books b
where (Format is not null and b.Format <>'') and Len(Format) >1
