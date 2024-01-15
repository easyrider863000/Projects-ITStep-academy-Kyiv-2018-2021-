set dateformat mdy
select *
from Sales.Orders o
where o.empid=6 and o.orderdate>='01.01.2007' and o.orderdate<='12.31.2007'
order by freight desc, orderdate