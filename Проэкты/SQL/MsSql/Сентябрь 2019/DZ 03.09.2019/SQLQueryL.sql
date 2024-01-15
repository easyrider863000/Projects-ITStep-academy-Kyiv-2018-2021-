--1
--Вивести список співробітників, які отримують заробітну плату більшу ніж у безпосереднього керівника.
--select *
--from dbo.Employee e
--where e.Salary>(select e2.Salary
--				from dbo.Employee e2
--				where e2.id=e.Chief_Id)


--2
--Вивести список співробітників, які отримують максимальну заробітну плату в своєму відділі.
--select *
--from dbo.Employee e
--where e.Salary=(select max(e2.Salary)
--				from dbo.Employee e2
--				where e2.DepartmentId=e.DepartmentId)


--3
--Вивести список ID відділів, кількість співробітників в яких не перевищує 3 осіб
--select d2.id, d2.Name
--from
--(SELECT d.id, COUNT(d.id) CountD
--FROM  Department d inner join dbo.Employee e
--	on d.id=e.DepartmentId
--group by d.id
--having COUNT(d.id)<=3) t inner join dbo.Department d2
--	on d2.id=t.id


--4
--Вивести список співробітників, які не мають призначеного керівника, який працює в тому-ж відділі.
--select *
--from dbo.Employee e
--where e.Chief_Id = (select e2.Id
--					from dbo.Employee e2
--					where e2.DepartmentId<>e.DepartmentId and e.Chief_Id=e2.Id)


--5
--Знайти список ID відділів з максимальною сумарною зарплатою співробітників.
--select distinct t1.DepartmentId
--from (SELECT e.DepartmentId, e.Salary, sum(e.salary) over(partition by e.DepartmentId) SumDepartment
--FROM Employee e) t1 inner join
--(select max(t.SumDepartment) MaxSumDepartment
--from
--(SELECT e.DepartmentId, e.Salary, sum(e.salary) over(partition by e.DepartmentId) SumDepartment
--FROM Employee e) t) t2
--	on t1.SumDepartment=t2.MaxSumDepartment
