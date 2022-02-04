CREATE TABLE [dbo].[Countries] (
    [Name]        VARCHAR (255) NOT NULL,
    [CountryId]   INT           IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

