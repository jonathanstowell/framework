ALTER TABLE [dbo].[AuthenticationRegistrationExternalAuthenticators]
    ADD CONSTRAINT [PK_AuthenticationRegistrationExternalAuthenticators] PRIMARY KEY CLUSTERED ([ExternalAuthenticatorId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

