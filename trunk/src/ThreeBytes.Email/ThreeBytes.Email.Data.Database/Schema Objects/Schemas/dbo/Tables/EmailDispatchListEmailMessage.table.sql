CREATE TABLE [dbo].[EmailDispatchListEmailMessage] (
    [EmailMessageId]       UNIQUEIDENTIFIER  NOT NULL,
	[ApplicationName]      NVARCHAR (64)      NOT NULL,
    [From]                 NVARCHAR (128)    NOT NULL,
    [To]                   NVARCHAR (128)    NOT NULL,
    [CC]                   NVARCHAR (MAX)    NULL,
    [BCC]                  NVARCHAR (MAX)    NULL,
	[Subject]              NVARCHAR (255)    NOT NULL,
    [IsHtml]               BIT               NOT NULL,
    [Encoding]             NVARCHAR (16)     NOT NULL,
    [CreationDateTime]     DATETIME          NOT NULL,
    [LastModifiedDateTime] DATETIME          NULL
);

