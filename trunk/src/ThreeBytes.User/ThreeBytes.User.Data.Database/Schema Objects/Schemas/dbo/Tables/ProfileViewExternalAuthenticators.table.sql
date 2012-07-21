CREATE TABLE [dbo].[ProfileViewExternalAuthenticators]
(
	[ExternalAuthenticatorId]          UNIQUEIDENTIFIER		NOT NULL,
	[ExternalIdentifier]               VARCHAR (256)		NOT NULL,
	[Username]                         VARCHAR (64)			NOT NULL,
	[Email]							   VARCHAR (128)		NOT NULL,
	[ExternalAuthenticationType]       VARCHAR (64)			NOT NULL,
	[ProfileId]                        UNIQUEIDENTIFIER		NOT NULL,
	[CreationDateTime]                 DATETIME				NOT NULL,
    [LastModifiedDateTime]             DATETIME				NULL
)
