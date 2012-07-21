ALTER TABLE [dbo].[AuthenticationOAuthUserRoles]
    ADD CONSTRAINT [FK_AuthenticationOAuthUserRoles_AuthenticationOAuthRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AuthenticationOAuthRoles] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

