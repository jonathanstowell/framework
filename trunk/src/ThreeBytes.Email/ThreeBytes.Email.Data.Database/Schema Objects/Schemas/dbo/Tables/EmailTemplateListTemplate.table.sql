CREATE TABLE [dbo].[EmailTemplateListTemplate] (
    [TemplateId]           UNIQUEIDENTIFIER  NOT NULL,
	[ApplicationName]      VARCHAR (64)      NOT NULL,
    [Name]                 NVARCHAR (64)     NOT NULL,
    [From]                 NVARCHAR (128)    NOT NULL,
    [Subject]              NVARCHAR (255)    NOT NULL,
    [IsHtml]               BIT               NOT NULL,
    [Encoding]             NVARCHAR (16)     NOT NULL,
    [CreationDateTime]     DATETIME          NOT NULL,
    [LastModifiedDateTime] DATETIME          NULL
);

