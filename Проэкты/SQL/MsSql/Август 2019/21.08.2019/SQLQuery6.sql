SELECT orderid, custid, empid, orderdate, requireddate, shipperid, shippeddate, freight, shipname, shipaddress, shipcity, shipregion, shippostalcode, shipcountry
into dbo.Orders
FROM     Sales.Orders


truncate table dbo.Orders
drop table dbo.Orders


select *
from dbo.Orders








