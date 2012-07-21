ALTER TABLE [dbo].[AuthenticationLoginUserRoles]
    ADD CONSTRAINT [FK_AuthenticationLoginUserRoles_AuthenticationLoginRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AuthenticationLoginRoles] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

