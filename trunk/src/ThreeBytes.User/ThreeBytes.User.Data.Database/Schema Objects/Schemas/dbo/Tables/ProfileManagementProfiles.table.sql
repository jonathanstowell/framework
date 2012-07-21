CREATE TABLE [dbo].[ProfileManagementProfiles] (
    [ProfileId]            UNIQUEIDENTIFIER NOT NULL,
    [Username]             VARCHAR (64)     NOT NULL,
    [ApplicationName]      VARCHAR (64)     NOT NULL,
	[Email]                VARCHAR (128)    NOT NULL,
    [Forename]			   VARCHAR (64)     NULL,
    [Surname]			   VARCHAR (64)     NULL,
    [FullName]             VARCHAR (64)     NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

