USE [master]
GO
/****** Object:  Database [ShopAdo1]    Script Date: 02/28/2018 19:01:23 ******/
CREATE DATABASE [ShopAdo1] 
GO
USE ShopAdo1
GO
CREATE TABLE [dbo].[GoodsTemp](
	[GoodId] [int] NOT NULL,
	[GoodName] [varchar](100) NOT NULL,
	[CategoryName] [nvarchar](20) NULL,
	[ManufacturerName] [nvarchar](20) NULL,
	[Price] [money] NOT NULL,
	[GoodCount] [numeric](18, 3) NOT NULL
) ON [PRIMARY]
GO

INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (1, N'HP LaserJet P2035 (CE461A)', N'Printer', N'HP', 5445.0000, CAST(12.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (2, N'Canon i-SENSYS MF212W with Wi-F', N'Printer', N'Canon', 3999.0000, CAST(7.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (3, N'Samsung SCX-4650N ', N'Printer', N'Samsung', 3999.0000, CAST(15.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (4, N'HP DJ1510 (B2L56C) ', N'Printer', N'HP', 1199.0000, CAST(2.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (5, N'Asus Transformer Book T100TAF 32GB', N'Notebook', N'Asus', 4999.0000, CAST(11.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (6, N'Lenovo Flex 10 (59427902)', N'Notebook', N'Lenovo', 5555.0000, CAST(11.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (7, N'Acer Aspire ES1-411-C1XZ', N'Notebook', N'Acer', 6399.0000, CAST(7.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (8, N'HP 255 G4 (N0Y69ES)', N'Notebook', NULL, 6199.0000, CAST(5.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (9, N'HP ProBook 430 (N0Y70ES)', N'Notebook', N'HP', 12400.0000, CAST(3.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (10, N'Ultrabook Samsung 535U3', NULL, N'Samsung', 8000.0000, CAST(10.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (11, N'Samsung Galaxy S3 Neo Duos I9300i Black', N'Smartphone', N'Samsung', 3999.0000, CAST(7.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (12, N'Lenovo A5000 Black', N'Smartphone', N'Lenovo', 3299.0000, CAST(5.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (13, N'Microsoft Lumia 640 XL (Nokia)', N'Smartphone', N'Nokia', 4888.0000, CAST(5.000 AS Numeric(18, 3)))
INSERT [dbo].[GoodsTemp] ([GoodId], [GoodName], [CategoryName], [ManufacturerName], [Price], [GoodCount]) VALUES (14, N'LG G3s Dual D724 Titan', N'Smartphone', N'LG', 3999.0000, CAST(0.000 AS Numeric(18, 3)))
/****** Object:  Table [dbo].[Good]    Script Date: 02/28/2018 19:01:23 ******/
