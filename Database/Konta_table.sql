USE [AnimalCareDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[konta](
    [IDKonta] [int] NOT NULL,
    [IDPracownika] [int] NULL,
    [TypKonta] [varchar](255) NULL,
    [Login] [varchar](255) NULL,
    [Has³o] [varchar](255) NULL,
    [OstatnieLogowanie] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
    [IDKonta] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO