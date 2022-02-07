CREATE TABLE [dbo].[Cities] (
    [Name]      VARCHAR (255) NOT NULL,
    [CountryId] INT           NOT NULL,
    [CityId]    INT           IDENTITY (1, 1) NOT NULL,
    PRIMARY KEY CLUSTERED ([CityId] ASC),
    FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([CountryId])
);

