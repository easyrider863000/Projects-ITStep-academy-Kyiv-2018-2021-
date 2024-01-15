USE [19p31norm]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 19.08.2019 23:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentPhone]    Script Date: 19.08.2019 23:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentPhone](
	[DepartmentPhoneId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[NumperPhone] [char](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentPhoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 19.08.2019 23:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](32) NOT NULL,
	[LastName] [nvarchar](32) NOT NULL,
	[DepartmentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeePosition]    Script Date: 19.08.2019 23:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeePosition](
	[EmployeeId] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
	[Salary] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC,
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 19.08.2019 23:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (1, N'115')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (2, N'IT Department')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName]) VALUES (3, N'127')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[DepartmentPhone] ON 

INSERT [dbo].[DepartmentPhone] ([DepartmentPhoneId], [DepartmentId], [NumperPhone]) VALUES (2, 1, N'21-21-21')
INSERT [dbo].[DepartmentPhone] ([DepartmentPhoneId], [DepartmentId], [NumperPhone]) VALUES (3, 1, N'21-21-22')
INSERT [dbo].[DepartmentPhone] ([DepartmentPhoneId], [DepartmentId], [NumperPhone]) VALUES (4, 2, N'21-32-21')
INSERT [dbo].[DepartmentPhone] ([DepartmentPhoneId], [DepartmentId], [NumperPhone]) VALUES (5, 3, N'21-17-87')
SET IDENTITY_INSERT [dbo].[DepartmentPhone] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId]) VALUES (1, N'Вася', N'Пупкін', 1)
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId]) VALUES (2, N'Вова ', N'Петров', 3)
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId]) VALUES (3, N'Оксана ', N'Головач', 2)
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [DepartmentId]) VALUES (4, N'Вова ', N'Маякін', 3)
SET IDENTITY_INSERT [dbo].[Employee] OFF
INSERT [dbo].[EmployeePosition] ([EmployeeId], [PositionId], [Salary]) VALUES (1, 1, 4500.0000)
INSERT [dbo].[EmployeePosition] ([EmployeeId], [PositionId], [Salary]) VALUES (2, 1, 5000.0000)
INSERT [dbo].[EmployeePosition] ([EmployeeId], [PositionId], [Salary]) VALUES (3, 2, 3000.0000)
INSERT [dbo].[EmployeePosition] ([EmployeeId], [PositionId], [Salary]) VALUES (3, 3, 2000.0000)
INSERT [dbo].[EmployeePosition] ([EmployeeId], [PositionId], [Salary]) VALUES (4, 2, 5000.0000)
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (1, N'Інженер')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (2, N'Програміст')
INSERT [dbo].[Position] ([PositionId], [PositionName]) VALUES (3, N'Адміністратор')
SET IDENTITY_INSERT [dbo].[Position] OFF
ALTER TABLE [dbo].[EmployeePosition] ADD  DEFAULT ((0)) FOR [Salary]
GO
ALTER TABLE [dbo].[DepartmentPhone]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentPhone_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[DepartmentPhone] CHECK CONSTRAINT [FK_DepartmentPhone_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[EmployeePosition]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePosition_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeePosition] CHECK CONSTRAINT [FK_EmployeePosition_Employee]
GO
ALTER TABLE [dbo].[EmployeePosition]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePosition_Position] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[EmployeePosition] CHECK CONSTRAINT [FK_EmployeePosition_Position]
GO
