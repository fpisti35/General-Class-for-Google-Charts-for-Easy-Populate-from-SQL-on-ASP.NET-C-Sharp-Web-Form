CREATE TABLE [dbo].[Table_1] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NULL,
    [SalaryValue]  INT           NULL,
    [SalaryFormat] NVARCHAR (50) NULL,
    [FullTE]       NVARCHAR (10) NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [dbo].[Table_1] ON
INSERT INTO [dbo].[Table_1] ([id], [Name], [SalaryValue], [SalaryFormat], [FullTE]) VALUES (1, N'Mike', 10000, N'£10,000', N'true')
INSERT INTO [dbo].[Table_1] ([id], [Name], [SalaryValue], [SalaryFormat], [FullTE]) VALUES (2, N'Jim', 8000, N'£8,000', N'false')
INSERT INTO [dbo].[Table_1] ([id], [Name], [SalaryValue], [SalaryFormat], [FullTE]) VALUES (3, N'Alice', 12500, N'£12,500', N'true')
INSERT INTO [dbo].[Table_1] ([id], [Name], [SalaryValue], [SalaryFormat], [FullTE]) VALUES (4, N'Bob', 7000, N'£7,000', N'true')
SET IDENTITY_INSERT [dbo].[Table_1] OFF
