ALTER TABLE [dbo].[ProfileViewExternalAuthenticators]
    ADD CONSTRAINT [PK_ProfileViewExternalAuthenticators] PRIMARY KEY CLUSTERED ([ExternalAuthenticatorId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

