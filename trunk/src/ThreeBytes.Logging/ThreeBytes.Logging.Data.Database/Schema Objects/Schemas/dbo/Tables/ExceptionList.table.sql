CREATE TABLE [dbo].[ExceptionList] (
    [ExceptionId]          UNIQUEIDENTIFIER NOT NULL,
    [Message]              NVARCHAR (MAX)   NULL,
    [Source]               NVARCHAR (MAX)   NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

