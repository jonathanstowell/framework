CREATE TABLE [dbo].[ThespianListThespians] (
    [ThespianId]						UNIQUEIDENTIFIER NOT NULL,
    [FirstName]							NVARCHAR (35)    NOT NULL,
    [LastName]							NVARCHAR (35)    NOT NULL,
	[ProfileImageLocation]				NVARCHAR (100)   NULL,
    [ProfileThumbnailImageLocation]		NVARCHAR (100)   NULL,
	[Gender]							NVARCHAR (6)     NOT NULL,
	[ThespianType]						NVARCHAR (14)    NOT NULL,
	[CreatedBy]							NVARCHAR (35)    NOT NULL,  
    [LastModifiedBy]					NVARCHAR (35)    NULL,
    [CreationDateTime]					DATETIME         NOT NULL,
    [LastModifiedDateTime]				DATETIME         NULL
);

