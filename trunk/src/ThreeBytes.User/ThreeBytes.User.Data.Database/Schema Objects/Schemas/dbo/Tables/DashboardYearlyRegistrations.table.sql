CREATE TABLE [dbo].[DashboardYearlyRegistrations] (
    [YearlyRegistrationId]     UNIQUEIDENTIFIER NOT NULL,
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [Username]             NVARCHAR (64)       NOT NULL,
    [ApplicationName]      NVARCHAR (64)       NOT NULL,
	[Year]                 INT				NOT NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

