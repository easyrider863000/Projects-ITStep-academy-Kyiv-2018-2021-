if OBJECT_ID('Employee','U') is not null
	drop table Employee
go
if OBJECT_ID('Department','U') is not null
	drop table Department
go
create table Department
(
	id int primary key identity,
	Name nvarchar(200)
)
insert into Department(Name)
values
('ABC'),
('QWY')



create table Employee
(
	Id int primary key identity,
	DepartmentId int not null,
	Chief_Id int,
	Name nvarchar(200),
	Salary money,
	foreign key (DepartmentId) references Department(id),
	foreign key (Chief_Id) references Employee(Id)
)

insert into Employee(DepartmentId,Chief_Id,Name,Salary)
values
(1,2,'Vasya',2000),
(2,2,'Petya',3000),
(2,3,'Masha',2000),
(2,3,'Dasha',2000),
(1,3,'Vanya',4000),
(2,null,'Sasha',1000)