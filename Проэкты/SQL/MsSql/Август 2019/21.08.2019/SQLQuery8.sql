--Написать запросы, которые создают копии таблиц Production.Products,
--Production.Categories и Production.Suppliers
--базы данных TSQLFundamentals2008 В БАЗЕ ДАННЫХ tempdb;

--SELECT productid, productname, supplierid, categoryid, unitprice, discontinued
--into dbo.ProductionProducts
--FROM     Production.Products
--select *
--from dbo.ProductionProducts

--SELECT categoryid, categoryname, description
--into dbo.ProductionCategories
--FROM     Production.Categories
--select *
--from dbo.ProductionCategories

--SELECT supplierid, companyname, contactname, contacttitle, address, city, region, postalcode, country, phone, fax
--into dbo.ProductionSuppliers
--FROM     Production.Suppliers
--select *
--from dbo.ProductionSuppliers


--Написать запрос к базе данных  tempdb,
--который выводит все товары - наименование категории,
--наименование товара , название поставщика и цена
--товара – цены которых выше средней по категории.

--select *
--from TSQL2012.dbo.ProductionProducts p inner join TSQL2012.dbo.ProductionCategories c
--	on p.categoryid=c.categoryid inner join TSQL2012.dbo.ProductionSuppliers s
--	on s.supplierid=p.supplierid inner join (select p2.categoryid, AVG(p2.unitprice) avgprice
--											from TSQL2012.dbo.ProductionProducts p2
--											group by p2.categoryid) p2 on p2.categoryid=p.categoryid
--where unitprice>avgprice

					
