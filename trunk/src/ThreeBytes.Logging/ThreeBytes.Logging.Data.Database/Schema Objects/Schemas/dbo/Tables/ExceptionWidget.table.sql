CREATE TABLE [dbo].[ExceptionWidget] (
    [ExceptionId]          UNIQUEIDENTIFIER NOT NULL,
    [Message]              NVARCHAR (50)    NULL,
    [Source]               NVARCHAR (50)    NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

