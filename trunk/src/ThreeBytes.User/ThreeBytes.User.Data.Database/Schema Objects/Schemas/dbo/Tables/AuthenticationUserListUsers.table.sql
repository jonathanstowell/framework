CREATE TABLE [dbo].[AuthenticationUserListUsers] (
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [Username]             VARCHAR (64)     NOT NULL,
    [ApplicationName]      VARCHAR (64)     NOT NULL,
    [Email]                VARCHAR (128)    NOT NULL,
    [IsVerified]           BIT              NULL,
    [IsLockedOut]          BIT              NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

