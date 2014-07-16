USE [master]
GO

/****** Object:  Database [PMP_Extension]    Script Date: 7/16/2014 9:32:43 AM ******/
DROP DATABASE [PMP_Extension]
GO

/****** Object:  Database [PMP_Extension]    Script Date: 7/16/2014 9:32:43 AM ******/
CREATE DATABASE [PMP_Extension]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PMP_Extension', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PMP_Extension.mdf' , SIZE = 8256KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PMP_Extension_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PMP_Extension.ldf' , SIZE = 20096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [PMP_Extension] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PMP_Extension].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [PMP_Extension] SET ANSI_NULL_DEFAULT ON 
GO

ALTER DATABASE [PMP_Extension] SET ANSI_NULLS ON 
GO

ALTER DATABASE [PMP_Extension] SET ANSI_PADDING ON 
GO

ALTER DATABASE [PMP_Extension] SET ANSI_WARNINGS ON 
GO

ALTER DATABASE [PMP_Extension] SET ARITHABORT ON 
GO

ALTER DATABASE [PMP_Extension] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PMP_Extension] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [PMP_Extension] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PMP_Extension] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PMP_Extension] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PMP_Extension] SET CURSOR_DEFAULT  LOCAL 
GO

ALTER DATABASE [PMP_Extension] SET CONCAT_NULL_YIELDS_NULL ON 
GO

ALTER DATABASE [PMP_Extension] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PMP_Extension] SET QUOTED_IDENTIFIER ON 
GO

ALTER DATABASE [PMP_Extension] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PMP_Extension] SET  DISABLE_BROKER 
GO

ALTER DATABASE [PMP_Extension] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PMP_Extension] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PMP_Extension] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PMP_Extension] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PMP_Extension] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PMP_Extension] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PMP_Extension] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PMP_Extension] SET RECOVERY FULL 
GO

ALTER DATABASE [PMP_Extension] SET  MULTI_USER 
GO

ALTER DATABASE [PMP_Extension] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PMP_Extension] SET DB_CHAINING OFF 
GO

ALTER DATABASE [PMP_Extension] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [PMP_Extension] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [PMP_Extension] SET  READ_WRITE 
GO

USE [PMP_Extension]
GO
-- ==================================================================
-- VIEWS
-- ==================================================================


/****** Object:  View [dbo].[rpt_client_project_hours]    Script Date: 7/16/2014 9:51:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[rpt_client_project_hours]
AS 
SELECT 
*
FROM [PMP].[rpt].[vw_client_time_report]
GO

-- ==================================================================
-- Stored Proceudres 
-- ==================================================================
USE [PMP_Extension]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		RWhitten
-- Create date: 07/16/2014
-- Description:	Client Project Hours Report
-- =============================================
CREATE PROCEDURE [dbo].[sp_rpt_client_project_hours]
	@OrganizationName VARCHAR(150) = '/',
	@StartDate		  DATETIME,
	@EndDate		  DATETIME
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [week_name]
		  ,[day_of_week]
		  ,[day_name]
		  ,[begin_date]
		  ,[end_date]
		  ,[date]
		  ,[age]
		  ,[created_on]
		  ,[latency]
		  ,[user_name]
		  ,[actual_user]
		  ,[company_name]
		  ,[project_name]
		  ,[parent_name]
		  ,[billable_hours]
		  ,[unbillable_hours]
		  ,[total_hours]
	  FROM [dbo].[rpt_client_project_hours]

	  WHERE 
		([company_name] = @OrganizationName)
	  AND 
		([date] BETWEEN @StartDate AND @EndDate) 

END
GO

