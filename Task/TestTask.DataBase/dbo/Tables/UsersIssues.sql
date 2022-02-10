CREATE TABLE [dbo].[UsersIssues]
(
	[UserIssueId] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [IssueId] INT NOT NULL, 
    CONSTRAINT [FK_UsersIssues_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_UsersIssues_Issues] FOREIGN KEY ([IssueId]) REFERENCES [Issues]([IssueId])
)
