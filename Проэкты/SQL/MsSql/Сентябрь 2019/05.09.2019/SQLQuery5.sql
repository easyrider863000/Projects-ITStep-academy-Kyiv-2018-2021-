--�������� ������� ��� ���������� ��������� ������:
--����� ������� �� ������� Sales.OrderDetails �� ���������
--unitprice ������ 10 �� ����� ����� ������ �����

select *
from Sales.OrderDetails
where orderid=10248

insert into Sales.OrderDetails(orderid, productid, unitprice, qty, discount)
values(10248,41,7.70,3,0.7),
	(10248,65,16.80,2,0.6)
--10248 41 7.70
--10248 65 16.80

delete from Sales.OrderDetails
where orderid=10248 and productid in(41,65)
