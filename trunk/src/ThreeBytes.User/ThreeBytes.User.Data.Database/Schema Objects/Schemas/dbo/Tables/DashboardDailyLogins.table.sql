CREATE TABLE [dbo].[DashboardDailyLogins] (
    [DailyLoginId]         UNIQUEIDENTIFIER NOT NULL,
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [Username]             NVARCHAR (64)       NOT NULL,
    [ApplicationName]      NVARCHAR (64)       NOT NULL,
    [LoginDate]            DATETIME         NOT NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

