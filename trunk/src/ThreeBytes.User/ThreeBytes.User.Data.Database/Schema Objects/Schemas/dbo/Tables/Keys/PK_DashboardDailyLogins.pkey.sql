﻿ALTER TABLE [dbo].[DashboardDailyLogins]
    ADD CONSTRAINT [PK_DashboardDailyLogins] PRIMARY KEY CLUSTERED ([DailyLoginId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

