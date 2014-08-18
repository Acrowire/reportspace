USE [master]
GO

/****** Object:  Database [ReportSpace]    Script Date: 8/18/2014 10:43:41 AM ******/
DROP DATABASE [ReportSpace]
GO

/****** Object:  Database [ReportSpace]    Script Date: 8/18/2014 10:43:41 AM ******/
CREATE DATABASE [ReportSpace]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReportSpace', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ReportSpace.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ReportSpace_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ReportSpace_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [ReportSpace] ADD FILEGROUP [INDEX]
GO

ALTER DATABASE [ReportSpace] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReportSpace].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ReportSpace] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ReportSpace] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ReportSpace] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ReportSpace] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ReportSpace] SET ARITHABORT OFF 
GO

ALTER DATABASE [ReportSpace] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ReportSpace] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [ReportSpace] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ReportSpace] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ReportSpace] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ReportSpace] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ReportSpace] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ReportSpace] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ReportSpace] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ReportSpace] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ReportSpace] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ReportSpace] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ReportSpace] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ReportSpace] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ReportSpace] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ReportSpace] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ReportSpace] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ReportSpace] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ReportSpace] SET RECOVERY FULL 
GO

ALTER DATABASE [ReportSpace] SET  MULTI_USER 
GO

ALTER DATABASE [ReportSpace] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ReportSpace] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ReportSpace] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ReportSpace] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [ReportSpace] SET  READ_WRITE 
GO



