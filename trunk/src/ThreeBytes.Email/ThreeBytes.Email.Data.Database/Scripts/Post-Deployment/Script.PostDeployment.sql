/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [ThreeBytesEmail].[dbo].[EmailDispatchManagementTemplate]
           ([TemplateId]
           ,[Name]
           ,[ApplicationName]
           ,[From]
           ,[Body]
           ,[Subject]
           ,[IsHtml]
           ,[Encoding]
           ,[CreationDateTime]
           ,[LastModifiedDateTime])
     VALUES
           (NEWID()
           ,'Welcome'
           ,'Generic'
           ,'welcome@threebytes.com'
		   ,'<html><body>Welcome [Username] to Three Bytes <br /><br /> To unlock your account visit the Verify Account page and use the unlock code: [VerifiedCode]</body></html>'
           ,'Welcome to Three Bytes'
           ,1
           ,'ASCII'
           ,CURRENT_TIMESTAMP
           ,CURRENT_TIMESTAMP)

INSERT INTO [ThreeBytesEmail].[dbo].[EmailDispatchManagementTemplate]
           ([TemplateId]
           ,[Name]
           ,[ApplicationName]
           ,[From]
           ,[Body]
           ,[Subject]
           ,[IsHtml]
           ,[Encoding]
           ,[CreationDateTime]
           ,[LastModifiedDateTime])
     VALUES
           (NEWID()
           ,'UnlockAccount'
           ,'Generic'
           ,'unlock@threebytes.com'
		   ,'[Username] it seems someone has attempted to enter your Three Bytes password too many times. To reset visit the unlock account page and enter code: [UnlockCode]'
           ,'Unlock Three Bytes Account'
           ,0
           ,'ASCII'
           ,CURRENT_TIMESTAMP
           ,CURRENT_TIMESTAMP)

INSERT INTO [ThreeBytesEmail].[dbo].[EmailDispatchManagementTemplate]
           ([TemplateId]
           ,[Name]
           ,[ApplicationName]
           ,[From]
           ,[Body]
           ,[Subject]
           ,[IsHtml]
           ,[Encoding]
           ,[CreationDateTime]
           ,[LastModifiedDateTime])
     VALUES
           (NEWID()
           ,'ResetPassword'
           ,'Generic'
           ,'resetpassword@threebytes.com'
		   ,'[Username] you have requested to reset your password. Here is your reset code: [ResetPasswordCode]. Please reset your password by visiting the Reset Password page.'
           ,'Reset Three Bytes Account Password'
           ,0
           ,'ASCII'
           ,CURRENT_TIMESTAMP
           ,CURRENT_TIMESTAMP)

INSERT INTO [ThreeBytesEmail].[dbo].[EmailDispatchManagementTemplate]
           ([TemplateId]
           ,[Name]
           ,[ApplicationName]
           ,[From]
           ,[Body]
           ,[Subject]
           ,[IsHtml]
           ,[Encoding]
           ,[CreationDateTime]
           ,[LastModifiedDateTime])
     VALUES
           (NEWID()
           ,'ResetPasswordConfirmed'
           ,'Generic'
           ,'resetpassword@threebytes.com'
		   ,'[Username] your password has been reset'
           ,'Reset Three Bytes Account Password Confirm'
           ,0
           ,'ASCII'
           ,CURRENT_TIMESTAMP
           ,CURRENT_TIMESTAMP)