CREATE TABLE [dbo].[AuthenticationRegistrationExternalUsers] (
    [UserId]                           UNIQUEIDENTIFIER NOT NULL,
    [Username]                         VARCHAR (64)     NOT NULL,
    [ApplicationName]                  VARCHAR (64)     NOT NULL,
    [CreationDateTime]                 DATETIME         NOT NULL,
    [LastModifiedDateTime]             DATETIME         NULL
);

