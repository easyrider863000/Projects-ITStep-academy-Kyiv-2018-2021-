--select e.empid, e.firstname+' '+e.lastname, year(e.birthdate)
--from HR.Employees e


--select EOMONTH(DATEFROMPARTS(year(GetDate()),MONTH(GetDate()),1))


--select *
--from Sales.Orders
--where Month(orderdate)=6 and year(orderdate)=2007


--select *
--from hr.Employees
--where lastname like '%[a]%[a]%' and lastname not like '%[a]%[a]%[a]%'


--select o.shipcountry, avg(o.freight) avg_freight
--from Sales.Orders o
--group by o.shipcountry
--having avg(o.freight)>(
--	select avg(freight)
--	from Sales.Orders
--	where year(orderdate)=2006
--)


--select *
--from Sales.Orders o
--where o.orderdate= EOMONTH(o.orderdate)

