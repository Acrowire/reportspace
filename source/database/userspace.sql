USE [ReportSpace]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 6/30/2014 12:59:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Resources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PublicId] [uniqueidentifier] NOT NULL,
	[ResourceTypeId] [int] NOT NULL,
	[Path] [varchar](512) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ResourceType]    Script Date: 6/30/2014 12:59:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ResourceType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PublicId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Description] [varchar](500) NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[SourceSystem] [varchar](512) NULL,
 CONSTRAINT [PK_ResourceType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserGroupMembership]    Script Date: 6/30/2014 12:59:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupMembership](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserGroupMembership] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroupResourcesPermissions]    Script Date: 6/30/2014 12:59:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupResourcesPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupId] [int] NOT NULL,
	[ResourceId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserGroupResourcesPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 6/30/2014 12:59:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserGroups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PublicId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserIdentity]    Script Date: 6/30/2014 12:59:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserIdentity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PublicId] [uniqueidentifier] NOT NULL,
	[Username] [varchar](128) NOT NULL,
	[Password] [varchar](128) NULL,
	[Active] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[Is_ActiveDirectory] [bit] NULL,
 CONSTRAINT [PK_UserIdentity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 6/30/2014 12:59:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AttributeName] [varchar](150) NOT NULL,
	[AttributeValue] [varchar](150) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [FK_Resources_ResourceType] FOREIGN KEY([ResourceTypeId])
REFERENCES [dbo].[ResourceType] ([Id])
GO
ALTER TABLE [dbo].[Resources] CHECK CONSTRAINT [FK_Resources_ResourceType]
GO
ALTER TABLE [dbo].[UserGroupMembership]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupMembership_UserGroups] FOREIGN KEY([GroupId])
REFERENCES [dbo].[UserGroups] ([Id])
GO
ALTER TABLE [dbo].[UserGroupMembership] CHECK CONSTRAINT [FK_UserGroupMembership_UserGroups]
GO
ALTER TABLE [dbo].[UserGroupMembership]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupMembership_UserIdentity] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserIdentity] ([Id])
GO
ALTER TABLE [dbo].[UserGroupMembership] CHECK CONSTRAINT [FK_UserGroupMembership_UserIdentity]
GO
ALTER TABLE [dbo].[UserGroupResourcesPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupResourcesPermissions_Resources] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[Resources] ([Id])
GO
ALTER TABLE [dbo].[UserGroupResourcesPermissions] CHECK CONSTRAINT [FK_UserGroupResourcesPermissions_Resources]
GO
ALTER TABLE [dbo].[UserGroupResourcesPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupResourcesPermissions_UserGroups] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[UserGroups] ([Id])
GO
ALTER TABLE [dbo].[UserGroupResourcesPermissions] CHECK CONSTRAINT [FK_UserGroupResourcesPermissions_UserGroups]
GO
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_UserIdentity] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserIdentity] ([Id])
GO
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_UserIdentity]
GO
