--1.	������� ������ �������������� �������

--select *
--from dbo.Manufacturer

--2.	������� ������ ������� � ������������, ����, ���������� � ������������ �������������(����� ���� ��������).

--select p.ProductName, p.Price, p.ProductCount, m.ManufacturerName
--from dbo.Product p left join dbo.Manufacturer m
--	on p.ManufacturerId=m.ManufacturerId

--3.	������� ������ ������� � ������������, ����, ���������� � ������������ ���������(����� ���� ��������).

--select p.ProductName, p.Price, p.ProductCount, c.CategoryName
--from dbo.Product p left join dbo.Category c
--	on p.CategoryId=c.CategoryId

--4.	������� ������ �������, � ������� �� ����� �������������

--select *
--from dbo.Product p
--where p.ManufacturerId is null

--5.	������� ������ �������, � ������� �� ������ ���������

--select *
--from dbo.Product p
--where p.CategoryId is null

--6.	������� ������ �������������� ������� � ������������ ��������� �������, ������� ��� ����������

--select distinct m.ManufacturerName, c.CategoryName
--from dbo.Product p inner join dbo.Manufacturer m
--	on p.ManufacturerId=m.ManufacturerId 
--	inner join dbo.Category c
--	on c.CategoryId=p.CategoryId

--7.	������� ������ �������������� ������� ������� ���������� ��� � �����  �������

--select m.ManufacturerName, c.CountOfProduct
--from dbo.Manufacturer m inner join (select p.ManufacturerId, count(p.ManufacturerId) CountOfProduct
--									from dbo.Product p
--									group by p.ManufacturerId) c
--	on m.ManufacturerId=c.ManufacturerId
--where c.CountOfProduct>=2

--8.	������� ��������� �������, ������� �� ������������ �� ����� ��������������.

--select distinct c.CategoryName
--from dbo.Product p inner join dbo.Manufacturer m
--	on p.ManufacturerId=m.ManufacturerId 
--	right join dbo.Category c
--	on c.CategoryId=p.CategoryId
--where m.ManufacturerName is null

--9.	������� ������ �������������� �������, ������� ���������� ������ ��������

--(select m.*
--from dbo.Product p inner join dbo.Manufacturer m
--	on p.ManufacturerId=m.ManufacturerId 
--	inner join dbo.Category c
--	on c.CategoryId=p.CategoryId
--where c.CategoryName='Notebook'

--except

--select m.*
--from dbo.Product p inner join dbo.Manufacturer m
--	on p.ManufacturerId=m.ManufacturerId 
--	inner join dbo.Category c
--	on c.CategoryId=p.CategoryId
--where c.CategoryName<>'Notebook')

--10.	�������� ������ ��� ���������� ���� �������. ���������� ����� �������������, ��� �� ����� ���� �����. ������� ��� ���� - ��� �������������  ���� � ���� �� ����� (��� nvarchar(256)). �������� ��������� ������� � �������.

--if object_id('Photo','U') is not null
--	drop table Photo
--create table Photo
--(
--	PhotoId int not null primary key identity,
--	ProductId int not null,
--	PhotoPath nvarchar(256)
--	Foreign key (ProductId) references Product(ProductId)
--)
--insert into Photo(ProductId,PhotoPath)
--values
--(1,'C:\Photo1')
--,(2,'C:\Photo2')
--,(3,'C:\Photo3')
--,(2,'C:\Photo4')
--,(5,'C:\Photo5')

--11.	�������� ������, ������� ��������� ������� - ������ ������(� ������� Product). 

--alter table dbo.Product add discount float check(discount>=0 and discount<=100)
--update dbo.Product
--set discount=0

--12.	���������� �������, ������� ���������� ����� � ����������� ����� �� ��������� - ���������(�������� ���������)

--if OBJECT_ID('GetMinPriceForCategory','IF') is not null
--	drop function GetMinPriceForCategory
--go
--create function GetMinPriceForCategory
--(
--	@CategoryId int
--)
--returns table
--as
--return
--(select * 
--		from dbo.Product p
--		where p.CategoryId=@CategoryId and p.Price=(select min(p2.Price)
--													from dbo.Product p2
--													where p2.CategoryId=@CategoryId) )
--go

--13.	���������� ��������  ���������, ������� ��������� � ������� ���� ������.

--if object_id('DelPhoto','P') is not null
--	drop procedure DelPhoto
--go
--create procedure DelPhoto
--	@PhotoId int
--as
--begin
--	delete from dbo.Photo
--	where PhotoId=@PhotoId
--end
--go

--if object_id('AddPhoto','P') is not null
--	drop procedure AddPhoto
--go
--create procedure AddPhoto
--	@ProductId int,
--	@PhotoPath nvarchar(256)
--as
--begin
--	INSERT INTO Photo(ProductId,PhotoPath) 
--	VALUES (@ProductId,@PhotoPath);
--end
--go

--14.	�������� ������, ������� ������� ��� ������ ��������� - �������� �� �����***

--if OBJECT_ID('DelAllProductOfCategory','P') is not null
--	drop procedure DelAllProductOfCategory
--go
--create procedure DelAllProductOfCategory
--	@CategoryName nvarchar(100)
--as
--begin
--	delete from dbo.Product
--	where CategoryId=(select c.CategoryId
--						from dbo.Category c
--						where c.CategoryName=@CategoryName)
--end
--go


