USE [ReportSpace]
GO
/****** Object:  Table [dbo].[ReportRole]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportRole](
	[ReportId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ReportRole] PRIMARY KEY CLUSTERED 
(
	[ReportId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reports]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Category] [nvarchar](max) NULL,
	[Path] [nvarchar](max) NULL,
	[IsDefault] [bit] NOT NULL,
	[IsHidden] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Resources]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[Id] [uniqueidentifier] NOT NULL,
	[ResourceTypeId] [uniqueidentifier] NULL,
	[Path] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Resources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ResourceTypes]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[SourceSystem] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.ResourceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroupMemberships]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupMemberships](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupId] [uniqueidentifier] NULL,
	[UserProfileId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
	[UserProfile_UserId] [int] NULL,
 CONSTRAINT [PK_dbo.UserGroupMemberships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroupResourcesPermissions]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupResourcesPermissions](
	[Id] [uniqueidentifier] NOT NULL,
	[UserGroupId] [uniqueidentifier] NULL,
	[ResourceId] [uniqueidentifier] NULL,
	[Active] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.UserGroupResourcesPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.UserGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[CompanyLogoFileName] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.UserProfile] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfileClient]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfileClient](
	[UserProfileId] [int] NOT NULL,
	[ClientId] [float] NOT NULL,
 CONSTRAINT [PK_dbo.UserProfileClient] PRIMARY KEY CLUSTERED 
(
	[UserProfileId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NOT NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.webpages_Membership] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.webpages_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 7/1/2014 2:35:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.webpages_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Resources] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[ResourceTypes] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserGroupResourcesPermissions] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserGroups] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[ReportRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ReportRole_dbo.Reports_ReportId] FOREIGN KEY([ReportId])
REFERENCES [dbo].[Reports] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReportRole] CHECK CONSTRAINT [FK_dbo.ReportRole_dbo.Reports_ReportId]
GO
ALTER TABLE [dbo].[ReportRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ReportRole_dbo.webpages_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReportRole] CHECK CONSTRAINT [FK_dbo.ReportRole_dbo.webpages_Roles_RoleId]
GO
ALTER TABLE [dbo].[Resources]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Resources_dbo.ResourceTypes_ResourceTypeId] FOREIGN KEY([ResourceTypeId])
REFERENCES [dbo].[ResourceTypes] ([Id])
GO
ALTER TABLE [dbo].[Resources] CHECK CONSTRAINT [FK_dbo.Resources_dbo.ResourceTypes_ResourceTypeId]
GO
ALTER TABLE [dbo].[UserGroupMemberships]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserGroupMemberships_dbo.UserGroups_UserGroupId] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[UserGroups] ([Id])
GO
ALTER TABLE [dbo].[UserGroupMemberships] CHECK CONSTRAINT [FK_dbo.UserGroupMemberships_dbo.UserGroups_UserGroupId]
GO
ALTER TABLE [dbo].[UserGroupMemberships]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserGroupMemberships_dbo.UserProfile_UserProfile_UserId] FOREIGN KEY([UserProfile_UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[UserGroupMemberships] CHECK CONSTRAINT [FK_dbo.UserGroupMemberships_dbo.UserProfile_UserProfile_UserId]
GO
ALTER TABLE [dbo].[UserGroupResourcesPermissions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserGroupResourcesPermissions_dbo.Resources_ResourceId] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[Resources] ([Id])
GO
ALTER TABLE [dbo].[UserGroupResourcesPermissions] CHECK CONSTRAINT [FK_dbo.UserGroupResourcesPermissions_dbo.Resources_ResourceId]
GO
ALTER TABLE [dbo].[UserGroupResourcesPermissions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserGroupResourcesPermissions_dbo.UserGroups_UserGroupId] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[UserGroups] ([Id])
GO
ALTER TABLE [dbo].[UserGroupResourcesPermissions] CHECK CONSTRAINT [FK_dbo.UserGroupResourcesPermissions_dbo.UserGroups_UserGroupId]
GO
ALTER TABLE [dbo].[UserProfileClient]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserProfileClient_dbo.MASFORW_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[MASFORW] ([FORW_NO])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserProfileClient] CHECK CONSTRAINT [FK_dbo.UserProfileClient_dbo.MASFORW_ClientId]
GO
ALTER TABLE [dbo].[UserProfileClient]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserProfileClient_dbo.UserProfile_UserProfileId] FOREIGN KEY([UserProfileId])
REFERENCES [dbo].[UserProfile] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserProfileClient] CHECK CONSTRAINT [FK_dbo.UserProfileClient_dbo.UserProfile_UserProfileId]
GO
ALTER TABLE [dbo].[webpages_Membership]  WITH CHECK ADD  CONSTRAINT [FK_dbo.webpages_Membership_dbo.UserProfile_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webpages_Membership] CHECK CONSTRAINT [FK_dbo.webpages_Membership_dbo.UserProfile_UserId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.webpages_UsersInRoles_dbo.UserProfile_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [FK_dbo.webpages_UsersInRoles_dbo.UserProfile_UserId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.webpages_UsersInRoles_dbo.webpages_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [FK_dbo.webpages_UsersInRoles_dbo.webpages_Roles_RoleId]
GO
