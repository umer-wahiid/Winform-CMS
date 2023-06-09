USE [master]
GO
/****** Object:  Database [shakeel_brothers]    Script Date: 12/15/2022 7:19:00 PM ******/
CREATE DATABASE [shakeel_brothers]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'shakeel_brothers', FILENAME = N'D:\SQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\shakeel_brothers.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'shakeel_brothers_log', FILENAME = N'D:\SQL\MSSQL15.MSSQLSERVER\MSSQL\DATA\shakeel_brothers_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [shakeel_brothers] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [shakeel_brothers].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [shakeel_brothers] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [shakeel_brothers] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [shakeel_brothers] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [shakeel_brothers] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [shakeel_brothers] SET ARITHABORT OFF 
GO
ALTER DATABASE [shakeel_brothers] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [shakeel_brothers] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [shakeel_brothers] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [shakeel_brothers] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [shakeel_brothers] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [shakeel_brothers] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [shakeel_brothers] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [shakeel_brothers] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [shakeel_brothers] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [shakeel_brothers] SET  ENABLE_BROKER 
GO
ALTER DATABASE [shakeel_brothers] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [shakeel_brothers] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [shakeel_brothers] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [shakeel_brothers] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [shakeel_brothers] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [shakeel_brothers] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [shakeel_brothers] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [shakeel_brothers] SET RECOVERY FULL 
GO
ALTER DATABASE [shakeel_brothers] SET  MULTI_USER 
GO
ALTER DATABASE [shakeel_brothers] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [shakeel_brothers] SET DB_CHAINING OFF 
GO
ALTER DATABASE [shakeel_brothers] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [shakeel_brothers] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [shakeel_brothers] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [shakeel_brothers] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'shakeel_brothers', N'ON'
GO
ALTER DATABASE [shakeel_brothers] SET QUERY_STORE = OFF
GO
USE [shakeel_brothers]
GO
/****** Object:  Table [dbo].[tblArea]    Script Date: 12/15/2022 7:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblArea](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Area] [varchar](35) NOT NULL,
	[UArea] [varchar](30) NOT NULL,
	[City] [int] NULL,
	[UCity] [varchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCashier]    Script Date: 12/15/2022 7:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCashier](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Cashier] [varchar](30) NOT NULL,
	[Password] [varchar](30) NOT NULL,
	[Role] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCity]    Script Date: 12/15/2022 7:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](25) NOT NULL,
	[UCity] [varchar](30) NOT NULL,
	[Country] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPacking]    Script Date: 12/15/2022 7:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPacking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Packing] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRawMaterial]    Script Date: 12/15/2022 7:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRawMaterial](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RawName] [varchar](40) NULL,
	[URawName] [varchar](40) NULL,
	[Packing] [varchar](25) NULL,
	[UPacking] [varchar](25) NULL,
	[PQty] [int] NULL,
	[Measure] [varchar](25) NULL,
	[PRate] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblReceiver]    Script Date: 12/15/2022 7:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblReceiver](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Receiver] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSupplier]    Script Date: 12/15/2022 7:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSupplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Supplier] [varchar](25) NOT NULL,
	[USupplier] [varchar](30) NOT NULL,
	[ContactPerson] [varchar](30) NULL,
	[Address] [varchar](30) NULL,
	[Ph] [varchar](30) NULL,
	[Fax] [varchar](30) NULL,
	[Email] [varchar](40) NULL,
	[City] [int] NULL,
	[Limit] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTransactions]    Script Date: 12/15/2022 7:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransactions](
	[TID] [int] IDENTITY(1,1) NOT NULL,
	[TDate] [date] NOT NULL,
	[TTime] [time](7) NULL,
	[BillNum] [varchar](30) NULL,
	[Supplier] [int] NULL,
	[Debit] [int] NULL,
	[Select] [varchar](30) NULL,
	[Description] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTransDetails]    Script Date: 12/15/2022 7:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TID] [int] NULL,
	[DDate] [date] NOT NULL,
	[DTime] [time](7) NULL,
	[RawMaterial] [int] NULL,
	[Qty] [int] NULL,
	[Rate] [int] NULL,
	[Nag] [int] NULL,
	[Bilty] [varchar](25) NULL,
	[Transport] [int] NULL,
	[Labour] [int] NULL,
	[Bardan] [int] NULL,
	[User] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTransport]    Script Date: 12/15/2022 7:19:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTransport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Transport] [varchar](30) NOT NULL,
	[UTransport] [varchar](30) NOT NULL,
	[Tport Ph] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblArea]  WITH CHECK ADD FOREIGN KEY([City])
REFERENCES [dbo].[tblCity] ([ID])
GO
ALTER TABLE [dbo].[tblSupplier]  WITH CHECK ADD FOREIGN KEY([City])
REFERENCES [dbo].[tblCity] ([ID])
GO
ALTER TABLE [dbo].[tblTransactions]  WITH CHECK ADD FOREIGN KEY([Supplier])
REFERENCES [dbo].[tblSupplier] ([Id])
GO
ALTER TABLE [dbo].[tblTransDetails]  WITH CHECK ADD FOREIGN KEY([RawMaterial])
REFERENCES [dbo].[tblRawMaterial] ([Id])
GO
ALTER TABLE [dbo].[tblTransDetails]  WITH CHECK ADD FOREIGN KEY([Transport])
REFERENCES [dbo].[tblTransport] ([ID])
GO
ALTER TABLE [dbo].[tblTransDetails]  WITH CHECK ADD FOREIGN KEY([TID])
REFERENCES [dbo].[tblTransactions] ([TID])
GO
USE [master]
GO
ALTER DATABASE [shakeel_brothers] SET  READ_WRITE 
GO
