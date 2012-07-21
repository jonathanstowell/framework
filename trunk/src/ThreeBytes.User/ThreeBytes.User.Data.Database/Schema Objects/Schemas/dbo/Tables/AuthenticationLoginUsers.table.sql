CREATE TABLE [dbo].[AuthenticationLoginUsers] (
    [UserId]                           UNIQUEIDENTIFIER NOT NULL,
    [Username]                         VARCHAR (64)     NOT NULL,
    [ApplicationName]                  VARCHAR (64)     NOT NULL,
    [Email]                            VARCHAR (128)    NOT NULL,
    [Password]                         VARCHAR (64)     NOT NULL,
    [IsVerified]                       BIT              NULL,
    [IsLockedOut]                      BIT              NULL,
    [FailedPasswordAttemptCount]       INT              NULL,
    [FailedPasswordAttemptWindowStart] DATETIME         NULL,
    [CreationDateTime]                 DATETIME         NOT NULL,
    [LastModifiedDateTime]             DATETIME         NULL
);

