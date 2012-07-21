CREATE TABLE [dbo].[DashboardDispatchMonthlyEmails] (
    [MonthlyEmailId]       UNIQUEIDENTIFIER  NOT NULL,
	[ApplicationName]      NVARCHAR (64)      NOT NULL,
    [To]                   NVARCHAR (128)    NOT NULL,
	[Subject]              NVARCHAR (255)    NOT NULL,
	[Month]                INT               NOT NULL,
	[Year]                 INT               NOT NULL,
    [CreationDateTime]     DATETIME          NOT NULL,
    [LastModifiedDateTime] DATETIME          NULL
);

