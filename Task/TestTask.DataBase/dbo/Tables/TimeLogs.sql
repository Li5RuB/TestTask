CREATE TABLE [dbo].[TimeLogs]
(
	[TimeLogId] INT NOT NULL PRIMARY KEY, 
    [IssueId] INT NOT NULL,
    [DateLog] DATETIME NULL, 
    [Time] TIME NULL
)