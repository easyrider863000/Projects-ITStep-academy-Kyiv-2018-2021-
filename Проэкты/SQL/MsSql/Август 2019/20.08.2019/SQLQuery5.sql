declare @s char(3) = '123',
		@a char(3) = 'abs', @i int = 32

select @a+ cast(@i as char(10))

select try_cast(@s as int ), try_cast(@a as int)

select cast(@s as int ), cast(@a as int)
------------------------------------------------

select parse('1/2/2012' as date using 'en-US')
select parse('1/2/2012' as date using 'ru-RU')
select parse('1/2/2012' as date using 'uk-UA')

select cast(5 as float)/2



declare @year int = 2019

select DATEFROMPARTS(@year,num.n,1) start_period, EOMONTH(DATEFROMPARTS(@year,num.n,1)) end_period
from dbo.Nums num
where num.n<=12


select c.custid, c.companyname,c.contactname,
coalesce( c.region+', ','')+c.country+', '+c.city+', '+c.address fulladdress
from Sales.Customers c


select len(phone) len_phone, DATALENGTH(phone) len_phone_byte
from HR.Employees e

go

declare @s char(3) = '123',
		@a char(3) = 'abs', @i int = 32

select len(@a) len_s, DATALENGTH(@a) len_s_byte


SELECT productid, productname, unitprice, discontinued,
CASE discontinued
WHEN 0 THEN 'No'
WHEN 1 THEN 'Yes'
ELSE 'Unknown'
END AS discontinued_desc
FROM Production.Products;




SELECT productid, productname, unitprice,
CASE
WHEN unitprice < 20.00 THEN 'Low'
WHEN unitprice < 40.00 THEN 'Medium'
WHEN unitprice >= 40.00 THEN 'High'
ELSE 'Unknown'
END
AS pricerange
FROM Production.Products
order by unitprice

