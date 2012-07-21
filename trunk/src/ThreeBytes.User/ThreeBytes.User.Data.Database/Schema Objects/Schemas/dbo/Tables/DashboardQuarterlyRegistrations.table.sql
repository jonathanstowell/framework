CREATE TABLE [dbo].[DashboardQuarterlyRegistrations] (
    [QuarterlyRegistrationId]     UNIQUEIDENTIFIER NOT NULL,
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [Username]             NVARCHAR (64)       NOT NULL,
    [ApplicationName]      NVARCHAR (64)       NOT NULL,
    [Quarter]			   INT         NOT NULL,
	[Year]                 INT         NOT NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

