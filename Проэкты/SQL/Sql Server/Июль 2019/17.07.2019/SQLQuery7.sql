select custid, count(custid) CountCustomerOrders
from Sales.Orders o
where YEAR(orderdate)=2007
group by custid
having count(custid)>=10
order by CountCustomerOrders