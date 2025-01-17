
CREATE DATABASE RENTALMASTER

USE RENTALMASTER;

CREATE TABLE [dbo].[AdminMaster](
	[Adm_Id] [int] IDENTITY(1,1) NOT NULL,
	[Admin_Name] [varchar](50) NULL,
	[Email] [varchar](20) NULL,
	[Password] [varchar](50) NULL,
	[Mobile_No] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Adm_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingMaster]    Script Date: 05-05-2024 12:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingMaster](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[ExtraHours] [int] NULL,
	[TotalHours] [int] NULL,
	[BookingDate] [date] NULL,
	[IsActice] [bit] NULL,
	[BookingStatus] [varchar](50) NULL,
	[LicenseNumber] [varchar](50) NULL,
	[BookingLastDate] [date] NULL,
	[CreatedDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BrandMaster]    Script Date: 05-05-2024 12:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrandMaster](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarMaster]    Script Date: 05-05-2024 12:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarMaster](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[Car_Title] [nvarchar](50) NULL,
	[Car_Description] [nvarchar](150) NULL,
	[Price] [decimal](18, 2) NULL,
	[Brand] [nchar](10) NULL,
	[Model_Year] [int] NULL,
	[Seating_Capacity] [int] NULL,
	[Fuel_Type] [nvarchar](50) NULL,
	[Car_img1] [nvarchar](50) NULL,
	[Car_img2] [nvarchar](50) NULL,
	[Car_img3] [nvarchar](50) NULL,
	[Car_Color] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[Is_Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CostMaster]    Script Date: 05-05-2024 12:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostMaster](
	[CostId] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Name] [varchar](50) NULL,
	[Booking_No] [varchar](50) NULL,
	[Issue_Type] [varchar](50) NULL,
	[Charges] [decimal](18, 2) NULL,
	[Description] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerMaster]    Script Date: 05-05-2024 12:48:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerMaster](
	[Cust_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cust_Name] [varchar](50) NULL,
	[Email] [varchar](20) NULL,
	[Password] [varchar](50) NULL,
	[Mobile_No] [varchar](50) NULL,
	[Address] [varchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cust_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AdminMaster] ON 

INSERT [dbo].[AdminMaster] ([Adm_Id], [Admin_Name], [Email], [Password], [Mobile_No], [Address], [CreatedDate], [IsActive]) VALUES (1, N'raj', N'raj@gmail.com', N'123', N'73576576576', N'Nagpur', CAST(N'2024-01-07T17:16:10.803' AS DateTime), 1)
INSERT [dbo].[AdminMaster] ([Adm_Id], [Admin_Name], [Email], [Password], [Mobile_No], [Address], [CreatedDate], [IsActive]) VALUES (2, N'admin', N'admin@gmail.com', N'123', N'73576576576', N'Nagpur', CAST(N'2024-01-07T17:17:12.573' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[AdminMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[BookingMaster] ON 

INSERT [dbo].[BookingMaster] ([BookingId], [CarId], [CustomerId], [Price], [TotalPrice], [ExtraHours], [TotalHours], [BookingDate], [IsActice], [BookingStatus], [LicenseNumber], [BookingLastDate], [CreatedDate], [ReturnDate]) VALUES (1, 2, 1, CAST(1000.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), NULL, 3, CAST(N'2024-03-06' AS Date), 1, N'Returned', N'tdgdf', CAST(N'2024-03-09' AS Date), CAST(N'2024-03-06T10:04:43.773' AS DateTime), CAST(N'2024-03-17T15:54:44.877' AS DateTime))
INSERT [dbo].[BookingMaster] ([BookingId], [CarId], [CustomerId], [Price], [TotalPrice], [ExtraHours], [TotalHours], [BookingDate], [IsActice], [BookingStatus], [LicenseNumber], [BookingLastDate], [CreatedDate], [ReturnDate]) VALUES (2, 2, 2, CAST(1000.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), NULL, 3, CAST(N'2024-04-07' AS Date), 1, N'Returned', N'dfgdgg', CAST(N'2024-04-10' AS Date), CAST(N'2024-04-06T16:22:47.903' AS DateTime), CAST(N'2024-04-07T23:02:43.547' AS DateTime))
INSERT [dbo].[BookingMaster] ([BookingId], [CarId], [CustomerId], [Price], [TotalPrice], [ExtraHours], [TotalHours], [BookingDate], [IsActice], [BookingStatus], [LicenseNumber], [BookingLastDate], [CreatedDate], [ReturnDate]) VALUES (3, 1, 3, CAST(1000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)), NULL, 2, CAST(N'2024-04-08' AS Date), 1, N'Returned', N'MH-42-1998-9876543', CAST(N'2024-04-10' AS Date), CAST(N'2024-04-07T20:05:50.127' AS DateTime), CAST(N'2024-04-07T23:04:14.143' AS DateTime))
INSERT [dbo].[BookingMaster] ([BookingId], [CarId], [CustomerId], [Price], [TotalPrice], [ExtraHours], [TotalHours], [BookingDate], [IsActice], [BookingStatus], [LicenseNumber], [BookingLastDate], [CreatedDate], [ReturnDate]) VALUES (4, 1, 4, CAST(1000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), NULL, 1, CAST(N'2024-04-08' AS Date), 1, N'Booked', N'MH-42-1998-9876543', CAST(N'2024-04-09' AS Date), CAST(N'2024-04-07T20:06:21.590' AS DateTime), NULL)
INSERT [dbo].[BookingMaster] ([BookingId], [CarId], [CustomerId], [Price], [TotalPrice], [ExtraHours], [TotalHours], [BookingDate], [IsActice], [BookingStatus], [LicenseNumber], [BookingLastDate], [CreatedDate], [ReturnDate]) VALUES (5, 1, 5, CAST(1000.00 AS Decimal(18, 2)), CAST(3000.00 AS Decimal(18, 2)), NULL, 3, CAST(N'2024-04-14' AS Date), 1, N'Booked', N'MH-42-1998-9876543', CAST(N'2024-04-17' AS Date), CAST(N'2024-04-07T20:30:24.090' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[BookingMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[BrandMaster] ON 

INSERT [dbo].[BrandMaster] ([BrandId], [BrandName], [CreatedDate]) VALUES (1, N'BMW', CAST(N'2024-02-27T09:13:14.827' AS DateTime))
SET IDENTITY_INSERT [dbo].[BrandMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[CarMaster] ON 

INSERT [dbo].[CarMaster] ([CarId], [Car_Title], [Car_Description], [Price], [Brand], [Model_Year], [Seating_Capacity], [Fuel_Type], [Car_img1], [Car_img2], [Car_img3], [Car_Color], [CreatedDate], [Is_Active]) VALUES (1, N'BMW i7', N'idsd', CAST(1000.00 AS Decimal(18, 2)), N'BMW       ', 1997, 3, N'Petrol', N'Images/download (2).jpg', N'Images/download.jpg', N'Images/download (1).jpg', N'red', CAST(N'2024-02-27T09:14:15.353' AS DateTime), 1)
INSERT [dbo].[CarMaster] ([CarId], [Car_Title], [Car_Description], [Price], [Brand], [Model_Year], [Seating_Capacity], [Fuel_Type], [Car_img1], [Car_img2], [Car_img3], [Car_Color], [CreatedDate], [Is_Active]) VALUES (2, N'BMW i7', N'gg', CAST(1000.00 AS Decimal(18, 2)), N'BMW       ', 1997, 3, N'Petrol', N'Images/download (2).jpg', N'Images/download.jpg', N'Images/download1.jpg', N'red', CAST(N'2024-02-27T09:16:40.573' AS DateTime), 1)
INSERT [dbo].[CarMaster] ([CarId], [Car_Title], [Car_Description], [Price], [Brand], [Model_Year], [Seating_Capacity], [Fuel_Type], [Car_img1], [Car_img2], [Car_img3], [Car_Color], [CreatedDate], [Is_Active]) VALUES (3, N'BMW i7', N'gg', CAST(1000.00 AS Decimal(18, 2)), N'BMW       ', 1997, 3, N'Petrol', N'Images/download (2).jpg', N'Images/download.jpg', N'Images/download1.jpg', N'red', CAST(N'2024-02-27T09:16:40.573' AS DateTime), 1)
INSERT [dbo].[CarMaster] ([CarId], [Car_Title], [Car_Description], [Price], [Brand], [Model_Year], [Seating_Capacity], [Fuel_Type], [Car_img1], [Car_img2], [Car_img3], [Car_Color], [CreatedDate], [Is_Active]) VALUES (4, N'BMW i7', N'fgfgf', CAST(200.00 AS Decimal(18, 2)), N'BMW       ', 1998, 3, N'Petrol', N'Images/download (2).jpg', N'Images/download.jpg', N'Images/download1.jpg', N'Blue', CAST(N'2024-02-27T09:19:55.740' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[CarMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerMaster] ON 

INSERT [dbo].[CustomerMaster] ([Cust_Id], [Cust_Name], [Email], [Password], [Mobile_No], [Address], [CreatedDate], [IsActive]) VALUES (1, N'Raj', N'raj@gmail.com', N'', N'87585857857', N'Nagpur', CAST(N'2024-03-06T10:04:43.740' AS DateTime), 1)
INSERT [dbo].[CustomerMaster] ([Cust_Id], [Cust_Name], [Email], [Password], [Mobile_No], [Address], [CreatedDate], [IsActive]) VALUES (2, N'Raj', N'raj@gmail.com', N'', N'87585857857sfgdfg', N'Nagpur', CAST(N'2024-04-06T16:22:47.887' AS DateTime), 1)
INSERT [dbo].[CustomerMaster] ([Cust_Id], [Cust_Name], [Email], [Password], [Mobile_No], [Address], [CreatedDate], [IsActive]) VALUES (3, N'Raj', N'raj@gmail.com', N'', N'8674768768', N'Nagpur', CAST(N'2024-04-07T20:05:50.117' AS DateTime), 1)
INSERT [dbo].[CustomerMaster] ([Cust_Id], [Cust_Name], [Email], [Password], [Mobile_No], [Address], [CreatedDate], [IsActive]) VALUES (4, N'Gauri', N'Gauri@gmail.com', N'', N'8674768768', N'Chandrapur', CAST(N'2024-04-07T20:06:21.587' AS DateTime), 1)
INSERT [dbo].[CustomerMaster] ([Cust_Id], [Cust_Name], [Email], [Password], [Mobile_No], [Address], [CreatedDate], [IsActive]) VALUES (5, N'Raj', N'raj@gmail.com', N'', N'8674768768', N'Nagpur', CAST(N'2024-04-07T20:30:24.080' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[CustomerMaster] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__BrandMas__2206CE9BC9F28E4F]    Script Date: 05-05-2024 12:48:34 PM ******/
ALTER TABLE [dbo].[BrandMaster] ADD UNIQUE NONCLUSTERED 
(
	[BrandName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

