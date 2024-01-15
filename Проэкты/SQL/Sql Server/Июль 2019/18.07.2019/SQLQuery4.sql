go
use [19p31]
go
--select distinct themes
--from dbo.books

--if DB_ID('MyThemes') is not null
--	drop database [MyThemes]
--create database [MyThemes]
--go 
--use [My]
--go

if OBJECT_ID('Theme','U') is not null
	drop table Theme
create table Theme
(
	ThemeId int not null identity(1,1) primary key,
	ThemeName nvarchar(64) not null
)
go