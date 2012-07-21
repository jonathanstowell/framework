using System;
using FluentValidation;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.Management.Entities;
using ThreeBytes.Email.Template.Management.Entities.Enums;
using ThreeBytes.Email.Template.Management.Service.Abstract;
using ThreeBytes.Email.Template.Management.Validations.Abstract;
using ThreeBytes.Email.Template.Messages.Commands;
using ThreeBytes.Email.Template.Messages.InternalEvents;

namespace ThreeBytes.Email.Template.Management.Backend.MessageHandlers
{
    public class UpdateTemplateEmailContentsCommandMessageHandler : IHandleMessages<IUpdateTemplateEmailContentsCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateManagementTemplateService service;
        private readonly IEmailTemplateManagementTemplateValidatorResolver validatorResolver;

        public UpdateTemplateEmailContentsCommandMessageHandler(IEmailTemplateManagementTemplateService service, IEmailTemplateManagementTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdateTemplateEmailContentsCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailTemplateManagementTemplate templateToUpdate = service.GetById(message.Id);

            if (templateToUpdate == null)
                return;

            templateToUpdate.Subject = message.Subject;
            templateToUpdate.Body = message.Body;
            templateToUpdate.IsHtml = message.IsHtml;
            templateToUpdate.Encoding = (Encoding) Enum.Parse(typeof (Encoding), message.Encoding);

            ValidationResult result = validatorResolver.UpdateContentsValidator().Validate(templateToUpdate);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            service.Update(templateToUpdate);

            Bus.PublishAndSendLocal<ITemplateEmailContentsUpdatedInternalEventMessage>(x =>
            {
                x.Id = templateToUpdate.Id;
                x.Subject = templateToUpdate.Subject;
                x.Body = templateToUpdate.Body;
                x.IsHtml = templateToUpdate.IsHtml;
                x.Encoding = templateToUpdate.Encoding.ToString();
            });
        }
    }
}
