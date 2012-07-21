using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.List.Entities;
using ThreeBytes.Email.Template.List.Entities.Enums;
using ThreeBytes.Email.Template.List.Service.Abstract;
using ThreeBytes.Email.Template.List.Validations.Abstract;
using ThreeBytes.Email.Template.Messages.InternalEvents;

namespace ThreeBytes.Email.Template.List.Backend.MessageHandlers
{
    public class UpdateTemplateEmailContentsEventMessageHandler : IHandleMessages<ITemplateEmailContentsUpdatedInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateListTemplateService service;
        private readonly IEmailTemplateListTemplateValidatorResolver validatorResolver;

        public UpdateTemplateEmailContentsEventMessageHandler(IEmailTemplateListTemplateService service, IEmailTemplateListTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ITemplateEmailContentsUpdatedInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailTemplateListTemplate templateToUpdate = service.GetById(message.Id);

            if (templateToUpdate == null)
                return;

            templateToUpdate.Subject = message.Subject;
            templateToUpdate.IsHtml = message.IsHtml;
            templateToUpdate.Encoding = (Encoding) Enum.Parse(typeof (Encoding), message.Encoding);

            ValidationResult result = validatorResolver.UpdateContentsValidator().Validate(templateToUpdate);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            service.Update(templateToUpdate);
        }
    }
}
