use ShopAdo
go
if object_id('SalePos','U') is not null
	drop table SalePos
go
if object_id('Sale','U') is not null
	drop table Sale
go
create table Sale
(
	SaleId int identity primary key,
	DateSale DateTime not null default(GetDate()),
	UserName nvarchar(64),
	Summa money not null default(0)
)
insert into dbo.Sale(UserName,Summa)
select p.ProductName, p.Price*p.ProductCount*(1-p.discount)
from dbo.Product p



go
create table SalePos
(
	SalePosId int identity primary key,
	SaleId int foreign key references Sale(SaleId),
	ProductId int foreign key references Product(ProductId),
	Price money not null default(0),
	Qty numeric(18,3) not null default(1)
)

insert into dbo.SalePos(ProductId,Price,Qty)
select p.ProductId, p.Price, p.ProductCount
from dbo.Product p

update dbo.SalePos
set SaleId = (select SaleId
from dbo.Sale
where SalePosId=SaleId)

select *
from dbo.SalePos
