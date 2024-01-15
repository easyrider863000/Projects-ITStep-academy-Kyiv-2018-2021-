--1.	¬ывести список производителей товаров

--select *
--from dbo.Manufacturer

--2.	¬ывести список товаров Ц наименование, цена, количество и наименование производител€(может быть пропущен).

--select p.ProductName, p.Price, p.ProductCount, m.ManufacturerName
--from dbo.Product p left join dbo.Manufacturer m
--	on p.ManufacturerId=m.ManufacturerId

--3.	¬ывести список товаров Ц наименование, цена, количество и наименование категории(может быть пропущен).

--select p.ProductName, p.Price, p.ProductCount, c.CategoryName
--from dbo.Product p left join dbo.Category c
--	on p.CategoryId=c.CategoryId

--4.	¬ывести список товаров, у которых не задан производитель

--select *
--from dbo.Product p
--where p.ManufacturerId is null

--5.	¬ывести список товаров, у которых не задана категори€

--select *
--from dbo.Product p
--where p.CategoryId is null

--6.	¬ывести список производителей товаров и наименование категорий товаров, который они производ€т

--select distinct m.ManufacturerName, c.CategoryName
--from dbo.Product p inner join dbo.Manufacturer m
--	on p.ManufacturerId=m.ManufacturerId 
--	inner join dbo.Category c
--	on c.CategoryId=p.CategoryId

--7.	¬ывести список производителей товаров которые производ€т два и более  товаров

--select m.ManufacturerName, c.CountOfProduct
--from dbo.Manufacturer m inner join (select p.ManufacturerId, count(p.ManufacturerId) CountOfProduct
--									from dbo.Product p
--									group by p.ManufacturerId) c
--	on m.ManufacturerId=c.ManufacturerId
--where c.CountOfProduct>=2

--8.	¬ывести категории товаров, которые не представлены ни одним производителем.

--select distinct c.CategoryName
--from dbo.Product p inner join dbo.Manufacturer m
--	on p.ManufacturerId=m.ManufacturerId 
--	right join dbo.Category c
--	on c.CategoryId=p.CategoryId
--where m.ManufacturerName is null

--9.	¬ывести список производителей товаров, которые производ€т только ноутбуки

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

--10.	Ќаписать скрипт дл€ добавлени€ фото товаров. ‘отографи€ может отсутствовать, или их может быть много.  олонка дл€ фото - это относительный  путь к фото на диске (тип nvarchar(256)). ƒобавьте несколько записей в таблицу.

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

--11.	Ќаписать скрипт, который добавл€ет колонку - скидка товара(в таблице Product). 

--alter table dbo.Product add discount float check(discount>=0 and discount<=100)
--update dbo.Product
--set discount=0

--12.	–еализуйте функцию, котора€ возвращает товар с минимальной ценой по параметру - категори€(айдишник категории)

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

--13.	–еализуйте хранимые  процедуры, которые добавл€ет и удал€ет фото товара.

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

--14.	Ќапишите скрипт, который удал€ет все товары категории - заданной по имени***

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


