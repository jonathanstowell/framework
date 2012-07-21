CREATE TABLE [dbo].[NewsListNewsArticles] (
    [NewsArticleId]        UNIQUEIDENTIFIER NOT NULL,
    [Content]              NVARCHAR (200)   NOT NULL,
    [Title]                NVARCHAR (100)   NOT NULL,
    [CreatedBy]            NVARCHAR (35)    NOT NULL,  
    [LastModifiedBy]       NVARCHAR (35)    NULL,    
    [CreationDateTime]     DATETIME         NOT NULL,
    [LastModifiedDateTime] DATETIME         NULL
);

