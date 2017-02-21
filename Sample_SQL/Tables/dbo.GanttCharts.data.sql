CREATE TABLE [dbo].[GanttCharts] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [Task_ID]          NVARCHAR (50)  NULL,
    [Task_Name]        NVARCHAR (250) NULL,
    [Start_Date]       DATE           NULL,
    [End_Date]         DATE           NULL,
    [Duration]         INT            NULL,
    [Percent_Complete] INT            NULL,
    [Dependencies]     NVARCHAR (250) NULL,
    CONSTRAINT [PK_GanttCharts] PRIMARY KEY CLUSTERED ([id] ASC)
);


SET IDENTITY_INSERT [dbo].[GanttCharts] ON
INSERT INTO [dbo].[GanttCharts] ([id], [Task_ID], [Task_Name], [Start_Date], [End_Date], [Duration], [Percent_Complete], [Dependencies]) VALUES (1, N'Research', N'Find sources', N'2015-01-01', N'2015-01-05', NULL, 100, NULL)
INSERT INTO [dbo].[GanttCharts] ([id], [Task_ID], [Task_Name], [Start_Date], [End_Date], [Duration], [Percent_Complete], [Dependencies]) VALUES (2, N'Write', N'Write paper', NULL, N'2015-01-09', 3, 25, N'Research,Outline')
INSERT INTO [dbo].[GanttCharts] ([id], [Task_ID], [Task_Name], [Start_Date], [End_Date], [Duration], [Percent_Complete], [Dependencies]) VALUES (3, N'Cite', N'Create bibliography', NULL, N'2015-01-07', 1, 25, N'Research')
INSERT INTO [dbo].[GanttCharts] ([id], [Task_ID], [Task_Name], [Start_Date], [End_Date], [Duration], [Percent_Complete], [Dependencies]) VALUES (4, N'Complete', N'Hand in paper', NULL, N'2015-01-10', 1, 0, N'Cite,Write')
INSERT INTO [dbo].[GanttCharts] ([id], [Task_ID], [Task_Name], [Start_Date], [End_Date], [Duration], [Percent_Complete], [Dependencies]) VALUES (5, N'Outline', N'Outline paper', NULL, N'2015-01-06', 1, 100, N'Research')
SET IDENTITY_INSERT [dbo].[GanttCharts] OFF
