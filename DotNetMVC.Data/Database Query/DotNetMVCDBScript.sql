USE [master]
GO
/****** Object:  Database [DotNetMVC]    Script Date: 5/9/2020 9:15:50 AM ******/
CREATE DATABASE [DotNetMVC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DotNetMVC', FILENAME = N'C:\Program Files\Microsoft SQL Server17\MSSQL14.MSSQLSERVER17\MSSQL\DATA\DotNetMVC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DotNetMVC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server17\MSSQL14.MSSQLSERVER17\MSSQL\DATA\DotNetMVC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DotNetMVC] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DotNetMVC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DotNetMVC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DotNetMVC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DotNetMVC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DotNetMVC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DotNetMVC] SET ARITHABORT OFF 
GO
ALTER DATABASE [DotNetMVC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DotNetMVC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DotNetMVC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DotNetMVC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DotNetMVC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DotNetMVC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DotNetMVC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DotNetMVC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DotNetMVC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DotNetMVC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DotNetMVC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DotNetMVC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DotNetMVC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DotNetMVC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DotNetMVC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DotNetMVC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DotNetMVC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DotNetMVC] SET RECOVERY FULL 
GO
ALTER DATABASE [DotNetMVC] SET  MULTI_USER 
GO
ALTER DATABASE [DotNetMVC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DotNetMVC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DotNetMVC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DotNetMVC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DotNetMVC] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DotNetMVC', N'ON'
GO
ALTER DATABASE [DotNetMVC] SET QUERY_STORE = OFF
GO
USE [DotNetMVC]
GO
/****** Object:  Table [dbo].[AcadamicMaster]    Script Date: 5/9/2020 9:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcadamicMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CollageName] [nvarchar](200) NOT NULL,
	[FromYear] [datetime] NOT NULL,
	[ToYear] [datetime] NOT NULL,
	[CourseName] [nvarchar](200) NOT NULL,
	[Semester] [nvarchar](200) NOT NULL,
	[Credit] [decimal](18, 0) NOT NULL,
	[Grade] [nvarchar](10) NOT NULL,
	[StudentId] [int] NOT NULL,
 CONSTRAINT [PK_AcadamicMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CollageMaster]    Script Date: 5/9/2020 9:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CollageMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CollageName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_CollageMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 5/9/2020 9:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfileMaster]    Script Date: 5/9/2020 9:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfileMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[Gender] [nvarchar](200) NOT NULL,
	[DOB] [datetime] NOT NULL,
	[CollageId] [int] NOT NULL,
	[YOG] [int] NOT NULL,
 CONSTRAINT [PK_UserProfile_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AcadamicMaster] ON 

INSERT [dbo].[AcadamicMaster] ([Id], [CollageName], [FromYear], [ToYear], [CourseName], [Semester], [Credit], [Grade], [StudentId]) VALUES (7, N'NSIT', CAST(N'2020-05-15T00:00:00.000' AS DateTime), CAST(N'2020-05-22T00:00:00.000' AS DateTime), N'ccx', N'Semester - 1', CAST(123 AS Decimal(18, 0)), N'A', 6)
SET IDENTITY_INSERT [dbo].[AcadamicMaster] OFF
SET IDENTITY_INSERT [dbo].[CollageMaster] ON 

INSERT [dbo].[CollageMaster] ([Id], [CollageName]) VALUES (1, N'IGNOU')
INSERT [dbo].[CollageMaster] ([Id], [CollageName]) VALUES (2, N'NSIT')
INSERT [dbo].[CollageMaster] ([Id], [CollageName]) VALUES (3, N'DTU')
SET IDENTITY_INSERT [dbo].[CollageMaster] OFF
SET IDENTITY_INSERT [dbo].[UserMaster] ON 

INSERT [dbo].[UserMaster] ([Id], [Email], [Password]) VALUES (6, N'sagarkumar2499@gmail.com', N'123')
INSERT [dbo].[UserMaster] ([Id], [Email], [Password]) VALUES (7, N'rkumargw@hotmail.com', N'123')
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
SET IDENTITY_INSERT [dbo].[UserProfileMaster] ON 

INSERT [dbo].[UserProfileMaster] ([Id], [StudentId], [FirstName], [LastName], [Gender], [DOB], [CollageId], [YOG]) VALUES (5, 6, N'Sagar', N'Kumar', N'Female', CAST(N'2020-05-13T00:00:00.000' AS DateTime), 2, 2020)
INSERT [dbo].[UserProfileMaster] ([Id], [StudentId], [FirstName], [LastName], [Gender], [DOB], [CollageId], [YOG]) VALUES (6, 7, N'', N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[UserProfileMaster] OFF
ALTER TABLE [dbo].[AcadamicMaster]  WITH CHECK ADD  CONSTRAINT [FK_AcadamicMaster_UserMaster] FOREIGN KEY([StudentId])
REFERENCES [dbo].[UserMaster] ([Id])
GO
ALTER TABLE [dbo].[AcadamicMaster] CHECK CONSTRAINT [FK_AcadamicMaster_UserMaster]
GO
ALTER TABLE [dbo].[UserProfileMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserProfileMaster_CollageMaster] FOREIGN KEY([CollageId])
REFERENCES [dbo].[CollageMaster] ([Id])
GO
ALTER TABLE [dbo].[UserProfileMaster] CHECK CONSTRAINT [FK_UserProfileMaster_CollageMaster]
GO
ALTER TABLE [dbo].[UserProfileMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserProfileMaster_UserMaster] FOREIGN KEY([StudentId])
REFERENCES [dbo].[UserMaster] ([Id])
GO
ALTER TABLE [dbo].[UserProfileMaster] CHECK CONSTRAINT [FK_UserProfileMaster_UserMaster]
GO
USE [master]
GO
ALTER DATABASE [DotNetMVC] SET  READ_WRITE 
GO
