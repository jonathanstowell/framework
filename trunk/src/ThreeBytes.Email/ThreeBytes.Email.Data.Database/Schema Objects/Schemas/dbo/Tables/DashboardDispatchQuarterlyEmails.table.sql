CREATE TABLE [dbo].[DashboardDispatchQuarterlyEmails] (
    [QuarterlyEmailId]     UNIQUEIDENTIFIER NOT NULL,
	[ApplicationName]      NVARCHAR (64)     NOT NULL,
    [To]                   NVARCHAR (128)   NOT NULL,
	[Subject]              NVARCHAR (255)   NOT NULL,
	[Quarter]              INT              NOT NULL,
	[Year]                 INT              NOT NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

