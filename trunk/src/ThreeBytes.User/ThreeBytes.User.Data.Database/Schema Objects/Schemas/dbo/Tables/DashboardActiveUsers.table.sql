CREATE TABLE [dbo].[DashboardActiveUsers] (
    [ActiveUserId]         UNIQUEIDENTIFIER NOT NULL,
    [Username]             NVARCHAR (64)       NOT NULL,
    [ApplicationName]      NVARCHAR (64)       NOT NULL,
    [Logins]               INT	            NOT NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

