select s.companyname, s.address, s.country, p.productname, c.categoryname, p.unitprice
from Production.Suppliers s left join Production.Products p
	on s.supplierid=p.supplierid
	join Production.Categories c
	on p.categoryid=c.categoryid
where s.country='Japan'
order by 1

