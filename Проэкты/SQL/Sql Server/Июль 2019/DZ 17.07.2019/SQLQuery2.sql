--������� ���������� ������� ������� ����������

--select empid, count(*) as NumberOfOrders
--from Sales.Orders 
--GROUP BY empid



--������� ���������� ������� ������� ���������� �� 2007 ���. ������������� �� �� ��������.

--set dateformat mdy
--select empid, count(*) as NumberOfOrders
--from Sales.Orders o
--where o.orderdate>='01.01.2007' and o.orderdate<='12.31.2007'
--GROUP BY empid
--order by NumberOfOrders desc



--������� ��������  ����������, ������� ������� ������� ������ 10 � 2007 ����

--select custid, count(*) as NumberOfOrders
--from Sales.Orders o
--where o.orderdate>='01.01.2007' and o.orderdate<='12.31.2007'
--group by custid
--having count(*)>10