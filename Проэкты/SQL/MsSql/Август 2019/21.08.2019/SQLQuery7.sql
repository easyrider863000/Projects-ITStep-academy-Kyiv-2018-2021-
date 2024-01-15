select c.country, count(o.orderid) AmountOrder
from Sales.Customers c inner join Sales.Orders o
	on c.custid=o.custid
where YEAR(o.orderdate)=2007
group by c.country
having count(o.orderid)>40


select *
from Sales.Orders o inner join Sales.OrderDetails od
	on od.orderid=o.orderid
where od.productid in(12,21)


select *
from Sales.Orders o
where o.orderid in (select od.orderid
				from Sales.OrderDetails od
				where od.productid in (12,21))



