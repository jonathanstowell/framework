﻿ALTER TABLE [dbo].[ExceptionList]
    ADD CONSTRAINT [PK_ExceptionList] PRIMARY KEY CLUSTERED ([ExceptionId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

