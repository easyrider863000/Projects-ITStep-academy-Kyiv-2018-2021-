USE [Sotr]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 20.08.2019 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[NoDepartment] [int] NOT NULL,
	[NumberPhone] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[NoDepartment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentProject]    Script Date: 20.08.2019 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentProject](
	[NoDepartment] [int] NOT NULL,
	[NoProject] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 20.08.2019 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[NoEmployee] [int] NOT NULL,
	[Surname] [nvarchar](32) NULL,
	[NoDepartment] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NoEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 20.08.2019 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[NoProject] [int] NOT NULL,
	[PName] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[NoProject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTask]    Script Date: 20.08.2019 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTask](
	[NoProject] [int] NOT NULL,
	[NoTask] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 20.08.2019 10:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[NoTask] [int] NOT NULL,
	[TName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[NoTask] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Department] ([NoDepartment], [NumberPhone]) VALUES (1, N'11-22-33')
INSERT [dbo].[Department] ([NoDepartment], [NumberPhone]) VALUES (2, N'33-22-11')
INSERT [dbo].[DepartmentProject] ([NoDepartment], [NoProject]) VALUES (1, 1)
INSERT [dbo].[DepartmentProject] ([NoDepartment], [NoProject]) VALUES (1, 2)
INSERT [dbo].[DepartmentProject] ([NoDepartment], [NoProject]) VALUES (2, 1)
INSERT [dbo].[DepartmentProject] ([NoDepartment], [NoProject]) VALUES (2, 2)
INSERT [dbo].[Employee] ([NoEmployee], [Surname], [NoDepartment]) VALUES (1, N'Иванов', 1)
INSERT [dbo].[Employee] ([NoEmployee], [Surname], [NoDepartment]) VALUES (2, N'Петров', 1)
INSERT [dbo].[Employee] ([NoEmployee], [Surname], [NoDepartment]) VALUES (3, N'Сидоров', 2)
INSERT [dbo].[Project] ([NoProject], [PName]) VALUES (1, N'Космос')
INSERT [dbo].[Project] ([NoProject], [PName]) VALUES (2, N'Климат')
INSERT [dbo].[ProjectTask] ([NoProject], [NoTask]) VALUES (1, 1)
INSERT [dbo].[ProjectTask] ([NoProject], [NoTask]) VALUES (2, 1)
INSERT [dbo].[ProjectTask] ([NoProject], [NoTask]) VALUES (1, 2)
INSERT [dbo].[ProjectTask] ([NoProject], [NoTask]) VALUES (1, 3)
INSERT [dbo].[ProjectTask] ([NoProject], [NoTask]) VALUES (2, 2)
INSERT [dbo].[Task] ([NoTask], [TName]) VALUES (1, NULL)
INSERT [dbo].[Task] ([NoTask], [TName]) VALUES (2, NULL)
INSERT [dbo].[Task] ([NoTask], [TName]) VALUES (3, NULL)
ALTER TABLE [dbo].[DepartmentProject]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentProject_Department] FOREIGN KEY([NoDepartment])
REFERENCES [dbo].[Department] ([NoDepartment])
GO
ALTER TABLE [dbo].[DepartmentProject] CHECK CONSTRAINT [FK_DepartmentProject_Department]
GO
ALTER TABLE [dbo].[DepartmentProject]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentProject_Project] FOREIGN KEY([NoProject])
REFERENCES [dbo].[Project] ([NoProject])
GO
ALTER TABLE [dbo].[DepartmentProject] CHECK CONSTRAINT [FK_DepartmentProject_Project]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([NoDepartment])
REFERENCES [dbo].[Department] ([NoDepartment])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[ProjectTask]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTask_Project] FOREIGN KEY([NoProject])
REFERENCES [dbo].[Project] ([NoProject])
GO
ALTER TABLE [dbo].[ProjectTask] CHECK CONSTRAINT [FK_ProjectTask_Project]
GO
ALTER TABLE [dbo].[ProjectTask]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTask_Task] FOREIGN KEY([NoTask])
REFERENCES [dbo].[Task] ([NoTask])
GO
ALTER TABLE [dbo].[ProjectTask] CHECK CONSTRAINT [FK_ProjectTask_Task]
GO
