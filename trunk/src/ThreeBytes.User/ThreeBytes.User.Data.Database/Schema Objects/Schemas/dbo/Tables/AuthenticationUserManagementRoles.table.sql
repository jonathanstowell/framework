CREATE TABLE [dbo].[AuthenticationUserManagementRoles] (
    [RoleId]               UNIQUEIDENTIFIER NOT NULL,
    [Name]                 VARCHAR (64)     NOT NULL,
    [ApplicationName]      VARCHAR (64)     NOT NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

