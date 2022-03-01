CREATE TABLE [dbo].[TimeLogs]
(
	[TimeLogId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [IssueId] INT NOT NULL,
    [DateLog] DATETIME NULL, 
    [Time] TIME NULL
)