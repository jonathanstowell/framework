using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.List.Entities;
using ThreeBytes.Email.Template.List.Service.Abstract;
using ThreeBytes.Email.Template.List.Validations.Abstract;
using ThreeBytes.Email.Template.Messages.Commands;

namespace ThreeBytes.Email.Template.List.Backend.MessageHandlers
{
    public class DeletedTemplateEventMessageHandler : IHandleMessages<IDeleteTemplateCommandMessage>
    {
        private readonly IEmailTemplateListTemplateService service;
        private readonly IEmailTemplateListTemplateValidatorResolver validatorResolver;

        public DeletedTemplateEventMessageHandler(IEmailTemplateListTemplateService service, IEmailTemplateListTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IDeleteTemplateCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailTemplateListTemplate template = service.GetById(message.Id);

            if (template == null)
                return;

            ValidationResult result = validatorResolver.DeleteValidator().Validate(template);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could delete Template", result);
            }

            service.Delete(template);
        }
    }
}
