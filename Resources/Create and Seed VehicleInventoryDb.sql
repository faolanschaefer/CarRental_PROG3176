USE [VehicleInventoryDb]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vehicle_8878889]') AND type in (N'U'))
ALTER TABLE [dbo].[Vehicle_8878889] DROP CONSTRAINT IF EXISTS [FK_Vehicle_VehicleType]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory_8878889]') AND type in (N'U'))
ALTER TABLE [dbo].[Inventory_8878889] DROP CONSTRAINT IF EXISTS [FK_Inventory_VehicleStatus]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory_8878889]') AND type in (N'U'))
ALTER TABLE [dbo].[Inventory_8878889] DROP CONSTRAINT IF EXISTS [FK_Inventory_VehicleLocation]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory_8878889]') AND type in (N'U'))
ALTER TABLE [dbo].[Inventory_8878889] DROP CONSTRAINT IF EXISTS [FK_Inventory_Vehicle]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inventory_8878889]') AND type in (N'U'))
ALTER TABLE [dbo].[Inventory_8878889] DROP CONSTRAINT IF EXISTS [DF__Inventory__LastU__74AE54BC]
GO
/****** Object:  Index [UQ__VehicleT__737584F61253212D]    Script Date: 2026-02-03 11:11:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleType_8878889]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleType_8878889] DROP CONSTRAINT IF EXISTS [UQ__VehicleT__737584F61253212D]
GO
/****** Object:  Index [UQ__VehicleS__737584F697EFE4BF]    Script Date: 2026-02-03 11:11:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleStatus_8878889]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleStatus_8878889] DROP CONSTRAINT IF EXISTS [UQ__VehicleS__737584F697EFE4BF]
GO
/****** Object:  Index [UQ__VehicleL__737584F65980E5BE]    Script Date: 2026-02-03 11:11:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VehicleLocation_8878889]') AND type in (N'U'))
ALTER TABLE [dbo].[VehicleLocation_8878889] DROP CONSTRAINT IF EXISTS [UQ__VehicleL__737584F65980E5BE]
GO
/****** Object:  Table [dbo].[VehicleType_8878889]    Script Date: 2026-02-03 11:11:41 PM ******/
DROP TABLE IF EXISTS [dbo].[VehicleType_8878889]
GO
/****** Object:  Table [dbo].[VehicleStatus_8878889]    Script Date: 2026-02-03 11:11:41 PM ******/
DROP TABLE IF EXISTS [dbo].[VehicleStatus_8878889]
GO
/****** Object:  Table [dbo].[VehicleLocation_8878889]    Script Date: 2026-02-03 11:11:41 PM ******/
DROP TABLE IF EXISTS [dbo].[VehicleLocation_8878889]
GO
/****** Object:  Table [dbo].[Vehicle_8878889]    Script Date: 2026-02-03 11:11:41 PM ******/
DROP TABLE IF EXISTS [dbo].[Vehicle_8878889]
GO
/****** Object:  Table [dbo].[Inventory_8878889]    Script Date: 2026-02-03 11:11:41 PM ******/
DROP TABLE IF EXISTS [dbo].[Inventory_8878889]
GO
/****** Object:  Table [dbo].[Inventory_8878889]    Script Date: 2026-02-03 11:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory_8878889](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[VehicleLocationId] [int] NOT NULL,
	[VehicleStatusId] [int] NOT NULL,
	[LastUpdated] [datetime2](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle_8878889]    Script Date: 2026-02-03 11:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle_8878889](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[VehicleTypeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleLocation_8878889]    Script Date: 2026-02-03 11:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleLocation_8878889](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleStatus_8878889]    Script Date: 2026-02-03 11:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleStatus_8878889](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleType_8878889]    Script Date: 2026-02-03 11:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleType_8878889](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Inventory_8878889] ON 
GO
INSERT [dbo].[Inventory_8878889] ([Id], [VehicleId], [VehicleLocationId], [VehicleStatusId], [LastUpdated]) VALUES (1, 1, 1, 1, CAST(N'2026-02-01T18:38:44.5689735' AS DateTime2))
GO
INSERT [dbo].[Inventory_8878889] ([Id], [VehicleId], [VehicleLocationId], [VehicleStatusId], [LastUpdated]) VALUES (2, 2, 1, 2, CAST(N'2026-02-01T18:38:44.5689735' AS DateTime2))
GO
INSERT [dbo].[Inventory_8878889] ([Id], [VehicleId], [VehicleLocationId], [VehicleStatusId], [LastUpdated]) VALUES (3, 3, 2, 1, CAST(N'2026-02-01T18:38:44.5689735' AS DateTime2))
GO
INSERT [dbo].[Inventory_8878889] ([Id], [VehicleId], [VehicleLocationId], [VehicleStatusId], [LastUpdated]) VALUES (4, 4, 2, 3, CAST(N'2026-02-01T18:38:44.5689735' AS DateTime2))
GO
INSERT [dbo].[Inventory_8878889] ([Id], [VehicleId], [VehicleLocationId], [VehicleStatusId], [LastUpdated]) VALUES (5, 5, 3, 1, CAST(N'2026-02-01T18:38:44.5689735' AS DateTime2))
GO
INSERT [dbo].[Inventory_8878889] ([Id], [VehicleId], [VehicleLocationId], [VehicleStatusId], [LastUpdated]) VALUES (6, 6, 3, 4, CAST(N'2026-02-01T18:38:44.5689735' AS DateTime2))
GO
INSERT [dbo].[Inventory_8878889] ([Id], [VehicleId], [VehicleLocationId], [VehicleStatusId], [LastUpdated]) VALUES (7, 1, 4, 1, CAST(N'2026-02-01T18:38:44.5689735' AS DateTime2))
GO
INSERT [dbo].[Inventory_8878889] ([Id], [VehicleId], [VehicleLocationId], [VehicleStatusId], [LastUpdated]) VALUES (8, 2, 4, 2, CAST(N'2026-02-01T18:38:44.5689735' AS DateTime2))
GO
INSERT [dbo].[Inventory_8878889] ([Id], [VehicleId], [VehicleLocationId], [VehicleStatusId], [LastUpdated]) VALUES (9, 3, 1, 1, CAST(N'2026-02-01T18:38:44.5689735' AS DateTime2))
GO
INSERT [dbo].[Inventory_8878889] ([Id], [VehicleId], [VehicleLocationId], [VehicleStatusId], [LastUpdated]) VALUES (10, 4, 2, 3, CAST(N'2026-02-01T18:38:44.5689735' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Inventory_8878889] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicle_8878889] ON 
GO
INSERT [dbo].[Vehicle_8878889] ([Id], [Make], [Model], [VehicleTypeId]) VALUES (1, N'Toyota', N'Camry', 1)
GO
INSERT [dbo].[Vehicle_8878889] ([Id], [Make], [Model], [VehicleTypeId]) VALUES (2, N'Honda', N'Civic', 1)
GO
INSERT [dbo].[Vehicle_8878889] ([Id], [Make], [Model], [VehicleTypeId]) VALUES (3, N'Ford', N'Escape', 2)
GO
INSERT [dbo].[Vehicle_8878889] ([Id], [Make], [Model], [VehicleTypeId]) VALUES (4, N'Toyota', N'RAV4', 2)
GO
INSERT [dbo].[Vehicle_8878889] ([Id], [Make], [Model], [VehicleTypeId]) VALUES (5, N'Ford', N'F-150', 3)
GO
INSERT [dbo].[Vehicle_8878889] ([Id], [Make], [Model], [VehicleTypeId]) VALUES (6, N'Chevy', N'Express', 4)
GO
SET IDENTITY_INSERT [dbo].[Vehicle_8878889] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleLocation_8878889] ON 
GO
INSERT [dbo].[VehicleLocation_8878889] ([Id], [Name]) VALUES (3, N'Cambridge')
GO
INSERT [dbo].[VehicleLocation_8878889] ([Id], [Name]) VALUES (4, N'Guelph')
GO
INSERT [dbo].[VehicleLocation_8878889] ([Id], [Name]) VALUES (1, N'Kitchener')
GO
INSERT [dbo].[VehicleLocation_8878889] ([Id], [Name]) VALUES (2, N'Waterloo')
GO
SET IDENTITY_INSERT [dbo].[VehicleLocation_8878889] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleStatus_8878889] ON 
GO
INSERT [dbo].[VehicleStatus_8878889] ([Id], [Name]) VALUES (1, N'Available')
GO
INSERT [dbo].[VehicleStatus_8878889] ([Id], [Name]) VALUES (4, N'Maintenance')
GO
INSERT [dbo].[VehicleStatus_8878889] ([Id], [Name]) VALUES (3, N'Rented')
GO
INSERT [dbo].[VehicleStatus_8878889] ([Id], [Name]) VALUES (2, N'Reserved')
GO
SET IDENTITY_INSERT [dbo].[VehicleStatus_8878889] OFF
GO
SET IDENTITY_INSERT [dbo].[VehicleType_8878889] ON 
GO
INSERT [dbo].[VehicleType_8878889] ([Id], [Name]) VALUES (1, N'Sedan')
GO
INSERT [dbo].[VehicleType_8878889] ([Id], [Name]) VALUES (2, N'SUV')
GO
INSERT [dbo].[VehicleType_8878889] ([Id], [Name]) VALUES (3, N'Truck')
GO
INSERT [dbo].[VehicleType_8878889] ([Id], [Name]) VALUES (4, N'Van')
GO
SET IDENTITY_INSERT [dbo].[VehicleType_8878889] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VehicleL__737584F65980E5BE]    Script Date: 2026-02-03 11:11:41 PM ******/
ALTER TABLE [dbo].[VehicleLocation_8878889] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VehicleS__737584F697EFE4BF]    Script Date: 2026-02-03 11:11:41 PM ******/
ALTER TABLE [dbo].[VehicleStatus_8878889] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__VehicleT__737584F61253212D]    Script Date: 2026-02-03 11:11:41 PM ******/
ALTER TABLE [dbo].[VehicleType_8878889] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inventory_8878889] ADD  DEFAULT (sysdatetime()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[Inventory_8878889]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Vehicle] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicle_8878889] ([Id])
GO
ALTER TABLE [dbo].[Inventory_8878889] CHECK CONSTRAINT [FK_Inventory_Vehicle]
GO
ALTER TABLE [dbo].[Inventory_8878889]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_VehicleLocation] FOREIGN KEY([VehicleLocationId])
REFERENCES [dbo].[VehicleLocation_8878889] ([Id])
GO
ALTER TABLE [dbo].[Inventory_8878889] CHECK CONSTRAINT [FK_Inventory_VehicleLocation]
GO
ALTER TABLE [dbo].[Inventory_8878889]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_VehicleStatus] FOREIGN KEY([VehicleStatusId])
REFERENCES [dbo].[VehicleStatus_8878889] ([Id])
GO
ALTER TABLE [dbo].[Inventory_8878889] CHECK CONSTRAINT [FK_Inventory_VehicleStatus]
GO
ALTER TABLE [dbo].[Vehicle_8878889]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_VehicleType] FOREIGN KEY([VehicleTypeId])
REFERENCES [dbo].[VehicleType_8878889] ([Id])
GO
ALTER TABLE [dbo].[Vehicle_8878889] CHECK CONSTRAINT [FK_Vehicle_VehicleType]
GO
