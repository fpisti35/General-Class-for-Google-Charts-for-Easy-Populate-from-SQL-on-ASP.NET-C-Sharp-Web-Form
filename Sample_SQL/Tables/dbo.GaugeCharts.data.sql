CREATE TABLE [dbo].[GaugeCharts] (
    [id]    INT           IDENTITY (1, 1) NOT NULL,
    [Label] NVARCHAR (50) NULL,
    [Value] INT           NULL,
    CONSTRAINT [PK_GaugeCharts] PRIMARY KEY CLUSTERED ([id] ASC)
);



SET IDENTITY_INSERT [dbo].[GaugeCharts] ON
INSERT INTO [dbo].[GaugeCharts] ([id], [Label], [Value]) VALUES (1, N'Memory', 80)
INSERT INTO [dbo].[GaugeCharts] ([id], [Label], [Value]) VALUES (2, N'CPU', 55)
INSERT INTO [dbo].[GaugeCharts] ([id], [Label], [Value]) VALUES (3, N'Network', 68)
SET IDENTITY_INSERT [dbo].[GaugeCharts] OFF
