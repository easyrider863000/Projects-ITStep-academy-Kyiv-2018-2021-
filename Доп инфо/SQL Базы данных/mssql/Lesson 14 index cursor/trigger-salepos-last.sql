USE [ShopAdo]
GO
/****** Object:  Table [dbo].[Sale]    Script Date: 10.09.2019 7:43:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
if object_id('dbo.SalePos','U') is not null
	drop table dbo.SalePos
go
if object_id('dbo.Sale','U') is not null
	drop table dbo.Sale
go

CREATE TABLE [dbo].[Sale](
	[SaleId] [int] NOT NULL,
	[Summa] [money] NOT NULL,
	CreateDate DateTime not null default(GetDate()),
PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalePos]    Script Date: 10.09.2019 7:43:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[SalePos](
	[PosId] [int] NOT NULL,
	[SaleId] [int] NULL,
	[ProductId] [int] NOT NULL,
	[unitprice] [money] NOT NULL,
	[qty] [smallint] NOT NULL,
	[discount] [numeric](4, 3) NOT NULL,
 CONSTRAINT [PK_ProIdPosIs] PRIMARY KEY CLUSTERED 
(
	[PosId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Sale] ([SaleId], [Summa]) VALUES (5, 20000.0000)
INSERT [dbo].[Sale] ([SaleId], [Summa]) VALUES (7, 5600.0000)
INSERT [dbo].[SalePos] ([PosId], [SaleId], [ProductId], [unitprice], [qty], [discount]) VALUES (1, 5, 12, 11350.0000, 26, CAST(0.200 AS Numeric(4, 3)))
INSERT [dbo].[SalePos] ([PosId], [SaleId], [ProductId], [unitprice], [qty], [discount]) VALUES (2, 5, 1, 8000.0000, 26, CAST(0.600 AS Numeric(4, 3)))
INSERT [dbo].[SalePos] ([PosId], [SaleId], [ProductId], [unitprice], [qty], [discount]) VALUES (3, 7, 2, 8000.0000, 26, CAST(0.050 AS Numeric(4, 3)))
INSERT [dbo].[SalePos] ([PosId], [SaleId], [ProductId], [unitprice], [qty], [discount]) VALUES (4, 7, 11, 8000.0000, 26, CAST(0.300 AS Numeric(4, 3)))
INSERT [dbo].[SalePos] ([PosId], [SaleId], [ProductId], [unitprice], [qty], [discount]) VALUES (5, 5, 12, 3200.0000, 3, CAST(0.800 AS Numeric(4, 3)))
INSERT [dbo].[SalePos] ([PosId], [SaleId], [ProductId], [unitprice], [qty], [discount]) VALUES (6, 7, 12, 2000.0000, 6, CAST(0.500 AS Numeric(4, 3)))
INSERT [dbo].[SalePos] ([PosId], [SaleId], [ProductId], [unitprice], [qty], [discount]) VALUES (1024, 5, 10, 250.0000, 100, CAST(0.200 AS Numeric(4, 3)))
INSERT [dbo].[SalePos] ([PosId], [SaleId], [ProductId], [unitprice], [qty], [discount]) VALUES (1024, 7, 14, 140.0000, 80, CAST(0.500 AS Numeric(4, 3)))
ALTER TABLE [dbo].[SalePos]  WITH CHECK ADD  CONSTRAINT [FK_SalePos_Sale] FOREIGN KEY([SaleId])
REFERENCES [dbo].[Sale] ([SaleId])
GO
ALTER TABLE [dbo].[SalePos] CHECK CONSTRAINT [FK_SalePos_Sale]
GO
