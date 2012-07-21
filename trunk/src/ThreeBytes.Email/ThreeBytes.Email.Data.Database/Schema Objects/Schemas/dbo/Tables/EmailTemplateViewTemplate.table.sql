CREATE TABLE [dbo].[EmailTemplateViewTemplate] (
    [TemplateId]           UNIQUEIDENTIFIER  NOT NULL,
    [ItemId]               UNIQUEIDENTIFIER  NOT NULL,
	[ApplicationName]      VARCHAR (64)      NOT NULL,
    [Name]                 NVARCHAR (64)     NOT NULL,
    [From]                 NVARCHAR (128)    NOT NULL,
    [Body]                 NVARCHAR (MAX)    NOT NULL,
    [Subject]              NVARCHAR (255)    NOT NULL,
    [IsHtml]               BIT               NOT NULL,
    [Encoding]             NVARCHAR (16)     NOT NULL,
    [CreationDateTime]     DATETIME          NOT NULL,
    [LastModifiedDateTime] DATETIME          NULL,
    [Operation]            NVARCHAR (MAX)    NULL
);

