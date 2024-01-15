--select *
--from Sales.OrderDetails

if object_id('dbo.GetSumByProduct','FN') is not null
	drop function dbo.GetSumByProduct
go
create function dbo.GetSumByProduct
(
	@orderid int
)
returns money
as
begin
	declare @sum money;
    set @sum = (select sum(unitprice * qty * (1-discount) )
    from Sales.OrderDetails d
    where d.orderid = @orderid)
    return @sum
end
go
select (dbo.GetSumByProduct(10607))