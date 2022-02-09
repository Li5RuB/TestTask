CREATE TABLE [dbo].[Users] (
    [Firstname] VARCHAR (255) NOT NULL,
    [Lastname]  VARCHAR (255) NOT NULL,
    [Email]     VARCHAR (255) NOT NULL,
    [Phone]     VARCHAR (50)  NOT NULL,
    [TitleId]   INT           NOT NULL,
    [Comments]  VARCHAR (255) NULL,
    [CItyId]    INT           NOT NULL,
    [UserId]    INT           IDENTITY (1, 1) NOT NULL,
    [Password]  VARCHAR (255) NOT NULL,
    [RoleId]    INT           NOT NULL,
    [LastLogin] DATETIME NULL, 
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    FOREIGN KEY ([CItyId]) REFERENCES [dbo].[Cities] ([CityId]),
    FOREIGN KEY ([TitleId]) REFERENCES [dbo].[Titles] ([TitleId]),
    CONSTRAINT [FK_Users_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId])
);

