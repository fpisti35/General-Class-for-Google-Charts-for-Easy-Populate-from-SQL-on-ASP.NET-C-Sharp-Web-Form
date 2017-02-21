CREATE TABLE [dbo].[Timeline] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [President] NVARCHAR (50) NULL,
    [StartDate] DATE          NULL,
    [EndDate]   DATE          NULL,
    CONSTRAINT [PK_Timeline] PRIMARY KEY CLUSTERED ([id] ASC)
);


SET IDENTITY_INSERT [dbo].[Timeline] ON
INSERT INTO [dbo].[Timeline] ([id], [President], [StartDate], [EndDate]) VALUES (1, N'Washington', N'1789-03-30', N'1797-02-04')
INSERT INTO [dbo].[Timeline] ([id], [President], [StartDate], [EndDate]) VALUES (2, N'Adams', N'1797-02-04', N'1801-02-04')
INSERT INTO [dbo].[Timeline] ([id], [President], [StartDate], [EndDate]) VALUES (3, N'Jefferson', N'1801-02-04', N'1809-02-04')
SET IDENTITY_INSERT [dbo].[Timeline] OFF
