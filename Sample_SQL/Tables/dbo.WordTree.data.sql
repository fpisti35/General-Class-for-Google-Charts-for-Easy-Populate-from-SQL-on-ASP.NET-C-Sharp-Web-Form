CREATE TABLE [dbo].[WordTree] (
    [id]      INT            IDENTITY (1, 1) NOT NULL,
    [Phrases] NVARCHAR (250) NULL,
    CONSTRAINT [PK_WordTree] PRIMARY KEY CLUSTERED ([id] ASC)
);


SET IDENTITY_INSERT [dbo].[WordTree] ON
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (1, N'cats are better than dogs')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (2, N'cats eat kibble')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (3, N'cats are better than hamsters')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (4, N'cats are awesome')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (5, N'cats are people too')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (6, N'cats eat mice')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (7, N'cats meowing')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (8, N'cats in the cradle')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (9, N'cats eat mice')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (10, N'cats in the cradle lyrics')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (11, N'cats eat kibble')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (12, N'cats for adoption')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (13, N'cats are family')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (14, N'cats eat mice')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (15, N'cats are better than kittens')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (16, N'cats are evil')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (17, N'cats are weird')
INSERT INTO [dbo].[WordTree] ([id], [Phrases]) VALUES (18, N'cats eat mice')
SET IDENTITY_INSERT [dbo].[WordTree] OFF
