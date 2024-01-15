use TSQL2012
go
SELECT empid, lastname, firstname, title, titleofcourtesy, birthdate, hiredate, city, address, region, postalcode, country, phone, mgrid
into dbo.Employees
FROM HR.Employees




set identity_insert dbo.Employees on
insert into dbo.Employees(empid, lastname, firstname, title, titleofcourtesy,
	birthdate, hiredate, city, address, region,
	postalcode, country, phone, mgrid)
select empid, lastname, firstname, title, titleofcourtesy,
	birthdate, hiredate, city, address, region,
	postalcode, country, phone, mgrid
from dbo.Employees
set identity_insert dbo.Employees off

select empid, lastname, firstname, title, titleofcourtesy,
	birthdate, hiredate, city, address, region,
	postalcode, country, phone, mgrid
from dbo.Employees
order by empid