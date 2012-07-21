CREATE TABLE [dbo].[AuthenticationOAuthUsers] (
    [UserId]                           UNIQUEIDENTIFIER NOT NULL,
    [Username]                         VARCHAR (64)     NOT NULL,
	[Email]							   VARCHAR (128)    NOT NULL,
    [ApplicationName]                  VARCHAR (64)     NOT NULL,
    [CreationDateTime]                 DATETIME         NOT NULL,
    [LastModifiedDateTime]             DATETIME         NULL
);

