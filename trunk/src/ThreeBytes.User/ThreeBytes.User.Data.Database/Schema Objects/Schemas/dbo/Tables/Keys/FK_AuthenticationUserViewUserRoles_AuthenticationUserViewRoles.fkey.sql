ALTER TABLE [dbo].[AuthenticationUserViewUserRoles]
    ADD CONSTRAINT [FK_AuthenticationUserViewUserRoles_AuthenticationUserViewRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AuthenticationUserViewRoles] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

