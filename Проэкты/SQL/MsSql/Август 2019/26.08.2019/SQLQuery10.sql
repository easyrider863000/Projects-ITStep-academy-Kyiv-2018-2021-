--select name FullName, mobile Phone
--from dbo.Customers

--union all

--select FullName, Phone
--from dbo.Suppliers




--select name FullName, mobile Phone
--from dbo.Customers

--intersect

--select FullName, Phone
--from dbo.Suppliers


--select name FullName
--from dbo.Customers

--intersect

--select FullName
--from dbo.Suppliers


--select name FullName, mobile Phone
--from dbo.Customers

--except

--select FullName, Phone
--from dbo.Suppliers

--use TSQL2012
--go

--select e.country, e.region, e.city 
--from hr.Employees e

--intersect

--select e.country, e.region, e.city 
--from Sales.Customers e





--select e.country, e.region, e.city 
--from hr.Employees e

--except

--select e.country, e.region, e.city 
--from Sales.Customers e



(select name
from dbo.Customers
except
select FullName
from dbo.Suppliers)
intersect
select Name
from dbo.EmployeeNames

