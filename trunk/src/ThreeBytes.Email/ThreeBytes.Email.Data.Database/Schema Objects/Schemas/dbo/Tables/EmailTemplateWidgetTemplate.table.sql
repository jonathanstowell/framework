CREATE TABLE [dbo].[EmailTemplateWidgetTemplate] (
    [TemplateId]           UNIQUEIDENTIFIER  NOT NULL,
	[ApplicationName]      VARCHAR (64)      NOT NULL,
    [Name]                 NVARCHAR (64)     NOT NULL,
    [Subject]              NVARCHAR (255)    NOT NULL,
    [CreationDateTime]     DATETIME          NOT NULL,
    [LastModifiedDateTime] DATETIME          NULL
);

