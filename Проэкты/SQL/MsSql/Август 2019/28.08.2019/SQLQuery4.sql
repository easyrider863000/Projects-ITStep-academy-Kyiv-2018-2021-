select *
from dbo.Suppliers

select *
from dbo.Customers
go
create procedure InsertSuppliers
	@name varchar(100)
as
begin
	insert into Suppliers(FullName)
	values(@name)
	print 'InsertSuppliers; @@identity = '+cast(@@identity as varchar(5))
	print 'InsertSuppliers; scope_identity() = '+cast(scope_identity() as varchar(5))
end


