USE [ReportSpace]
GO
/****** Object:  Table [dbo].[Functions]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Functions](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ResourceName] [nvarchar](max) NULL,
	[Controller] [nvarchar](max) NULL,
	[Action] [nvarchar](max) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Functions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MASFORW]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MASFORW](
	[FORW_NO] [float] NOT NULL,
	[NAME] [nvarchar](max) NULL,
	[ADDR] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.MASFORW] PRIMARY KEY CLUSTERED 
(
	[FORW_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportRole]    Script Date: 7/3/2014 11:40:15 AM ******/
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
/****** Object:  Table [dbo].[Reports]    Script Date: 7/3/2014 11:40:15 AM ******/
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
/****** Object:  Table [dbo].[Resources]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[Id] [uniqueidentifier] NOT NULL,
	[ResourceTypeId] [uniqueidentifier] NULL,
	[Path] [nvarchar](max) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Resources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ResourceTypes]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[SourceSystem] [nvarchar](max) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ResourceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TemplateFunctions]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemplateFunctions](
	[TemplateId] [uniqueidentifier] NOT NULL,
	[FunctionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.TemplateFunctions] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC,
	[FunctionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Templates]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Templates](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Templates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserFunctions]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFunctions](
	[Id] [uniqueidentifier] NOT NULL,
	[UserProfileId] [int] NOT NULL,
	[FunctionId] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
	[UserProfile_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.UserFunctions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroupMemberships]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupMemberships](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupId] [uniqueidentifier] NULL,
	[UserProfileId] [int] NOT NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
	[UserProfile_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.UserGroupMemberships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroupResourcesPermissions]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroupResourcesPermissions](
	[Id] [uniqueidentifier] NOT NULL,
	[UserGroupId] [uniqueidentifier] NULL,
	[ResourceId] [uniqueidentifier] NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.UserGroupResourcesPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserGroups]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.UserGroups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[CompanyLogoFileName] [nvarchar](max) NULL,
	[MembershipId] [int] NOT NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.UserProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfileClient]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfileClient](
	[UserProfileId] [uniqueidentifier] NOT NULL,
	[ClientId] [float] NOT NULL,
 CONSTRAINT [PK_dbo.UserProfileClient] PRIMARY KEY CLUSTERED 
(
	[UserProfileId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[UserProfileId] [uniqueidentifier] NULL,
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
	[UserProfile_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.webpages_Membership] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 7/3/2014 11:40:15 AM ******/
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
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 7/3/2014 11:40:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[RoleId] [int] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.webpages_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Functions] ([Id], [Name], [ResourceName], [Controller], [Action], [Created], [Updated], [Active]) VALUES (N'090ec82b-c802-e411-aaaa-9cb654bf7ceb', N'Create_Admin_Account', N'Create Admin Account', N'AdminAccount', N'index', NULL, NULL, 0)
INSERT [dbo].[Functions] ([Id], [Name], [ResourceName], [Controller], [Action], [Created], [Updated], [Active]) VALUES (N'0a0ec82b-c802-e411-aaaa-9cb654bf7ceb', N'Create_User_Group', N'Create User Group', N'UserGroup', N'index', NULL, NULL, 0)
INSERT [dbo].[TemplateFunctions] ([TemplateId], [FunctionId]) VALUES (N'0b0ec82b-c802-e411-aaaa-9cb654bf7ceb', N'090ec82b-c802-e411-aaaa-9cb654bf7ceb')
INSERT [dbo].[TemplateFunctions] ([TemplateId], [FunctionId]) VALUES (N'0b0ec82b-c802-e411-aaaa-9cb654bf7ceb', N'0a0ec82b-c802-e411-aaaa-9cb654bf7ceb')
INSERT [dbo].[Templates] ([Id], [Name], [Created], [Updated], [Active]) VALUES (N'0b0ec82b-c802-e411-aaaa-9cb654bf7ceb', N'Admin', NULL, NULL, 0)
INSERT [dbo].[Templates] ([Id], [Name], [Created], [Updated], [Active]) VALUES (N'0c0ec82b-c802-e411-aaaa-9cb654bf7ceb', N'User', NULL, NULL, 0)
INSERT [dbo].[UserFunctions] ([Id], [UserProfileId], [FunctionId], [Created], [Updated], [Active], [UserProfile_Id]) VALUES (N'0d0ec82b-c802-e411-aaaa-9cb654bf7ceb', 0, N'090ec82b-c802-e411-aaaa-9cb654bf7ceb', NULL, NULL, 0, N'080ec82b-c802-e411-aaaa-9cb654bf7ceb')
INSERT [dbo].[UserFunctions] ([Id], [UserProfileId], [FunctionId], [Created], [Updated], [Active], [UserProfile_Id]) VALUES (N'0e0ec82b-c802-e411-aaaa-9cb654bf7ceb', 0, N'0a0ec82b-c802-e411-aaaa-9cb654bf7ceb', NULL, NULL, 0, N'080ec82b-c802-e411-aaaa-9cb654bf7ceb')
INSERT [dbo].[UserProfile] ([Id], [UserName], [FirstName], [LastName], [Email], [CompanyLogoFileName], [MembershipId], [Created], [Updated], [Active]) VALUES (N'080ec82b-c802-e411-aaaa-9cb654bf7ceb', N'root', N'system', N'admin', N'root@root.com', NULL, 0, NULL, NULL, 1)
ALTER TABLE [dbo].[Functions] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Resources] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[ResourceTypes] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[Templates] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserFunctions] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserGroupResourcesPermissions] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserGroups] ADD  DEFAULT (newsequentialid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserProfile] ADD  DEFAULT (newsequentialid()) FOR [Id]
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
ALTER TABLE [dbo].[TemplateFunctions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TemplateFunctions_dbo.Functions_FunctionId] FOREIGN KEY([FunctionId])
REFERENCES [dbo].[Functions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TemplateFunctions] CHECK CONSTRAINT [FK_dbo.TemplateFunctions_dbo.Functions_FunctionId]
GO
ALTER TABLE [dbo].[TemplateFunctions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TemplateFunctions_dbo.Templates_TemplateId] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[Templates] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TemplateFunctions] CHECK CONSTRAINT [FK_dbo.TemplateFunctions_dbo.Templates_TemplateId]
GO
ALTER TABLE [dbo].[UserFunctions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserFunctions_dbo.Functions_FunctionId] FOREIGN KEY([FunctionId])
REFERENCES [dbo].[Functions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserFunctions] CHECK CONSTRAINT [FK_dbo.UserFunctions_dbo.Functions_FunctionId]
GO
ALTER TABLE [dbo].[UserFunctions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserFunctions_dbo.UserProfile_UserProfile_Id] FOREIGN KEY([UserProfile_Id])
REFERENCES [dbo].[UserProfile] ([Id])
GO
ALTER TABLE [dbo].[UserFunctions] CHECK CONSTRAINT [FK_dbo.UserFunctions_dbo.UserProfile_UserProfile_Id]
GO
ALTER TABLE [dbo].[UserGroupMemberships]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserGroupMemberships_dbo.UserGroups_UserGroupId] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[UserGroups] ([Id])
GO
ALTER TABLE [dbo].[UserGroupMemberships] CHECK CONSTRAINT [FK_dbo.UserGroupMemberships_dbo.UserGroups_UserGroupId]
GO
ALTER TABLE [dbo].[UserGroupMemberships]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserGroupMemberships_dbo.UserProfile_UserProfile_Id] FOREIGN KEY([UserProfile_Id])
REFERENCES [dbo].[UserProfile] ([Id])
GO
ALTER TABLE [dbo].[UserGroupMemberships] CHECK CONSTRAINT [FK_dbo.UserGroupMemberships_dbo.UserProfile_UserProfile_Id]
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
REFERENCES [dbo].[UserProfile] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserProfileClient] CHECK CONSTRAINT [FK_dbo.UserProfileClient_dbo.UserProfile_UserProfileId]
GO
ALTER TABLE [dbo].[webpages_Membership]  WITH CHECK ADD  CONSTRAINT [FK_dbo.webpages_Membership_dbo.UserProfile_UserProfile_Id] FOREIGN KEY([UserProfile_Id])
REFERENCES [dbo].[UserProfile] ([Id])
GO
ALTER TABLE [dbo].[webpages_Membership] CHECK CONSTRAINT [FK_dbo.webpages_Membership_dbo.UserProfile_UserProfile_Id]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.webpages_UsersInRoles_dbo.UserProfile_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([Id])
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
