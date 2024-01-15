--Написать триггер для реализации следующей логики: любой
--элемент из таблицы Sales.OrderDetails со значением unitprice
--меньше 10 не может иметь скидку более .5.

--if OBJECT_ID('Sales.Trigger_OrderDetails','TR') is not null
--	drop trigger Sales.Trigger_OrderDetails
--go
--create trigger Sales.Trigger_OrderDetails on Sales.OrderDetails
--	after insert
--as
--begin
--	set Nocount on
--	if exists
--	(
--		select orderid, productid, unitprice, qty, discount
--		from inserted
--		where unitprice<10 and discount>0.5
--	)
--	begin
--		throw 50000, 'Discount must be <= .5 when unitprice < 10',0
--	end
--end



--Написать триггер для таблицы Category, который не
--позволит вставить запись с наименованием категории,
--которая уже есть в таблице

--if OBJECT_ID('trgForCategory','TR') is not null
--	drop trigger trgForCategory
--go
--create trigger trgForCategory on dbo.Category
--	instead of insert
--	as
--	begin
--	Set Nocount on
--	if exists
--	(
--		SELECT CategoryId, CategoryName
--		FROM Category c
--		where CategoryName in (select CategoryName
--							from inserted)
--	)
--	begin
--		throw 50000, 'Product is exists',0
--	end

--	insert into dbo.Category(CategoryName)
--	select CategoryName
--	from inserted
--end
--go

--insert into dbo.Category(CategoryName)
--values('Videokkarta')
--select *
--from dbo.Category



--Написать триггер для таблицы Product, который при
--попытке ввода в колонку ProductCount отрицательного
--значения, выводит сообщение об ошибке.

--if OBJECT_ID('trgForProduct','TR') is not null
--	drop trigger trgForProduct
--go
--create trigger trgForProduct on dbo.Product
--	instead of insert
--	as
--	begin
--	Set Nocount on
--	if exists
--	(
--		SELECT i.ProductCount
--		from inserted i
--		where i.ProductCount<0
--	)
--	begin
--		throw 50000, 'ProductCount is entered not correct. ProductCount must be > 0',0
--	end

--	insert into dbo.Product(CategoryId, discount,ManufacturerId, Price, ProductCount, ProductName)
--	select CategoryId, discount,ManufacturerId, Price, ProductCount, ProductName
--	from inserted
--end
--go

--insert into dbo.Product(CategoryId, discount,ManufacturerId, Price, ProductCount, ProductName)
--values(1, 0.50,1, 26, -1, 'Test1')
--select *
--from dbo.Product



--Написать триггер для таблицы SalePos, который при
--изменении таблицы обновляет сумму заказа в таблице Sale.

if OBJECT_ID('trgForSalePos','TR') is not null
	drop trigger trgForSalePos
go
create trigger trgForSalePos on dbo.SalePos
	instead of update
	as
	begin
	Set Nocount on
	update dbo.SalePos
	set Price = i.Price, Qty=i.Qty
	from dbo.SalePos s inner join inserted i
		on s.SaleId=i.SaleId
	
	update dbo.Sale
	set Summa= sp.Price*sp.Qty
	from dbo.SalePos sp inner join dbo.Sale s
		on s.SaleId=sp.SaleId
end
go

--select *
--from Sale
--update dbo.SalePos
--set Price=200, Qty=3
--where SaleId=17
--select *
--from Sale