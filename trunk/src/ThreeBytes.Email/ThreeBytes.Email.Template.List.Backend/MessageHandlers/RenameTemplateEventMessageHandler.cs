using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.List.Entities;
using ThreeBytes.Email.Template.List.Service.Abstract;
using ThreeBytes.Email.Template.List.Validations.Abstract;
using ThreeBytes.Email.Template.Messages.InternalEvents;

namespace ThreeBytes.Email.Template.List.Backend.MessageHandlers
{
    public class RenameTemplateEventMessageHandler : IHandleMessages<IRenamedTemplateInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateListTemplateService service;
        private readonly IEmailTemplateListTemplateValidatorResolver validatorResolver;

        public RenameTemplateEventMessageHandler(IEmailTemplateListTemplateService service, IEmailTemplateListTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRenamedTemplateInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailTemplateListTemplate templateToUpdate = service.GetById(message.Id);

            if (templateToUpdate == null)
                return;

            templateToUpdate.Name = message.Name;

            ValidationResult result = validatorResolver.RenameValidator().Validate(templateToUpdate);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            service.Update(templateToUpdate);
        }
    }
}
