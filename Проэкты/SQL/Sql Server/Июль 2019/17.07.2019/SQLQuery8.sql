select empid, SUM(freight), MIN(freight), MAX(freight), AVG(freight)
from Sales.Orders
where YEAR(orderdate)=2007
group by empid
having AVG(freight)>70
order by 2 desc