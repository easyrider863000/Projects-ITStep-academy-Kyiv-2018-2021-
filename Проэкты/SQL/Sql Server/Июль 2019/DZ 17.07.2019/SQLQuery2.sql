--¬ыбрать количество заказов каждого сотрудника

--select empid, count(*) as NumberOfOrders
--from Sales.Orders 
--GROUP BY empid



--¬ыбрать количество заказов каждого сотрудника за 2007 год. ќтсортировать их по убыванию.

--set dateformat mdy
--select empid, count(*) as NumberOfOrders
--from Sales.Orders o
--where o.orderdate>='01.01.2007' and o.orderdate<='12.31.2007'
--GROUP BY empid
--order by NumberOfOrders desc



--¬ыбрать айдишник  заказчиков, которые сделали заказов больше 10 в 2007 году

--select custid, count(*) as NumberOfOrders
--from Sales.Orders o
--where o.orderdate>='01.01.2007' and o.orderdate<='12.31.2007'
--group by custid
--having count(*)>10