USE [ReportSpace]
GO
/****** Object:  StoredProcedure [dbo].[sp_Organizations_Delete]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Organizations_Delete]
(
@Id int
)
AS
BEGIN
    DELETE FROM [dbo].[Organizations]
    WHERE
        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Organizations_Insert]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Organizations_Insert]
(
@PublicId uniqueidentifier,
@Name varchar(150),
@Active bit
)
AS
BEGIN
    INSERT INTO [dbo].[Organizations]
    (
        [PublicId],
[Name],
[Active]
    )
    VALUES
    (
        @PublicId,
@Name,
@Active

    )
    Select @@identity;
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Organizations_Select_All]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Organizations_Select_All]
AS
BEGIN
    SELECT [Id],[PublicId],[Name],[Active]
    FROM [dbo].[Organizations]
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Organizations_Select_One]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Organizations_Select_One]
(
@Id int
)
AS
BEGIN
    SELECT [Id],[PublicId],[Name],[Active]
    FROM [dbo].[Organizations]
    WHERE
        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Organizations_Update]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Organizations_Update]
(
@Id int,
@PublicId uniqueidentifier,
@Name varchar(150),
@Active bit
)
AS
BEGIN
    UPDATE [dbo].[Organizations]
    SET
        [PublicId]=@PublicId,
        [Name]=@Name,
        [Active]=@Active
WHERE        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_OrganizationUsers_Delete]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_OrganizationUsers_Delete]
(
@Id int
)
AS
BEGIN
    DELETE FROM [dbo].[OrganizationUsers]
    WHERE
        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_OrganizationUsers_Insert]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_OrganizationUsers_Insert]
(
@OrganizationId int,
@UserId int,
@Active bit
)
AS
BEGIN
    INSERT INTO [dbo].[OrganizationUsers]
    (
        [OrganizationId],
[UserId],
[Active]
    )
    VALUES
    (
        @OrganizationId,
@UserId,
@Active

    )
    Select @@identity;
END


GO
/****** Object:  StoredProcedure [dbo].[sp_OrganizationUsers_Select_All]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_OrganizationUsers_Select_All]
AS
BEGIN
    SELECT [Id],[OrganizationId],[UserId],[Active]
    FROM [dbo].[OrganizationUsers]
END


GO
/****** Object:  StoredProcedure [dbo].[sp_OrganizationUsers_Select_One]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_OrganizationUsers_Select_One]
(
@Id int
)
AS
BEGIN
    SELECT [Id],[OrganizationId],[UserId],[Active]
    FROM [dbo].[OrganizationUsers]
    WHERE
        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_OrganizationUsers_Update]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_OrganizationUsers_Update]
(
@Id int,
@OrganizationId int,
@UserId int,
@Active bit
)
AS
BEGIN
    UPDATE [dbo].[OrganizationUsers]
    SET
        [OrganizationId]=@OrganizationId,
        [UserId]=@UserId,
        [Active]=@Active
WHERE        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Roles_Delete]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Roles_Delete]
(
@Id int
)
AS
BEGIN
    DELETE FROM [dbo].[Roles]
    WHERE
        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Roles_Insert]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Roles_Insert]
(
@PublicId uniqueidentifier,
@Name varchar(50),
@Active bit
)
AS
BEGIN
    INSERT INTO [dbo].[Roles]
    (
        [PublicId],
[Name],
[Active]
    )
    VALUES
    (
        @PublicId,
@Name,
@Active

    )
    Select @@identity;
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Roles_Select_All]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Roles_Select_All]
AS
BEGIN
    SELECT [Id],[PublicId],[Name],[Active]
    FROM [dbo].[Roles]
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Roles_Select_One]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Roles_Select_One]
(
@Id int
)
AS
BEGIN
    SELECT [Id],[PublicId],[Name],[Active]
    FROM [dbo].[Roles]
    WHERE
        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Roles_Update]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Roles_Update]
(
@Id int,
@PublicId uniqueidentifier,
@Name varchar(50),
@Active bit
)
AS
BEGIN
    UPDATE [dbo].[Roles]
    SET
        [PublicId]=@PublicId,
        [Name]=@Name,
        [Active]=@Active
WHERE        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Select_OrganizationUserss_By_OrganizationId]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Select_OrganizationUserss_By_OrganizationId]
(
@OrganizationId int
)
AS
BEGIN
    SELECT [Id],[OrganizationId],[UserId],[Active]
    FROM [dbo].[OrganizationUsers]
    WHERE
        [OrganizationId]=@OrganizationId
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Select_OrganizationUserss_By_UserId]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Select_OrganizationUserss_By_UserId]
(
@UserId int
)
AS
BEGIN
    SELECT [Id],[OrganizationId],[UserId],[Active]
    FROM [dbo].[OrganizationUsers]
    WHERE
        [UserId]=@UserId
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Select_UserRoless_By_RoleId]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Select_UserRoless_By_RoleId]
(
@RoleId int
)
AS
BEGIN
    SELECT [Id],[RoleId],[UserId],[Active]
    FROM [dbo].[UserRoles]
    WHERE
        [RoleId]=@RoleId
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Select_UserRoless_By_UserId]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Select_UserRoless_By_UserId]
(
@UserId int
)
AS
BEGIN
    SELECT [Id],[RoleId],[UserId],[Active]
    FROM [dbo].[UserRoles]
    WHERE
        [UserId]=@UserId
END


GO
/****** Object:  StoredProcedure [dbo].[sp_UserRoles_Delete]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_UserRoles_Delete]
(
@Id int
)
AS
BEGIN
    DELETE FROM [dbo].[UserRoles]
    WHERE
        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_UserRoles_Insert]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_UserRoles_Insert]
(
@RoleId int,
@UserId int,
@Active bit
)
AS
BEGIN
    INSERT INTO [dbo].[UserRoles]
    (
        [RoleId],
[UserId],
[Active]
    )
    VALUES
    (
        @RoleId,
@UserId,
@Active

    )
    Select @@identity;
END


GO
/****** Object:  StoredProcedure [dbo].[sp_UserRoles_Select_All]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_UserRoles_Select_All]
AS
BEGIN
    SELECT [Id],[RoleId],[UserId],[Active]
    FROM [dbo].[UserRoles]
END


GO
/****** Object:  StoredProcedure [dbo].[sp_UserRoles_Select_One]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_UserRoles_Select_One]
(
@Id int
)
AS
BEGIN
    SELECT [Id],[RoleId],[UserId],[Active]
    FROM [dbo].[UserRoles]
    WHERE
        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_UserRoles_Update]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_UserRoles_Update]
(
@Id int,
@RoleId int,
@UserId int,
@Active bit
)
AS
BEGIN
    UPDATE [dbo].[UserRoles]
    SET
        [RoleId]=@RoleId,
        [UserId]=@UserId,
        [Active]=@Active
WHERE        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Users_Delete]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Users_Delete]
(
@Id int
)
AS
BEGIN
    DELETE FROM [dbo].[Users]
    WHERE
        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Users_Insert]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Users_Insert]
(
@PublicId uniqueidentifier,
@UserName varchar(50),
@Email varchar(150),
@Active bit,
@PasswordHash varchar(256)
)
AS
BEGIN
    INSERT INTO [dbo].[Users]
    (
        [PublicId],
[UserName],
[Email],
[Active],
[PasswordHash]
    )
    VALUES
    (
        @PublicId,
@UserName,
@Email,
@Active,
@PasswordHash

    )
    Select @@identity;
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Users_Select_All]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Users_Select_All]
AS
BEGIN
    SELECT [Id],[PublicId],[UserName],[Email],[Active],[PasswordHash]
    FROM [dbo].[Users]
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Users_Select_One]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Users_Select_One]
(
@Id int
)
AS
BEGIN
    SELECT [Id],[PublicId],[UserName],[Email],[Active],[PasswordHash]
    FROM [dbo].[Users]
    WHERE
        [Id]=@Id
END


GO
/****** Object:  StoredProcedure [dbo].[sp_Users_Update]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Procedure [dbo].[sp_Users_Update]
(
@Id int,
@PublicId uniqueidentifier,
@UserName varchar(50),
@Email varchar(150),
@Active bit,
@PasswordHash varchar(256)
)
AS
BEGIN
    UPDATE [dbo].[Users]
    SET
        [PublicId]=@PublicId,
        [UserName]=@UserName,
        [Email]=@Email,
        [Active]=@Active,
        [PasswordHash]=@PasswordHash
WHERE        [Id]=@Id
END


GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PublicId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrganizationUsers]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_OrganizationUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PublicId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/18/2014 10:43:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PublicId] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Active] [bit] NOT NULL,
	[PasswordHash] [varchar](256) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[OrganizationUsers]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationUsers_Organizations] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organizations] ([Id])
GO
ALTER TABLE [dbo].[OrganizationUsers] CHECK CONSTRAINT [FK_OrganizationUsers_Organizations]
GO
ALTER TABLE [dbo].[OrganizationUsers]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationUsers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[OrganizationUsers] CHECK CONSTRAINT [FK_OrganizationUsers_Users]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
