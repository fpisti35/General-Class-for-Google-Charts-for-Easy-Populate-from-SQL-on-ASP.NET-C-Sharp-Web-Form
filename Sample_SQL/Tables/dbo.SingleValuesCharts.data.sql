CREATE TABLE [dbo].[SingleValuesCharts] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (50) NULL,
    [Value] INT           NULL,
    CONSTRAINT [PK_SingleValuesCharts] PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [dbo].[SingleValuesCharts] ON
INSERT INTO [dbo].[SingleValuesCharts] ([id], [Name], [Value]) VALUES (1, N'Work', 11)
INSERT INTO [dbo].[SingleValuesCharts] ([id], [Name], [Value]) VALUES (2, N'Eat', 2)
INSERT INTO [dbo].[SingleValuesCharts] ([id], [Name], [Value]) VALUES (3, N'Commute', 2)
INSERT INTO [dbo].[SingleValuesCharts] ([id], [Name], [Value]) VALUES (4, N'Watch TV', 2)
INSERT INTO [dbo].[SingleValuesCharts] ([id], [Name], [Value]) VALUES (5, N'Sleep', 7)
SET IDENTITY_INSERT [dbo].[SingleValuesCharts] OFF
