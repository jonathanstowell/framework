﻿ALTER TABLE [dbo].[AuthenticationRegistrationExternalUsers]
    ADD CONSTRAINT [PK_AuthenticationRegistrationExternalUsers] PRIMARY KEY CLUSTERED ([UserId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

