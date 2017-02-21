CREATE TABLE [dbo].[Maps] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [Country]    NVARCHAR (50)  NULL,
    [Population] NVARCHAR (250) NULL,
    CONSTRAINT [PK_Maps] PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [dbo].[Maps] ON
INSERT INTO [dbo].[Maps] ([id], [Country], [Population]) VALUES (1, N'China', N'China: 1,363,800,000')
INSERT INTO [dbo].[Maps] ([id], [Country], [Population]) VALUES (2, N'India', N'India: 1,242,620,000')
INSERT INTO [dbo].[Maps] ([id], [Country], [Population]) VALUES (3, N'US', N'US: 317,842,000')
INSERT INTO [dbo].[Maps] ([id], [Country], [Population]) VALUES (4, N'Indonesia', N'Indonesia: 247,424,598')
INSERT INTO [dbo].[Maps] ([id], [Country], [Population]) VALUES (5, N'Brazil', N'Brazil: 201,032,714')
INSERT INTO [dbo].[Maps] ([id], [Country], [Population]) VALUES (6, N'Pakistan', N'Pakistan: 186,134,000')
INSERT INTO [dbo].[Maps] ([id], [Country], [Population]) VALUES (7, N'Nigeria', N'Nigeria: 173,615,000')
INSERT INTO [dbo].[Maps] ([id], [Country], [Population]) VALUES (8, N'Bangladesh', N'Bangladesh: 152,518,015')
INSERT INTO [dbo].[Maps] ([id], [Country], [Population]) VALUES (9, N'Russia', N'Russia: 146,019,512')
INSERT INTO [dbo].[Maps] ([id], [Country], [Population]) VALUES (10, N'Japan', N'Japan: 127,120,000')
SET IDENTITY_INSERT [dbo].[Maps] OFF
