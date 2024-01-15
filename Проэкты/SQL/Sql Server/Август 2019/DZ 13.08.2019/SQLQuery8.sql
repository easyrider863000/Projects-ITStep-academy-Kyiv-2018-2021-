--1. Вывести на экран все города
--select *
--from dbo.Cities


--2. Вывести на экран имена всех продавцов с комиссией больше 0.11
--select *
--from dbo.Sellers
--where comision>0.11


--3. Вывести на экран имена всех продавцов из города Львов
--select s.SName
--from dbo.Sellers s inner join dbo.Cities c
--	on c.id=s.id_city
--where c.City_Name='Львов'


--4. Вывести на экран имена всех покупателей, работающих с продавцом Петр
--select c.CName
--from dbo.Customers c inner join dbo.Sellers s 
--	on c.id_Sel=s.id
--where s.SName='Пётр'


--5. Вывести на экран имена всех покупателей, у которых нету продавцов 
--select c.CName
--from dbo.Customers c inner join dbo.Orders o
--	on o.id_Cus=c.id
--where o.id_Sel is null


--6. Вывести на экран средний рейтинг покупателей из Львов
--select AVG(c.Raiting)
--from dbo.Customers c inner join dbo.Cities ci
--	on ci.id=c.id_city
--where ci.City_Name='Львов'


--7. Вывести на экран самую последнюю операцию в таблице Orders (по полю data)
--select *
--from dbo.Orders o
--where o.data=(select Max(data) from dbo.Orders)


--8. Вывести на экран продавцов, у которых более 2-х покупателей
--select se.SName, count(id_sel)
--from dbo.Sellers se inner join dbo.Customers c
--	on se.id=c.id_Sel
--group by se.SName
--having count(id_sel)>=2


--9. Вывести на экран самую крупную сделку
--select *
--from dbo.Orders
--where Summa=(select max(Summa) from dbo.Orders)


--10.Вывести на экран количество сделок с продавцами из города Николаев
--select s.SName, count(id_sel) CountSel
--from dbo.Orders o inner join dbo.Sellers s
--	on o.id_sel=s.id
--	inner join dbo.Cities c
--	on c.id=s.id_city
--where City_Name='Николаев'
--group by S.SName


--11.Вывести на экран количество покупателей в каждом городе (Киев, Львов, Николаев)
--select City_Name, count(City_Name) CountCustomers
--from dbo.Sellers s inner join dbo.Customers c
--	on s.id=c.id_Sel
--	right join dbo.Cities ci
--	on ci.id=c.id_city
--where (ci.City_Name='Киев'or ci.City_Name='Львов' or ci.City_Name='Николаев') and not c.id_Sel is null
--group by ci.City_Name


--12.Вывести на экран имя покупателя, продавца, сумму сделки, место проживания покупателя, место проживания продавца, рейтинг покупателя, комиссию продавца, сумму, заработанную продавцом в период с '01.01.2015' по '20.01.2015'
--select c.CName, s.SName, o.Summa as DealSumma, cityC.City_Name as CustomerCity, cityS.City_Name as SellerCity, 
--c.Raiting as CustomerRaiting, s.comision as SellerComision, SMoney.EarnedMoney SellerEarnedMoney
--from dbo.Orders o join dbo.Customers c
--	on o.id_Cus = c.id 
--	join dbo.Sellers s 
--	on o.id_Sel = s.id
--	join dbo.Cities cityC 
--	on c.id_city = cityC.id
--	join dbo.Cities cityS
--	on s.id_city = cityS.id
--	join 
--	(
--		select o.id_Sel, sum(o.Summa) EarnedMoney
--		from dbo.Orders o
--		where o.data >= '20150101' and o.data <= '20150120'
--		group by o.id_Sel
--	) SMoney
--	on SMoney.id_Sel = s.id
--order by 1


--13.Вывести на экран самую крупную покупку покупателя из города Киев
--select CName,ci.City_Name,o.Summa
--from dbo.Customers c inner join dbo.Cities ci
--	on c.id_city=ci.id inner join dbo.Orders o
--	on c.id=o.id_Cus
--where o.Summa=(select MAX(ord.Summa)
--				from dbo.Orders ord inner join dbo.Customers cu
--				on cu.id=ord.id_Cus inner join dbo.Cities cit
--				on cit.id=cu.id_city
--				where cit.City_Name='Киев'
--				)


