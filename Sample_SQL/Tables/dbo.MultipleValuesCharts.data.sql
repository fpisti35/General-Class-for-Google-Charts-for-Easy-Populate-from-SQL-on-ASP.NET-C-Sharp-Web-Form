CREATE TABLE [dbo].[MultipleValuesCharts] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [Year]       NVARCHAR (50) NULL,
    [Sales]      NVARCHAR (10) NULL,
    [Expenses]   NVARCHAR (10) NULL,
    [Cash]       NVARCHAR (10) NULL,
    [CreditCard] NVARCHAR (10) NULL,
    [Online]     NVARCHAR (10) NULL,
    [Retailer]   NVARCHAR (10) NULL,
    [Average]    NVARCHAR (10) NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED ([id] ASC)
);



SET IDENTITY_INSERT [dbo].[MultipleValuesCharts] ON
INSERT INTO [dbo].[MultipleValuesCharts] ([id], [Year], [Sales], [Expenses], [Cash], [CreditCard], [Online], [Retailer], [Average]) VALUES (1, N'2000', N'150000', N'120000', N'50000', N'100000', N'30000', N'120000', N'80000')
INSERT INTO [dbo].[MultipleValuesCharts] ([id], [Year], [Sales], [Expenses], [Cash], [CreditCard], [Online], [Retailer], [Average]) VALUES (2, N'2001', N'100000', N'120000', N'20000', N'80000', N'40000', N'40000', N'65000')
INSERT INTO [dbo].[MultipleValuesCharts] ([id], [Year], [Sales], [Expenses], [Cash], [CreditCard], [Online], [Retailer], [Average]) VALUES (3, N'2002', N'200000', N'240000', N'80000', N'120000', N'80000', N'120000', N'140000')
INSERT INTO [dbo].[MultipleValuesCharts] ([id], [Year], [Sales], [Expenses], [Cash], [CreditCard], [Online], [Retailer], [Average]) VALUES (4, N'2003', N'180000', N'180000', N'80000', N'100000', N'70000', N'110000', N'130000')
INSERT INTO [dbo].[MultipleValuesCharts] ([id], [Year], [Sales], [Expenses], [Cash], [CreditCard], [Online], [Retailer], [Average]) VALUES (5, N'2004', N'200000', N'180000', N'100000', N'100000', N'90000', N'110000', N'130000')
INSERT INTO [dbo].[MultipleValuesCharts] ([id], [Year], [Sales], [Expenses], [Cash], [CreditCard], [Online], [Retailer], [Average]) VALUES (6, N'2005', N'250000', N'150000', N'140000', N'110000', N'110000', N'140000', N'160000')
INSERT INTO [dbo].[MultipleValuesCharts] ([id], [Year], [Sales], [Expenses], [Cash], [CreditCard], [Online], [Retailer], [Average]) VALUES (7, N'2006', N'210000', N'215000', N'80000', N'130000', N'110000', N'100000', N'140000')
SET IDENTITY_INSERT [dbo].[MultipleValuesCharts] OFF
