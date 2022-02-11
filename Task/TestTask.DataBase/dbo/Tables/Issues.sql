CREATE TABLE [dbo].[Issues]
(
	[IssueId] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(255) NULL, 
    [Description] VARCHAR(255) NULL, 
    [UserId] INT NOT NULL
)