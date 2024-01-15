--1. �������� ������, ������� ���������� ��� ���������� �
--������������ ���������, ������� ������ ������ � ������
--2008 � ������� 2008 ����

--select e.firstname,c.contactname
--from hr.Employees e inner join Sales.Orders o
--	on e.empid=o.empid inner join Sales.Customers c
--	on c.custid=o.custid
--where YEAR(o.orderdate)='2008' and MONTH(o.orderdate)='1'
--intersect
--select e.firstname,c.contactname
--from hr.Employees e inner join Sales.Orders o
--	on e.empid=o.empid inner join Sales.Customers c
--	on c.custid=o.custid
--where YEAR(o.orderdate)='2008' and MONTH(o.orderdate)='2'



--2. �������� ������, ������� ���������� ��� ���������� �
--������������ ���������, ������� ������ ������ � ������
--2008, �� �� � ������� 2008 ����

--select e.firstname,c.contactname
--from hr.Employees e inner join Sales.Orders o
--	on e.empid=o.empid inner join Sales.Customers c
--	on c.custid=o.custid
--where YEAR(o.orderdate)='2008' and MONTH(o.orderdate)='1'
--intersect
--select e.firstname,c.contactname
--from hr.Employees e inner join Sales.Orders o
--	on e.empid=o.empid inner join Sales.Customers c
--	on c.custid=o.custid
--where YEAR(o.orderdate)='2008' and MONTH(o.orderdate)<>'2'



--3. �������� �������������, ������� ���������� ����������
--� ���������� � ���������� ��� ������� �� �����.

--create view ViewEmployeeYear
--as
--SELECT distinct en.empid, en.lastname, en.firstname, en.title,
--	en.titleofcourtesy, en.birthdate, en.hiredate,
--	en.address, en.city, en.region, en.postalcode,
--	en.country, en.phone, en.mgrid, cnt.OrderYear, cnt.OrdersCount
--FROM Sales.Orders one INNER JOIN HR.Employees en 
--	ON en.empid = one.empid inner join 
--		(SELECT 
--			e.empid
--		    ,YEAR(o.OrderDate) OrderYear
--		    ,COUNT(o.OrderId) OrdersCount 
--		FROM Sales.Orders o inner join HR.Employees e
--			on e.empid=o.empid
--		GROUP BY YEAR(o.OrderDate),e.empid) cnt
--			on cnt.OrderYear=year(one.orderdate) and cnt.empid=en.empid

--select *
--from dbo.ViewEmployeeYear ve
--order by ve.empid, ve.OrderYear



--4*. �������� �������������, ������� ���������� ����������
--� ���������, ���������� � ����� ������� �� �����.

--create view ViewCustomerYear
--as
--SELECT distinct en.custid, en.companyname, en.contactname,
--	en.contacttitle, en.address, en.city, en.region,
--	en.postalcode, en.country, en.phone, en.fax,
--	cnt.OrderYear, cnt.OrdersCount, cnt.OrdersSum
--FROM Sales.Customers en INNER JOIN Sales.Orders one
--	ON en.custid = one.custid inner join 
--		(SELECT 
--			e.custid
--		    ,YEAR(o.OrderDate) OrderYear
--		    ,COUNT(o.OrderId) OrdersCount
--			,Sum(o.freight) OrdersSum
--		FROM Sales.Orders o inner join Sales.Customers e
--			on e.custid=o.custid
--		GROUP BY YEAR(o.OrderDate),e.custid) cnt
--			on cnt.OrderYear=year(one.orderdate) and cnt.custid=en.custid

--select *
--from dbo.ViewCustomerYear ve
--order by ve.custid, ve.OrderYear