ALTER TABLE [dbo].[AuthenticationOAuthExternalAuthenticators]
    ADD CONSTRAINT [PK_AuthenticationOAuthExternalAuthenticators] PRIMARY KEY CLUSTERED ([ExternalAuthenticatorId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

