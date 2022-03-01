CREATE TABLE [dbo].[Issues]
(
    [IssueId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(255) NULL, 
    [Description] VARCHAR(255) NULL, 
    [UserId] INT NOT NULL, 
    [IsClosed] BIT NOT NULL DEFAULT 0
)