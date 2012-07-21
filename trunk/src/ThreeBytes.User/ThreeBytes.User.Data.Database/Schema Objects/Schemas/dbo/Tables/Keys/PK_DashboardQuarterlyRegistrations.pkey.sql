ALTER TABLE [dbo].[DashboardQuarterlyRegistrations]
    ADD CONSTRAINT [PK_DashboardQuarterlyRegistrations] PRIMARY KEY CLUSTERED ([QuarterlyRegistrationId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

