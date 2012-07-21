CREATE TABLE [dbo].[RoleViewRoles] (
    [RoleId]               UNIQUEIDENTIFIER NOT NULL,
    [ItemId]               UNIQUEIDENTIFIER NOT NULL,
    [Name]                 VARCHAR (64)     NOT NULL,
    [ApplicationName]      VARCHAR (64)     NOT NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL,
    [Operation]            NVARCHAR (MAX)   NULL
);

