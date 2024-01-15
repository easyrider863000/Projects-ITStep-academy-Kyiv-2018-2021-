USE [Music]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 22.08.2019 0:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] NOT NULL,
	[Cname] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Disks]    Script Date: 22.08.2019 0:45:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Disks](
	[DiskId] [int] NOT NULL,
	[DiskName] [nvarchar](30) NULL,
	[SongerId] [int] NOT NULL,
	[DateOfIssue] [date] NULL,
	[StyleId] [int] NOT NULL,
	[PublisherId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DiskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 22.08.2019 0:45:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[PublisherId] [int] NOT NULL,
	[Pname] [nvarchar](30) NULL,
	[CountryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Songers]    Script Date: 22.08.2019 0:45:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songers](
	[SongerId] [int] NOT NULL,
	[Sname] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[SongerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Songs]    Script Date: 22.08.2019 0:45:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[SongId] [int] NOT NULL,
	[DiskId] [int] NOT NULL,
	[SongName] [nvarchar](100) NULL,
	[SongLength] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Styles]    Script Date: 22.08.2019 0:45:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Styles](
	[StyleId] [int] NOT NULL,
	[SName] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[StyleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Countries] ([CountryId], [Cname]) VALUES (1, N'USA')
INSERT [dbo].[Countries] ([CountryId], [Cname]) VALUES (2, N'Asia')
INSERT [dbo].[Disks] ([DiskId], [DiskName], [SongerId], [DateOfIssue], [StyleId], [PublisherId]) VALUES (1, N'Burn', 1, CAST(N'2017-02-02' AS Date), 1, 1)
INSERT [dbo].[Disks] ([DiskId], [DiskName], [SongerId], [DateOfIssue], [StyleId], [PublisherId]) VALUES (2, N'Hello', 3, CAST(N'2007-01-02' AS Date), 2, 2)
INSERT [dbo].[Disks] ([DiskId], [DiskName], [SongerId], [DateOfIssue], [StyleId], [PublisherId]) VALUES (3, N'MySolo', 2, CAST(N'2013-01-02' AS Date), 2, 1)
INSERT [dbo].[Publishers] ([PublisherId], [Pname], [CountryId]) VALUES (1, N'qwerty', 2)
INSERT [dbo].[Publishers] ([PublisherId], [Pname], [CountryId]) VALUES (2, N'production', 1)
INSERT [dbo].[Publishers] ([PublisherId], [Pname], [CountryId]) VALUES (3, N'entertaimant', 1)
INSERT [dbo].[Songers] ([SongerId], [Sname]) VALUES (1, N'Eminem')
INSERT [dbo].[Songers] ([SongerId], [Sname]) VALUES (2, N'ACDC')
INSERT [dbo].[Songers] ([SongerId], [Sname]) VALUES (3, N'Nirvana')
INSERT [dbo].[Songs] ([SongId], [DiskId], [SongName], [SongLength]) VALUES (1, 1, N'Vasyakolk', 1)
INSERT [dbo].[Songs] ([SongId], [DiskId], [SongName], [SongLength]) VALUES (2, 3, N'What', 3)
INSERT [dbo].[Songs] ([SongId], [DiskId], [SongName], [SongLength]) VALUES (3, 1, N'hello', 2)
INSERT [dbo].[Songs] ([SongId], [DiskId], [SongName], [SongLength]) VALUES (4, 2, N'Andry ', 1)
INSERT [dbo].[Songs] ([SongId], [DiskId], [SongName], [SongLength]) VALUES (5, 2, N'Adsgvrgtefrt ', 3)
INSERT [dbo].[Styles] ([StyleId], [SName]) VALUES (1, N'Pop')
INSERT [dbo].[Styles] ([StyleId], [SName]) VALUES (2, N'Trap')
INSERT [dbo].[Styles] ([StyleId], [SName]) VALUES (3, N'Rap')
ALTER TABLE [dbo].[Disks]  WITH CHECK ADD  CONSTRAINT [FK_Disks_Publishers] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([PublisherId])
GO
ALTER TABLE [dbo].[Disks] CHECK CONSTRAINT [FK_Disks_Publishers]
GO
ALTER TABLE [dbo].[Disks]  WITH CHECK ADD  CONSTRAINT [FK_Disks_Songers] FOREIGN KEY([SongerId])
REFERENCES [dbo].[Songers] ([SongerId])
GO
ALTER TABLE [dbo].[Disks] CHECK CONSTRAINT [FK_Disks_Songers]
GO
ALTER TABLE [dbo].[Disks]  WITH CHECK ADD  CONSTRAINT [FK_Disks_Styles] FOREIGN KEY([StyleId])
REFERENCES [dbo].[Styles] ([StyleId])
GO
ALTER TABLE [dbo].[Disks] CHECK CONSTRAINT [FK_Disks_Styles]
GO
ALTER TABLE [dbo].[Publishers]  WITH CHECK ADD  CONSTRAINT [FK_Publishers_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Publishers] CHECK CONSTRAINT [FK_Publishers_Countries]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Disks] FOREIGN KEY([DiskId])
REFERENCES [dbo].[Disks] ([DiskId])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Disks]
GO
