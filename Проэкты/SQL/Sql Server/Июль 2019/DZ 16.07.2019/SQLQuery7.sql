--1 ������� ����� ���������� �� 20 �� 25 ���.
--select *
--from dbo.books b
--where b.Price>=20 and b.Price<=25


--2 ������� ����� � ������� �� ������ ���� �������
--select *
--from dbo.books b
--where b.Date is null


--3 ������� ����� � ������� ���������� ���-�� �������
--select *
--from dbo.books b
--where b.Pages is null


--4 ������� ����� � ������� ���������� ������!!!
--select *
--from dbo.books b
--where b.Format is null or b.Format=''


--5 ������� ����� ����������� �������, � ������� �� ������� ���� �������
--select *
--from dbo.books b
--where b.Izd='�������' and b.Date is null


--6 ������� ����� ���������� ����� 10 � ����� 20 ��� � ������������� �� �� ���� � ���� �������
--select *
--from dbo.books b
--where b.Price<10 or b.Price>20
--order by b.Price, b.Date


--7 ������� ����� ���� ������� ������� ����� � �������� ���������
--select *
--from dbo.books b
--where b.Date>='2000.01.01' and b.Date<='2001.01.01'


--8 ������� ����� �� ����  CorelDRAW 9
--select *
--from dbo.books b
--where b.Name like '%CorelDRAW%9%' 


--9 ������� ����� �� ����  CorelDRAW 9 ������������ �����
--select *
--from dbo.books b
--where b.Name like '%CorelDRAW%9%' and b.Izd='�����'


--10 ������� ����� � ������� ������ � ���� ������� �� ������
--select *
--from dbo.books b
--where b.Format is null and b.Date is null


--11 ������� ����� � ������� � �������� ����� ��� ����� '�'
--select *
--from dbo.books b
--where (b.Name like '%�%�%' and b.Name not like '%�%�%�%')