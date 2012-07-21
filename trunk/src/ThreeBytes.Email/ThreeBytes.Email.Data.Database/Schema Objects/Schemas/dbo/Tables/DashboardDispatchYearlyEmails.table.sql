CREATE TABLE [dbo].[DashboardDispatchYearlyEmails] (
    [YearlyEmailId]        UNIQUEIDENTIFIER NOT NULL,
	[ApplicationName]      NVARCHAR (64)     NOT NULL,
    [To]                   NVARCHAR (128)   NOT NULL,
	[Subject]              NVARCHAR (255)   NOT NULL,
	[Year]				   INT              NOT NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

