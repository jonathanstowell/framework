CREATE TABLE [dbo].[TeamViewEmployees] (
    [EmployeeId]						UNIQUEIDENTIFIER NOT NULL,
    [ItemId]							UNIQUEIDENTIFIER NOT NULL,
    [FirstName]							NVARCHAR (35)    NOT NULL,
    [LastName]							NVARCHAR (35)    NOT NULL,
    [JobTitle]							NVARCHAR (50)    NOT NULL,
    [ProfileImageLocation]				NVARCHAR (100)   NULL,
    [ProfileThumbnailImageLocation]		NVARCHAR (100)   NULL,  
    [Summary]							NVARCHAR (MAX)   NULL,
	[Operation]							NVARCHAR (MAX)   NULL,
	[CreatedBy]							NVARCHAR (35)    NOT NULL,  
    [LastModifiedBy]					NVARCHAR (35)    NULL,
    [CreationDateTime]					DATETIME         NOT NULL,
    [LastModifiedDateTime]				DATETIME         NULL
);

