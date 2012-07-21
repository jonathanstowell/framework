CREATE TABLE [dbo].[AuthenticationOAuthExternalAuthenticators]
(
	[ExternalAuthenticatorId]          UNIQUEIDENTIFIER		NOT NULL,
	[ExternalIdentifier]               VARCHAR (256)		NOT NULL,
	[Username]                         VARCHAR (64)			NOT NULL,
	[Email]							   VARCHAR (128)		NOT NULL,
	[Token]							   VARCHAR (255)		NOT NULL,
	[TokenSecret]					   VARCHAR (255)		NULL,
	[ExternalAuthenticationType]       VARCHAR (64)			NOT NULL,
	[UserId]                           UNIQUEIDENTIFIER		NOT NULL,
	[CreationDateTime]                 DATETIME				NOT NULL,
    [LastModifiedDateTime]             DATETIME				NULL
)
