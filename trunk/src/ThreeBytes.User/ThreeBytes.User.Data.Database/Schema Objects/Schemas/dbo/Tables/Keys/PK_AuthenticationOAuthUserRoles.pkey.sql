﻿ALTER TABLE [dbo].[AuthenticationOAuthUserRoles]
    ADD CONSTRAINT [PK_AuthenticationOAuthUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

