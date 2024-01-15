--use TSQL2012
--go

select *
from HR.Employees e


select count(*) as CountRecord,
	   count(o.empid) CountRecordByEmpId,
	   count(o.shipregion) CountRecordByShipRegion,
	   count(distinct o.empid) CountRecordByEmpIdDistrict,
	   count(distinct o.custid) CountRecordByCustId
from Sales.Orders o

select count(*)
from Sales.Orders o
where o.shipregion is not null