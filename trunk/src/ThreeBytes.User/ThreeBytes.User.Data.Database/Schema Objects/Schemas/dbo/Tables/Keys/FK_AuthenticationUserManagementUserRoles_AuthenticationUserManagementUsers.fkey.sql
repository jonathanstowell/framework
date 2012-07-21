ALTER TABLE [dbo].[AuthenticationUserManagementUserRoles]
    ADD CONSTRAINT [FK_AuthenticationUserManagementUserRoles_AuthenticationUserManagementUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AuthenticationUserManagementUsers] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

