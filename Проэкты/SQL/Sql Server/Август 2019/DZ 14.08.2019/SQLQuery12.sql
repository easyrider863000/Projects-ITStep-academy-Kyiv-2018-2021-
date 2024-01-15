--1. ¬ернуть все заказы, сделанные в последний день деловой активности - Sales.Orders
--select *
--from Sales.Orders o
--where o.orderdate=(
--					select max(ord.orderdate)
--					from Sales.Orders ord
--					)


--2. Ќаписать запрос, который возвращает все заказы клиентов поместивших максимальное количество заказов - Sales.Orders
--select *
--from Sales.Orders
--where custid in
--(select custid
--from 
--		(select o.custid, count(o.custid) CountOrders
--		from Sales.Orders o
--		group by o.custid) a

--where CountOrders = (select max(CountOrders)
--		from
--		(select o.custid, count(o.custid) CountOrders
--		from Sales.Orders o
--		group by o.custid) a 
--		)
--)


--3. Ќаписать запрос, который возвращает сотрудников не поместивших ни одного заказа или не сделавших их после 1 ма€ 2008 года -  HR.Employeers , Sales.Orders
--set dateformat dmy
--select *
--from HR.Employees e
--where e.empid not in 
--(
--	select  o.empid
--	from Sales.Orders o
--	where o.orderdate>'01.05.2008'
--)
--or
--e.empid not in
--(
--	select  o.empid
--	from Sales.Orders o
--	where not o.custid is null
--)



--4. Ќаписать запрос, возвращающий страны в которых есть клиенты, но нет сотрудников - Sales.Customers, HR.Employeers 
--select distinct country
--from Sales.Customers c
--where country not in
--		(
--			select distinct country
--			from HR.Employees
--		)


--5. Ќаписать запрос, возвращающий дл€ каждого клиента все заказы сделанные в последний день деловой активности  Ћ»≈Ќ“ј - Sales.Orders
--select *
--from Sales.Orders o
--where o.orderdate =
--(
--	select max(orderdate)
--	from Sales.Orders ord
--	where ord.custid=o.custid
--)


--6. Ќаписать запрос, возвращающий custid, companyname клиентов сделавших заказы в 2007 году и не сделавших ни одного заказа в 2008 году  - Sales.Orders, Sales.Customers
--select c.custid,c.companyname
--from Sales.Customers c
--where c.custid in (select  o.custid
--					from Sales.Orders o
--					where o.orderdate>='20070101' and o.orderdate<='20071231'
--					)
--					and c.custid not in
--					(
--					select  o.custid
--					from Sales.Orders o
--					where o.orderdate>='20080101' and o.orderdate<='20081231'
--					)


--7. Ќаписать запрос, возвращающий custid, companyname заказавших товар с айдишником 12  - Sales.Orders, Sales.Customers, Sales.OrderDetails
--select custid,companyname
--from Sales.Customers c
--where c.custid in 
--(
--	select o.custid
--	from Sales.Orders o
--	where orderid in
--	(
--		select orderid
--		from Sales.OrderDetails od
--		where o.orderid=od.orderid and od.productid=12
--	)
--)




