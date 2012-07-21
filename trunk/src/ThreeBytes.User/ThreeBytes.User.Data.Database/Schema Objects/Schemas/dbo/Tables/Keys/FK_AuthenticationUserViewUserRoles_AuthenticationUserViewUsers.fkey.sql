ALTER TABLE [dbo].[AuthenticationUserViewUserRoles]
    ADD CONSTRAINT [FK_AuthenticationUserViewUserRoles_AuthenticationUserViewUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AuthenticationUserViewUsers] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