--14.Вывести на экран количество сделок продавца Петр с покупателями из города Львов
--select s.SName, count(s.SName) NumOfOrder
--from dbo.Sellers s inner join dbo.Customers c
--	on c.id_Sel=s.id inner join dbo.Cities ci
--	on ci.id=c.id_city
--where ci.City_Name='Львов' and s.SName='Пётр'
--group by s.SName,ci.City_Name


--15.Вывести на экран всех покупателей, купивших товар до 2015-02-10 числа со стоимостью меньше 2000
--select c.CName,o.data,o.Summa
--from dbo.Customers c inner join dbo.Orders o
--	on c.id=o.id_Cus
--where o.data<='20150210' and o.Summa<2000


--16.Вывести на экран все покупки покупателя из города Львов
--select c.CName, c.Raiting, ci.City_Name,o.data,o.Summa
--from dbo.Customers c inner join dbo.Cities ci
--	on c.id_city=ci.id inner join dbo.Orders o
--	on o.id_Cus=c.id
--where ci.City_Name='Львов'


--17.Вывести на экран доход каждого продавца за 2015год
--select s.SName, SUM(o.Summa) SalaryFor2015
--from dbo.Sellers s inner join dbo.Orders o
--	on s.id=o.id_Sel
--where year(o.data)=2015
--group by s.SName
--order by SalaryFor2015 desc


--18.Вывести на экран имена всех продавцов, у которых нету покупателей
--select s.SName
--from dbo.Sellers s cross join dbo.Customers c
--where c.id_Sel is null and s.id not in(select s2.id
--									from dbo.Sellers s2)


--19.Вывести на экран покупателей, которые работают с продавцами : Петр, Руслан, Алексей
--select c.CName, s.SName
--from dbo.Customers c inner join dbo.Sellers s
--	on c.id_Sel=s.id
--where s.SName='Пётр' or s.SName='Алексей' or s.SName='Руслан'


--20.Вывести на экран покупателей, которые покупали товары у продавцов из разных городов
--select c.CName,o.data,o.Summa,s.SName,ci.City_Name
--from dbo.Customers c inner join dbo.Orders o
--	on c.id_Sel=o.id_Cus inner join dbo.Sellers s
--	on s.id=o.id_Sel inner join dbo.Cities ci
--	on ci.id=s.id_city
--where s.SName in ( select s2.SName
--					from dbo.Customers c2 inner join dbo.Orders o2
--						on c2.id_Sel=o2.id_Cus inner join dbo.Sellers s2
--						on s2.id=o2.id_Sel inner join dbo.Cities ci2
--						on ci2.id=s2.id_city
--					where not s.SName=s2.SName
--					)


--21.Вывести на экран продавцов, которые продали товар покупателям из Киева и Львова
--select s.SName
--from dbo.Sellers s inner join dbo.Orders o
--	on o.id_Sel=s.id inner join dbo.Customers c
--	on c.id=o.id_Cus inner join dbo.Cities ci
--	on ci.id=c.id_city
--where ci.City_Name='Киев' and ci.City_Name in(select ci2.City_Name
--												from dbo.Sellers s2 inner join dbo.Orders o2
--													on o2.id_Sel=s2.id inner join dbo.Customers c2
--													on c2.id=o2.id_Cus inner join dbo.Cities ci2
--													on ci2.id=c2.id_city
--													where ci.City_Name='Львов'
--												)


--22.Вывести на экран все покупки, в которых покупатель не из города продавца
--select *
--from dbo.Customers c inner join dbo.Orders o
--	on c.id=o.id_Cus inner join dbo.Sellers s
--	on s.id=o.id_Sel
--where not c.id_city=s.id_city


--23.Вывести на экран все покупки, в которых покупатель из города продавца
--select *
--from dbo.Customers c inner join dbo.Orders o
--	on c.id=o.id_Cus inner join dbo.Sellers s
--	on s.id=o.id_Sel
--where c.id_city=s.id_city






