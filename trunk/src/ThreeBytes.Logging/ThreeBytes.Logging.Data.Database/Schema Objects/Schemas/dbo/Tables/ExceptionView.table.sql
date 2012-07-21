CREATE TABLE [dbo].[ExceptionView] (
    [ExceptionId]          UNIQUEIDENTIFIER NOT NULL,
    [Message]              NVARCHAR (MAX)   NULL,
    [Source]               NVARCHAR (MAX)   NULL,
    [StackTrace]           NVARCHAR (MAX)   NULL,
    [InnerException]       NVARCHAR (MAX)   NULL,
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

