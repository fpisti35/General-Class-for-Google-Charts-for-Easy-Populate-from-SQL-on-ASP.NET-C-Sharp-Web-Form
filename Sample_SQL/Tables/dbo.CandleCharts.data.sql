CREATE TABLE [dbo].[CandleCharts] (
    [id]   INT           IDENTITY (1, 1) NOT NULL,
    [Days] NVARCHAR (10) NULL,
    [val1] INT           NULL,
    [val2] INT           NULL,
    [val3] INT           NULL,
    [val4] INT           NULL,
    CONSTRAINT [PK_Candle] PRIMARY KEY CLUSTERED ([id] ASC)
);


SET IDENTITY_INSERT [dbo].[CandleCharts] ON
INSERT INTO [dbo].[CandleCharts] ([id], [Days], [val1], [val2], [val3], [val4]) VALUES (1, N'Mon', 20, 28, 38, 45)
INSERT INTO [dbo].[CandleCharts] ([id], [Days], [val1], [val2], [val3], [val4]) VALUES (2, N'Tue', 31, 38, 55, 66)
INSERT INTO [dbo].[CandleCharts] ([id], [Days], [val1], [val2], [val3], [val4]) VALUES (3, N'Wed', 50, 55, 77, 80)
INSERT INTO [dbo].[CandleCharts] ([id], [Days], [val1], [val2], [val3], [val4]) VALUES (4, N'Thu', 77, 77, 66, 50)
INSERT INTO [dbo].[CandleCharts] ([id], [Days], [val1], [val2], [val3], [val4]) VALUES (5, N'Fri', 68, 66, 22, 15)
SET IDENTITY_INSERT [dbo].[CandleCharts] OFF
