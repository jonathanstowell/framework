CREATE TABLE [dbo].[AuthenticationUserViewUsers] (
    [UserId]                           UNIQUEIDENTIFIER NOT NULL,
    [ItemId]                           UNIQUEIDENTIFIER NOT NULL,
    [Username]                         VARCHAR (64)     NOT NULL,
    [ApplicationName]                  VARCHAR (64)     NOT NULL,
    [Email]                            VARCHAR (128)    NOT NULL,
    [IsVerified]                       BIT              NULL,
    [VerifiedCode]                     UNIQUEIDENTIFIER NULL,
    [IsOriginalAdministrator]          BIT              NULL,
    [IsLockedOut]                      BIT              NULL,
    [UnlockCode]                       UNIQUEIDENTIFIER NULL,
    [FailedPasswordAttemptCount]       INT              NULL,
    [FailedPasswordAttemptWindowStart] DATETIME         NULL,
    [CreationDateTime]                 DATETIME         NOT NULL,
    [LastModifiedDateTime]             DATETIME         NULL,
    [Operation]                        NVARCHAR (MAX)   NULL
);

