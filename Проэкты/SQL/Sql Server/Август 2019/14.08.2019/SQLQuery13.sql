--select distinct country
--from Sales.Customers c
--where country not in
--		(
--			select distinct country
--			from HR.Employees
--		)



--������������ ������ ��������� � ����������� ����� �� ������� � �������� ���������
--select *
--from Production.Products p
--order by p.categoryid, p.unitprice

--select *
--from Production.Products pOutQuery
--where pOutQuery.unitprice=(select min(unitprice)
--							from Production.Products pIn
--							where pIn.categoryid=pOutQuery.categoryid)





--������, ������������ ��������, ������������ ���� ������ 12 ������� 2007 �
--select *
--from Sales.Customers c
--where exists
--(
--select *
--from Sales.Orders o
--where o.custid=c.custid and o.orderdate='20070212'
--)





