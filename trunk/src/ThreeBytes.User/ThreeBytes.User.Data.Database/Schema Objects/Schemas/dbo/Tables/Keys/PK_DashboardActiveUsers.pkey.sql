﻿ALTER TABLE [dbo].[DashboardActiveUsers]
    ADD CONSTRAINT [PK_DashboardActiveUsers] PRIMARY KEY CLUSTERED ([ActiveUserId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

