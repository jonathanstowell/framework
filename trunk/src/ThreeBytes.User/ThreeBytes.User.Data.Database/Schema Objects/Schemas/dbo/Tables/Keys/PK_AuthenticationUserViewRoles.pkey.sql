﻿ALTER TABLE [dbo].[AuthenticationUserViewRoles]
    ADD CONSTRAINT [PK_AuthenticationUserViewRoles] PRIMARY KEY CLUSTERED ([RoleId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

