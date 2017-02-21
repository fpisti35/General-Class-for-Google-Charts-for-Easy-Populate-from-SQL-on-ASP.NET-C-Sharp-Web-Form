CREATE TABLE [dbo].[GeoCharts] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [City]       NVARCHAR (50) NULL,
    [Population] INT           NULL,
    [Area]       NVARCHAR (10) NULL,
    CONSTRAINT [PK_GeoCharts] PRIMARY KEY CLUSTERED ([id] ASC)
);

SET IDENTITY_INSERT [dbo].[GeoCharts] ON
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (1, N'London', 8173941, N'	157.215')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (2, N'Birmingham', 1085810, N'	22.982')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (3, N'Glasgow', 590507, N'15.185')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (4, N'Liverpool', 552267, N'12.331')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (5, N'Bristol', 535907, N'11.246')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (6, N'Sheffield', 518090, N'	12.249')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (7, N'Manchester', 510746, N'9.845')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (8, N'Leeds', 474632, N'11.163')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (9, N'Edinburgh', 459366, N'11.792')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (10, N'Leicester', 443760, N'9.203')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (11, N'Bradford', 349561, N'8.174')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (12, N'Cardiff', 335145, N'	7.138')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (13, N'Coventry', 325949, N'7.358')
INSERT INTO [dbo].[GeoCharts] ([id], [City], [Population], [Area]) VALUES (14, N'Nottingham', 289301, N'6.250')
SET IDENTITY_INSERT [dbo].[GeoCharts] OFF
