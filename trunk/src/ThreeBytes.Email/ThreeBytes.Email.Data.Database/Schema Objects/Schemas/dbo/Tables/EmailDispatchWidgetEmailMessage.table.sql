CREATE TABLE [dbo].[EmailDispatchWidgetEmailMessage] (
    [EmailMessageId]       UNIQUEIDENTIFIER  NOT NULL,
	[ApplicationName]      VARCHAR (64)      NOT NULL,
    [To]                   NVARCHAR (128)    NOT NULL,
	[Subject]              NVARCHAR (128)    NOT NULL,
    [CreationDateTime]     DATETIME          NOT NULL,
    [LastModifiedDateTime] DATETIME          NULL
);

