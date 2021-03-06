USE [Bookstore]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 20.02.2019 11:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 20.02.2019 11:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 20.02.2019 11:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 20.02.2019 11:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 20.02.2019 11:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[FullName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 20.02.2019 11:31:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](120) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CoverImagePath] [nvarchar](500) NULL,
	[Author] [nvarchar](50) NOT NULL,
	[Condition] [nvarchar](500) NULL,
	[PublishYear] [nvarchar](15) NULL,
	[ISBN] [nvarchar](50) NULL,
	[SellerId] [nvarchar](128) NULL,
	[BuyerId] [nvarchar](128) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Offered] [bit] NULL,
	[OfferDate] [datetime2](7) NULL,
	[Description] [nvarchar](800) NULL,
	[IsDeleted] [bit] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_dbo.Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5ca3cb54-f943-423d-9e96-69dc3c34bbef', N'Admin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0a0df06d-5ed6-45b7-bda1-21fc5784073d', N'Buyer')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'c477cd97-e308-4301-8be3-034592410d69', N'Seller')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'20ab32c8-ad7d-48c5-b8ee-ad8ae648f4b2', N'0a0df06d-5ed6-45b7-bda1-21fc5784073d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'374cc22c-a5f0-4b03-8ea6-61d65e9eb07e', N'0a0df06d-5ed6-45b7-bda1-21fc5784073d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'58ea582e-b4a6-451c-9ebb-126cc50aca3f', N'0a0df06d-5ed6-45b7-bda1-21fc5784073d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'75244cf9-ac1b-4ed4-88c2-5d44c8128c63', N'0a0df06d-5ed6-45b7-bda1-21fc5784073d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ad4bb510-d4b0-4aac-a9f5-2e36c55c2421', N'0a0df06d-5ed6-45b7-bda1-21fc5784073d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'afdead6e-da05-422f-a505-f18984079a5f', N'0a0df06d-5ed6-45b7-bda1-21fc5784073d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e6697540-0761-4e18-9dbb-232cf357843d', N'0a0df06d-5ed6-45b7-bda1-21fc5784073d')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0d668976-6127-4c9f-883c-9434a282aa58', N'5ca3cb54-f943-423d-9e96-69dc3c34bbef')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd098d62a-2d6a-4da9-b36a-622a9e514634', N'c477cd97-e308-4301-8be3-034592410d69')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsDeleted], [FullName]) VALUES (N'0d668976-6127-4c9f-883c-9434a282aa58', N'admin@example.com', 1, N'AAStmyZJf+rRWzNXKBW3kDIcnZHLkPAreWyeIYFyVw2SLHG4mOzTcRgsVlAP2kKWXQ==', N'c54ca236-2993-4180-88a1-3aeb2ce690ee', NULL, 0, 0, NULL, 0, 0, N'admin@example.com', 0, N'Admin')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsDeleted], [FullName]) VALUES (N'20ab32c8-ad7d-48c5-b8ee-ad8ae648f4b2', N'buyer43@example.com', 1, N'ANetQKrr06d/K2mhpG4OoIjy+EYDsCVWDscvYqGRk26Dzoj9POGHOHKli/wuDR/1Ug==', N'5588b489-3694-44e3-bda4-f0701e7128a7', NULL, 0, 0, NULL, 0, 0, N'buyer43@example.com', 1, N'Buyer43')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsDeleted], [FullName]) VALUES (N'374cc22c-a5f0-4b03-8ea6-61d65e9eb07e', N'test@example.com', 1, N'AFdDYkGfGpXWjRoxYlLjyBhScL6K6cPu44B80ArDeEoRzzSrLhtnXoPjPdNGA+8w7A==', N'6b15796d-f0b6-41a9-aa3d-e608560ef30b', NULL, 0, 0, NULL, 0, 0, N'test@example.com', 0, N'test test')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsDeleted], [FullName]) VALUES (N'58ea582e-b4a6-451c-9ebb-126cc50aca3f', N'buyer2@example.com', 1, N'ABKW/FV+Z+dAh4J4DWnAMbtSAfs6hyxqRMNaEtwQfQF60aipmCCzjyY+v0UZwPv1eQ==', N'05d26a1c-3835-4763-b73a-a3596328a84c', NULL, 0, 0, NULL, 0, 0, N'buyer2@example.com', 1, N'Buyer2')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsDeleted], [FullName]) VALUES (N'75244cf9-ac1b-4ed4-88c2-5d44c8128c63', N'buyer@example.com', 1, N'AIK56sf/WzKc4d9NrgLY88sJi2X4Cl2UdCDRWs9u7nNpUiyoW/CXJWmOKAT9+nYGeg==', N'8ed008ca-9f9f-473b-9178-db18c74cd2fa', NULL, 0, 0, NULL, 0, 0, N'buyer@example.com', 0, N'Buyer')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsDeleted], [FullName]) VALUES (N'ad4bb510-d4b0-4aac-a9f5-2e36c55c2421', N'test2@example.com', 1, N'AHfEEXeSXU48IC5zI+yXe1s1/QuZJY9yLFSNGgN48DoACCUKTf51kBJKZ+LgGJ257g==', N'b80824a6-3ef4-44db-9599-96afc04ab76e', NULL, 0, 0, NULL, 0, 0, N'test2@example.com', 0, N'test test2')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsDeleted], [FullName]) VALUES (N'afdead6e-da05-422f-a505-f18984079a5f', N'elyor@outlook.com', 1, N'AJk0JjFAITyZur3pmkW48gn+aSUzKNhWa4cZFhHe/Fl6i1Xdq2WG3AB+zir2Bm60Ag==', N'2dbf9470-a363-4ce2-b8b8-d653a1161064', NULL, 0, 0, NULL, 0, 0, N'elyor@outlook.com', 0, N'Elyor Latipov')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsDeleted], [FullName]) VALUES (N'd098d62a-2d6a-4da9-b36a-622a9e514634', N'seller@example.com', 1, N'AD9IIcL5gZnpC2xAI5bD54vmUwi8OjO210h9zk9L+uROSPy4fDxnIZ316lpewXQVHw==', N'4ead6e83-ed9a-4f45-a4d0-73351e6c3e69', NULL, 0, 0, NULL, 0, 0, N'seller@example.com', 0, N'Seller')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [IsDeleted], [FullName]) VALUES (N'e6697540-0761-4e18-9dbb-232cf357843d', N'elyor.blog@gmail.com', 1, N'AP4yECLs9wtb5O9ihtRoHlR3upVCWblJRoIidJeY50W72OxfomxfD3TUKnSwCK6yYQ==', N'1c833c7a-b552-4d50-805a-495d57f39cc0', NULL, 0, 0, NULL, 0, 0, N'elyor.blog@gmail.com', 0, N'Elyor Latipov')
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (1, N'Harry Potter', CAST(25.00 AS Decimal(18, 2)), N'~/Images/Covers/1.jpg', N'McMillan', N'New', N'10.10.2015', N'11-22-33-44-55', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'the best book ever', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (2, N'Harry Potter 2', CAST(15.00 AS Decimal(18, 2)), N'~/Images/Covers/2.jpg', N'McMillan', N'New', N'10.10.2015', N'11-22-33-44-55', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'the best book ever', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (3, N'Harry Potter 3', CAST(25.00 AS Decimal(18, 2)), N'~/Images/Covers/3.jpg', N'McMillan', N'New', N'10.10.2015', N'11-22-33-44-55', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'the best book ever', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (4, N'Harry Potter 4', CAST(15.00 AS Decimal(18, 2)), N'~/Images/Covers/4.jpg', N'McMillan', N'New', N'10.10.2015', N'11-22-33-44-55', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'the best book ever', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (5, N'Harry Potter 5', CAST(25.00 AS Decimal(18, 2)), N'~/Images/Covers/5.jpeg', N'McMillan', N'New', N'10.10.2015', N'11-22-33-44-55', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'the best book ever', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (6, N'Lord of rings', CAST(55.00 AS Decimal(18, 2)), N'~/Images/Covers/6.jpg', N'Smith', N'New', N'10.10.2015', N'11-22-33-44-55', N'd098d62a-2d6a-4da9-b36a-622a9e514634', N'20ab32c8-ad7d-48c5-b8ee-ad8ae648f4b2', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, CAST(N'2019-02-20T11:21:03.0230943' AS DateTime2), N'the best book ever', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (7, N'From good to great', CAST(10.00 AS Decimal(18, 2)), N'~/Images/Covers/9.jpg', N'Jacobson', N'New', N'10.10.2015', N'11-22-33-44-55', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'the best book ever', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (8, N'Hobbit', CAST(100.00 AS Decimal(18, 2)), N'~/Images/Covers/7.jpg', N'Jacobson', N'New', N'10.10.2015', N'11-22-33-44-55', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'the best book ever', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (9, N'New Land', CAST(25.00 AS Decimal(18, 2)), N'~/Images/Covers/10.jpg', N'Smith', N'New', N'10.10.2015', N'11-22-33-44-55', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'the best book ever', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (10, N'Home Land', CAST(100.00 AS Decimal(18, 2)), N'~/Images/Covers/8.jpg', N'McMillon', N'New', N'10.10.2015', N'11-22-33-44-55', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, N'the best book ever', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (11, N'tedst', CAST(234.00 AS Decimal(18, 2)), N'~/Images/Covers/Tulips.jpg', N'4545454', N'New', N'10.10.2015', N'124345345', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'2019-02-19T19:06:35.6900000' AS DateTime2), NULL, NULL, N'', 0, NULL)
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (12, N'new book', CAST(23.00 AS Decimal(18, 2)), N'~/Images/Covers/Tulips.jpg', N'test test', N'Used', N'10.10.2015', N'12-12-34-45-56', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'2019-02-20T03:12:18.1268910' AS DateTime2), NULL, NULL, N'test', 0, CAST(N'2019-02-20T11:14:25.1623857' AS DateTime2))
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (13, N'test', CAST(34.00 AS Decimal(18, 2)), N'~/Images/Covers/Penguins.jpg', N'tstr', N'New', N'10.10.2015', N'3434-546-567', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'2019-02-20T03:12:35.1950801' AS DateTime2), NULL, NULL, N'sdsd', 0, CAST(N'2019-02-20T03:12:35.1950801' AS DateTime2))
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (14, N'New bok2', CAST(23.00 AS Decimal(18, 2)), N'~/Images/Covers/Penguins.jpg', N'Test', N'Used', N'2013.23.02', N'12-596-45-48', N'd098d62a-2d6a-4da9-b36a-622a9e514634', N'20ab32c8-ad7d-48c5-b8ee-ad8ae648f4b2', CAST(N'2019-02-20T11:09:56.7094384' AS DateTime2), 0, NULL, N'good book', 0, CAST(N'2019-02-20T11:19:57.7874805' AS DateTime2))
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (15, N'used book3', CAST(56.00 AS Decimal(18, 2)), N'~/Images/Covers/Koala.jpg', N'Test', N'Used', N'4/5/2017', N'232-3-23-23-2-32', N'd098d62a-2d6a-4da9-b36a-622a9e514634', N'58ea582e-b4a6-451c-9ebb-126cc50aca3f', CAST(N'2019-02-20T11:10:34.6573967' AS DateTime2), 1, CAST(N'2019-02-20T11:11:52.2741510' AS DateTime2), N'try it', 0, CAST(N'2019-02-20T11:10:34.6573967' AS DateTime2))
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (16, N'test', CAST(3.00 AS Decimal(18, 2)), N'~/Images/Covers/Penguins.jpg', N'test', N'New', N'2016', N'324-234-324324', N'd098d62a-2d6a-4da9-b36a-622a9e514634', NULL, CAST(N'2019-02-20T11:17:55.7332489' AS DateTime2), NULL, NULL, N'sdfsfdgfdg', 0, CAST(N'2019-02-20T11:17:55.7332489' AS DateTime2))
GO
INSERT [dbo].[Books] ([Id], [Name], [Price], [CoverImagePath], [Author], [Condition], [PublishYear], [ISBN], [SellerId], [BuyerId], [CreatedDate], [Offered], [OfferDate], [Description], [IsDeleted], [ModifiedDate]) VALUES (17, N'test2', CAST(34.00 AS Decimal(18, 2)), N'~/Images/Covers/Lighthouse.jpg', N'gfdgfdg', N'New', N'2018', N'2323-232-3-23-2', N'd098d62a-2d6a-4da9-b36a-622a9e514634', N'20ab32c8-ad7d-48c5-b8ee-ad8ae648f4b2', CAST(N'2019-02-20T11:18:12.8319585' AS DateTime2), 1, CAST(N'2019-02-20T11:19:21.8759161' AS DateTime2), N'test', 0, CAST(N'2019-02-20T11:18:12.8319585' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ('1900-01-01T00:00:00.000') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ((0)) FOR [Offered]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Books_dbo.AspNetUsers_BuyerId] FOREIGN KEY([BuyerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_dbo.Books_dbo.AspNetUsers_BuyerId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Books_dbo.AspNetUsers_SellerId] FOREIGN KEY([SellerId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_dbo.Books_dbo.AspNetUsers_SellerId]
GO
