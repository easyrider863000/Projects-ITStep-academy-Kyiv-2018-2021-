--select empid
--from Sales.Orders
--group by empid


--select empid, count(*) CountOrders
--from Sales.Orders
--group by empid
--order by CountOrders desc

set dateformat dmy

select empid, count(*) CountOrders
from Sales.Orders
where orderdate>='01.01.2007' and orderdate<='31.12.2007'
group by empid
having count(*)>50
order by CountOrders desc