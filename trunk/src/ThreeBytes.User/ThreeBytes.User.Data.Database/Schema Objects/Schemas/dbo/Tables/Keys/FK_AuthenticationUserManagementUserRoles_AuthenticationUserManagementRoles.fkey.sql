ALTER TABLE [dbo].[AuthenticationUserManagementUserRoles]
    ADD CONSTRAINT [FK_AuthenticationUserManagementUserRoles_AuthenticationUserManagementRoles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AuthenticationUserManagementRoles] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

