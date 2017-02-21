CREATE TABLE [dbo].[Sankey] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [clFrom]   NVARCHAR (10) NULL,
    [clTo]     NVARCHAR (10) NULL,
    [clWeight] INT           NULL,
    CONSTRAINT [PK_Sankey] PRIMARY KEY CLUSTERED ([id] ASC)
);


SET IDENTITY_INSERT [dbo].[Sankey] ON
INSERT INTO [dbo].[Sankey] ([id], [clFrom], [clTo], [clWeight]) VALUES (1, N'A', N'X', 5)
INSERT INTO [dbo].[Sankey] ([id], [clFrom], [clTo], [clWeight]) VALUES (2, N'A', N'Y', 7)
INSERT INTO [dbo].[Sankey] ([id], [clFrom], [clTo], [clWeight]) VALUES (3, N'A', N'Z', 6)
INSERT INTO [dbo].[Sankey] ([id], [clFrom], [clTo], [clWeight]) VALUES (4, N'B', N'X', 2)
INSERT INTO [dbo].[Sankey] ([id], [clFrom], [clTo], [clWeight]) VALUES (5, N'B', N'Y', 9)
INSERT INTO [dbo].[Sankey] ([id], [clFrom], [clTo], [clWeight]) VALUES (6, N'B', N'Z', 4)
SET IDENTITY_INSERT [dbo].[Sankey] OFF
