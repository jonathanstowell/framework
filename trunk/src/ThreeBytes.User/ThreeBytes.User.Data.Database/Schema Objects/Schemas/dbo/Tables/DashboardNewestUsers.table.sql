CREATE TABLE [dbo].[DashboardNewestUsers] (
    [NewestUserId]         UNIQUEIDENTIFIER NOT NULL,
    [Username]             NVARCHAR (64)       NOT NULL,
    [ApplicationName]      NVARCHAR (64)       NOT NULL,
	[RegistrationDateTime] DATETIME         NOT NULL,                                                         
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

