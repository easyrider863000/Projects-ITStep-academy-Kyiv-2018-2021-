--1. Реализовать скалярную функцию, которая 
--определяет стоимость заказа. БД TSql2012

--if object_id('dbo.GetSumByProduct','FN') is not null
--	drop function dbo.GetSumByProduct
--go
--create function dbo.GetSumByProduct
--(
--	@orderid int
--)
--returns money
--as
--begin
--	declare @sum money;
--    set @sum = (select sum(unitprice * qty * (1-discount) )
--    from Sales.OrderDetails d
--    where d.orderid = @orderid)
--    return @sum
--end
--go
--select (dbo.GetSumByProduct(10607))


--2. Реализовать функцию и хранимую процедуру, которые возвращает
--айди заказа, наименование заказчика, сумму заказа за определенный период.

--if object_id('dbo.GetSumForDate','IF') is not null
--	drop function dbo.GetSumForDate
--go
--create function dbo.GetSumForDate
--(
--	@orderdateF date,
--	@orderdateL date
--)
--returns table
--as
--return
--	select o.orderid, c.contactname, dbo.GetSumByProduct(o.orderid) SumForOrder
--	from Sales.Orders o inner join Sales.Customers c
--		on c.custid=o.custid
--	where o.orderdate>=@orderdateF and o.orderdate<=@orderdateL
--go

--select *
--from dbo.GetSumForDate('20060305','20060708')


--3. В  базе данных Shop реализовать функцию – которая
--возвращает товары заданного по ManufacturerId таблицу
--– ИД товара, наименование товара, наименование
--производителя, наименование категории, цену товара
--и значение 1 если есть остаток товара и 0 в
--противном случае. Если производитель не задан - вывести
--'Unknow'. Если категория не задана - вывести 'Unknow'


--if object_id('dbo.GetProductsOfManufacturer','IF') is not null
--	drop function dbo.GetProductsOfManufacturer
--go
--create function dbo.GetProductsOfManufacturer
--(
--	@ManufacturerId int
--)
--returns table
--as
--return
--	select p.Price,p.ProductCount,p.ProductName,m.ManufacturerName,
--	case 
--	when c.CategoryName is null then 'Unknown'
--	else c.CategoryName
--	end CategoryName, 

--	case
--	when p.ProductCount>=1 then 1
--	else 0
--	end Availability_
--	from dbo.Product p inner join dbo.Manufacturer m
--		on p.ManufacturerId=m.ManufacturerId left join dbo.Category c
--		on c.CategoryId=p.CategoryId
--	where @ManufacturerId=p.ManufacturerId
--go
--select *
--from dbo.GetProductsOfManufacturer(1)


