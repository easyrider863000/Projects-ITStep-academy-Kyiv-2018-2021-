if OBJECT_ID('Sales.Trigger_OrderDetails','TR') is not null
	drop trigger Sales.Trigger_OrderDetails
go
create trigger Sales.Trigger_OrderDetails on Sales.OrderDetails
	after insert
as
begin
	set Nocount on
	if exists
	(
		select orderid, productid, unitprice, qty, discount
		from inserted
		where unitprice<10 and discount>0.5
	)
	begin
		throw 50000, 'Discount must be <= .5 when unitprice < 10',0
	end
end