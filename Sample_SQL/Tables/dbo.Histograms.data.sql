CREATE TABLE [dbo].[Histograms] (
    [id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (100) NULL,
    [Value] NVARCHAR (10)  NULL,
    CONSTRAINT [PK_Histograms] PRIMARY KEY CLUSTERED ([id] ASC)
);


SET IDENTITY_INSERT [dbo].[Histograms] ON
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (1, N'Acrocanthosaurus (top-spined lizard)', N'12.2')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (2, N'Albertosaurus (Alberta lizard)', N'9.1')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (3, N'Allosaurus (other lizard)', N'12.2')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (4, N'Apatosaurus (deceptive lizard)', N'22.9')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (5, N'Archaeopteryx (ancient wing)', N'0.9')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (6, N'Argentinosaurus (Argentina lizard)', N' 36.6')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (7, N'Baryonyx (heavy claws)', N'9.1')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (8, N'Brachiosaurus (arm lizard)', N'30.5')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (9, N'Ceratosaurus (horned lizard)', N'6.1')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (10, N'Coelophysis (hollow form)', N'2.7')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (11, N'Compsognathus (elegant jaw', N'0.9')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (12, N'Deinonychus (terrible claw)', N'2.7')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (13, N'Diplodocus (double beam)', N'27.1')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (14, N'Dromicelomimus (emu mimic)', N'3.4')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (15, N'Gallimimus (fowl mimic)', N'5.5')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (16, N'Mamenchisaurus (Mamenchi lizard)', N'21.0')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (17, N'Megalosaurus (big lizard)', N'7.9')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (18, N'Microvenator (small hunter)', N'1.2')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (19, N'Ornithomimus (bird mimic)', N'4.6')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (20, N'Oviraptor (egg robber)', N'1.5')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (21, N'Plateosaurus (flat lizard)', N'7.9')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (22, N'Sauronithoides (narrow-clawed lizard)', N'2.0')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (23, N'Seismosaurus (tremor lizard)', N'45.7')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (24, N'Spinosaurus (spiny lizard)', N'12.2')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (25, N'Supersaurus (super lizard)', N'30.5')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (26, N'Tyrannosaurus (tyrant lizard)', N'15.2')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (27, N'Ultrasaurus (ultra lizard)', N'30.5')
INSERT INTO [dbo].[Histograms] ([id], [Name], [Value]) VALUES (28, N'Velociraptor (swift robber)', N'1.8')
SET IDENTITY_INSERT [dbo].[Histograms] OFF
