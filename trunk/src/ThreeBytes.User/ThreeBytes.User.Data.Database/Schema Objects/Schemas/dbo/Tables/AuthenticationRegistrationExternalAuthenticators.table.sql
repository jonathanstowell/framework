CREATE TABLE [dbo].[AuthenticationRegistrationExternalAuthenticators]
(
	[ExternalAuthenticatorId]          UNIQUEIDENTIFIER		NOT NULL,
	[ExternalIdentifier]               VARCHAR (256)		NOT NULL,
	[ApplicationName]				   VARCHAR (64)			NOT NULL,
	[Username]                         VARCHAR (64)			NOT NULL,
	[Email]							   VARCHAR (128)		NOT NULL,
	[ExternalAuthenticationType]       VARCHAR (64)			NOT NULL,
	[UserId]                           UNIQUEIDENTIFIER		NOT NULL,
	[CreationDateTime]                 DATETIME				NOT NULL,
    [LastModifiedDateTime]             DATETIME				NULL
)
