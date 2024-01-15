--SELECT custid, orderid, val,
--	SUM(val) OVER(PARTITION BY custid) AS custtotal,
--	SUM(val) OVER() AS grandtotal
--FROM Sales.OrderValues;

--select *
--from
--(
--SELECT orderid, od.productid,p.productname, od.unitprice * qty * (1-discount) price,
--	sum(od.unitprice * qty * (1-discount)) over(partition by orderid) PriceOrder
--FROM     Sales.OrderDetails od inner join Production.Products p
--			on p.productid=od.productid
--) tmp
--where tmp.PriceOrder>=1000

--declare @CountRecord int =10, @CurrentPage int =1
--select *
--from(
--SELECT orderid, custid, empid, orderdate
--,ROW_NUMBER() over(order by orderid) rownum
--FROM     Sales.Orders AS o
--) t
--where t.rownum between (@CurrentPage-1)*@CountRecord+1 and @CurrentPage*@CountRecord

--select *
--from Sales.Customers

--if object_id('CustomersPaging','P') is not null
--	drop procedure CustomersPaging
--go
--create procedure CustomersPaging
--@ColumnOrder nvarchar(64),
--@CountRecord int =10,
--@CurrentPage int =1
--as
--begin
--declare @query nvarchar(2000)=
--'select *
--from(
--SELECT orderid, custid, empid, orderdate
--,ROW_NUMBER() over(order by param) rownum
--FROM     Sales.Orders AS o
--) t
--where t.rownum between (@CurrentPage-1)*@CountRecord+1 and @CurrentPage*@CountRecord'
--set @query=REPLACE(@query,'param',@ColumnOrder)
--set @query=REPLACE(@query,'@CurrentPage',@CurrentPage)
--set @query=REPLACE(@query,'@CountRecord',@CountRecord)
--exec(@query)
--end
--go

--exec CustomersPaging 'custid',10,4


--exec('select *
--from HR.Employees')




WITH EmpsCTE AS
(   -- закрепленный элемент возвращает строку дл€ сотрудника с номером 9.
	SELECT empid, mgrid, firstname, lastname, 0 AS distance
	FROM HR.Employees
	WHERE empid = 9

UNION ALL
    -- рекурсивный элемент вызываетс€ многократно, и каждый раз объедин€ет
	-- предыдущий результирующий набор с таблицей HR.Employees дл€ возвращени€ 
	-- непосредственного руководител€ сотрудника из предыдущего захода
	SELECT M.empid, M.mgrid, M.firstname, M.lastname,
	S.distance + 1 AS distance
	FROM EmpsCTE AS S
	JOIN HR.Employees AS M
	ON S.mgrid = M.empid 
	-- –екурсивный запрос останавливаетс€, как только он возвратит пустой набор Ч
	-- в нашем случае, не найд€ менеджера по CEO.
	)

SELECT empid, mgrid, firstname, lastname, distance
FROM EmpsCTE;





