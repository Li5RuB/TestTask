CREATE TABLE [dbo].[News]
(
	[NewsId] INT NOT NULL PRIMARY KEY, 
    [Title] VARCHAR(50) NOT NULL, 
    [BriefContext] VARCHAR(255) NOT NULL, 
    [Url] VARCHAR(50) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Type] VARCHAR(50) NOT NULL
)
