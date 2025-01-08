USE [AnimalCareDB]
GO

-- Create Pracownicy table
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pracownicy](
    [IDPracownika] [int] NOT NULL,
    [Imiê] [varchar](255) NULL,
    [Nazwisko] [varchar](255) NULL,
    [DataZatrudnienia] [datetime] NULL,
    [DataZwolenienia] [datetime] NULL,
    [Rola] [varchar](255) NULL,
    [Email] [varchar](255) NULL,
    [NumerTelefonu] [varchar](20) NULL,
    [StatusZatrudnienia] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
    [IDPracownika] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Insert missing entries into Pracownicy table
INSERT INTO [dbo].[pracownicy] ([IDPracownika])
SELECT DISTINCT [IDPracownika]
FROM [dbo].[konta]
WHERE [IDPracownika] IS NOT NULL
AND NOT EXISTS (SELECT 1 FROM [dbo].[Pracownicy] WHERE [IDPracownika] = [konta].[IDPracownika])
GO


USE [AnimalCareDB]
GO
-- Modify konta table to add foreign key constraint
ALTER TABLE [dbo].[konta]
ADD CONSTRAINT FK_konta_Pracownicy
FOREIGN KEY (IDPracownika) REFERENCES [dbo].[pracownicy](IDPracownika)
GO

-- Note: To recreate the database, execute the scripts in numerical order. 
-- This ensures all tables are created correctly and foreign keys are properly connected.
