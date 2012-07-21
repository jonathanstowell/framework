using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.Management.Entities;
using ThreeBytes.Email.Template.Management.Entities.Enums;
using ThreeBytes.Email.Template.Management.Service.Abstract;
using ThreeBytes.Email.Template.Management.Validations.Abstract;
using ThreeBytes.Email.Template.Messages.InternalEvents;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.Email.Template.Management.Backend.MessageHandlers
{
    public class UserSystemFirstUseSetupExternalEventHandler : IHandleMessages<ISetupUserSystemExternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateManagementTemplateService service;
        private readonly IEmailTemplateManagementTemplateValidatorResolver validatorResolver;

        public UserSystemFirstUseSetupExternalEventHandler(IEmailTemplateManagementTemplateService service, IEmailTemplateManagementTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ISetupUserSystemExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            IList<EmailTemplateManagementTemplate> templates = new List<EmailTemplateManagementTemplate>();

            EmailTemplateManagementTemplate welcomeTemplate = new EmailTemplateManagementTemplate
            {
                Name = "Welcome",
                ApplicationName = message.ApplicationName,
                Encoding = Encoding.ASCII,
                From = string.Format("welcome@{0}.com", message.ApplicationName.ToLower()),
                IsHtml = true,
                Subject = string.Format("Welcome to {0}", message.ApplicationName),
                Body = string.Format("<html><body>Welcome [Username] to {0} <br /><br /> To unlock your account visit the Verify Account page and use the unlock code: [VerifiedCode]</body></html>", message.ApplicationName)
            };

            EmailTemplateManagementTemplate unlockTemplate = new EmailTemplateManagementTemplate
            {
                Name = "UnlockAccount",
                ApplicationName = message.ApplicationName,
                Encoding = Encoding.ASCII,
                From = string.Format("unlock@{0}.com", message.ApplicationName.ToLower()),
                IsHtml = false,
                Subject = string.Format("Unlock your {0} account", message.ApplicationName),
                Body = string.Format("[Username] it seems someone has attempted to enter your {0} password too many times. To reset visit the unlock account page and enter code: [UnlockCode]", message.ApplicationName)
            };

            EmailTemplateManagementTemplate passwordResetTemplate = new EmailTemplateManagementTemplate
            {
                Name = "ResetPassword",
                ApplicationName = message.ApplicationName,
                Encoding = Encoding.ASCII,
                From = string.Format("resetpassword@{0}.com", message.ApplicationName.ToLower()),
                IsHtml = false,
                Subject = string.Format("Reset {0} Account Passwor", message.ApplicationName),
                Body = string.Format("[Username] you have requested to reset your {0} password. Here is your reset code: [ResetPasswordCode]. Please reset your password by visiting the Reset Password page.", message.ApplicationName)
            };

            EmailTemplateManagementTemplate confirmPasswordResetTemplate = new EmailTemplateManagementTemplate
            {
                Name = "ResetPasswordConfirmed",
                ApplicationName = message.ApplicationName,
                Encoding = Encoding.ASCII,
                From = string.Format("resetpassword@{0}.com", message.ApplicationName.ToLower()),
                IsHtml = false,
                Subject = string.Format("Reset {0} Account Password Confirm", message.ApplicationName),
                Body = string.Format("[Username] your {0} password has been reset", message.ApplicationName)
            };

            templates.Add(welcomeTemplate);
            templates.Add(unlockTemplate);
            templates.Add(passwordResetTemplate);
            templates.Add(confirmPasswordResetTemplate);

            foreach (var template in templates)
            {
                ValidationResult result = validatorResolver.CreateValidator().Validate(template);

                if (!result.IsValid)
                {
                    throw new AsyncServiceValidationException("Could not add Template", result);
                }
            }

            service.Create(templates);

            foreach (var template in templates)
            {
                Bus.PublishAndSendLocal<ICreatedTemplateInternalEventMessage>(x =>
                {
                    x.Id = template.Id;
                    x.Name = template.Name;
                    x.ApplicationName = template.ApplicationName;
                    x.Encoding = template.Encoding.ToString();
                    x.From = template.From;
                    x.IsHtml = template.IsHtml;
                    x.Subject = template.Subject;
                    x.Body = template.Body;
                });
            }
        }
    }
}
