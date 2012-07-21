CREATE TABLE [dbo].[AuthenticationRegistrationUsers] (
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [Username]             VARCHAR (64)     NOT NULL,
    [ApplicationName]      VARCHAR (64)     NOT NULL,
    [Email]                VARCHAR (128)    NOT NULL,
    [Password]             VARCHAR (64)     NOT NULL,
    [ConfirmPassword]      VARCHAR (64)     NOT NULL,
    [IsVerified]           BIT              NULL,
    [VerifiedCode]         UNIQUEIDENTIFIER NOT NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

