CREATE TABLE [dbo].[DashboardMonthlyRegistrations] (
    [MonthlyRegistrationId]       UNIQUEIDENTIFIER NOT NULL,
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [Username]             NVARCHAR (64)       NOT NULL,
    [ApplicationName]      NVARCHAR (64)       NOT NULL,
    [Month]				   INT         NOT NULL,
	[Year]                 INT         NOT NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

