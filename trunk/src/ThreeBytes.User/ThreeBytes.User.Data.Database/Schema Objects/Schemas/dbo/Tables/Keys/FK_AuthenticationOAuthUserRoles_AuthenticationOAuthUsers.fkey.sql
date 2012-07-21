ALTER TABLE [dbo].[AuthenticationOAuthUserRoles]
    ADD CONSTRAINT [FK_AuthenticationOAuthUserRoles_AuthenticationOAuthUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AuthenticationOAuthUsers] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

