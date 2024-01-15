--select distinct country
--from Sales.Customers c
--where country not in
--		(
--			select distinct country
--			from HR.Employees
--		)



--Формирование списка продуктов с минимальной ценой за единицу в пределах категории
--select *
--from Production.Products p
--order by p.categoryid, p.unitprice

--select *
--from Production.Products pOutQuery
--where pOutQuery.unitprice=(select min(unitprice)
--							from Production.Products pIn
--							where pIn.categoryid=pOutQuery.categoryid)





--запрос, возвращающий клиентов, разместивших свои заказы 12 февраля 2007 г
--select *
--from Sales.Customers c
--where exists
--(
--select *
--from Sales.Orders o
--where o.custid=c.custid and o.orderdate='20070212'
--)





