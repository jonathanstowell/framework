CREATE TABLE [dbo].[DashboardDispatchDailyEmails] (
    [DailyEmailId]         UNIQUEIDENTIFIER  NOT NULL,
	[ApplicationName]      NVARCHAR (64)      NOT NULL,
    [To]                   NVARCHAR (128)    NOT NULL,
	[Subject]              NVARCHAR (255)    NOT NULL,
	[DispatchDate]         DATETIME          NOT NULL,
    [CreationDateTime]     DATETIME          NOT NULL,
    [LastModifiedDateTime] DATETIME          NULL
);

