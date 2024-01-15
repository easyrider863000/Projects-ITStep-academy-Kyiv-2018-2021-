select c.companyname,c.address, c.country, count(o.orderid) countorder
from Sales.Customers c left join Sales.Orders o
	on c.custid=o.custid
group by c.companyname, c.address, c.country