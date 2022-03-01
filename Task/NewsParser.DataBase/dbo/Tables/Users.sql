CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(255) NOT NULL, 
    [RoleId] INT NOT NULL,
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId]) ON DELETE SET NULL
)
