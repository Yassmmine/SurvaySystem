USE [master]
GO
/****** Object:  Database [SurvaySystem]    Script Date: 23/10/2022 9:59:27 PM ******/
CREATE DATABASE [SurvaySystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SurvaySystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SurvaySystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SurvaySystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SurvaySystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SurvaySystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SurvaySystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SurvaySystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SurvaySystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SurvaySystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SurvaySystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SurvaySystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [SurvaySystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SurvaySystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SurvaySystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SurvaySystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SurvaySystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SurvaySystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SurvaySystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SurvaySystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SurvaySystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SurvaySystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SurvaySystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SurvaySystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SurvaySystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SurvaySystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SurvaySystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SurvaySystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SurvaySystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SurvaySystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SurvaySystem] SET  MULTI_USER 
GO
ALTER DATABASE [SurvaySystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SurvaySystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SurvaySystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SurvaySystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SurvaySystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SurvaySystem] SET QUERY_STORE = OFF
GO
USE [SurvaySystem]
GO
/****** Object:  Table [dbo].[TblKPIS]    Script Date: 23/10/2022 9:59:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblKPIS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TargetValue] [int] NOT NULL,
	[MeasureUnit] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[KPIDescription] [nchar](150) NOT NULL,
 CONSTRAINT [PK_TBlKPI] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblKPIS] ON 

INSERT [dbo].[TblKPIS] ([Id], [TargetValue], [MeasureUnit], [IsDeleted], [DepartmentId], [KPIDescription]) VALUES (3007, 80, 0, 0, 1, N' description description                                                                                                                              ')
INSERT [dbo].[TblKPIS] ([Id], [TargetValue], [MeasureUnit], [IsDeleted], [DepartmentId], [KPIDescription]) VALUES (3008, 120, 1, 0, 2, N' description description                                                                                                                   44         ')
INSERT [dbo].[TblKPIS] ([Id], [TargetValue], [MeasureUnit], [IsDeleted], [DepartmentId], [KPIDescription]) VALUES (3009, 120, 1, 0, 3, N' description description                                           44                                                                                 ')
INSERT [dbo].[TblKPIS] ([Id], [TargetValue], [MeasureUnit], [IsDeleted], [DepartmentId], [KPIDescription]) VALUES (3010, 4545, 1, 0, 1, N'test                                                                                                                                                  ')
INSERT [dbo].[TblKPIS] ([Id], [TargetValue], [MeasureUnit], [IsDeleted], [DepartmentId], [KPIDescription]) VALUES (3011, 21, 1, 0, 1, N'test                                                                                                                                                  ')
INSERT [dbo].[TblKPIS] ([Id], [TargetValue], [MeasureUnit], [IsDeleted], [DepartmentId], [KPIDescription]) VALUES (3012, 1, 1, 0, 1, N'test                                                                                                                                                  ')
SET IDENTITY_INSERT [dbo].[TblKPIS] OFF
GO
USE [master]
GO
ALTER DATABASE [SurvaySystem] SET  READ_WRITE 
GO
