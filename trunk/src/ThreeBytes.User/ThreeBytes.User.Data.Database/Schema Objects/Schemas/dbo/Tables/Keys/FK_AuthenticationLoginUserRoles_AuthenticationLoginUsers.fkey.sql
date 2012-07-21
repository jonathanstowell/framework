ALTER TABLE [dbo].[AuthenticationLoginUserRoles]
    ADD CONSTRAINT [FK_AuthenticationLoginUserRoles_AuthenticationLoginUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AuthenticationLoginUsers] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

