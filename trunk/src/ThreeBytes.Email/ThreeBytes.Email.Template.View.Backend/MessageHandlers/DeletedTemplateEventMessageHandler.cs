using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.Messages.Commands;
using ThreeBytes.Email.Template.View.Entities;
using ThreeBytes.Email.Template.View.Service.Abstract;
using ThreeBytes.Email.Template.View.Validations.Abstract;

namespace ThreeBytes.Email.Template.View.Backend.MessageHandlers
{
    public class DeletedTemplateEventMessageHandler : IHandleMessages<IDeleteTemplateCommandMessage>
    {
        private readonly IEmailTemplateViewTemplateService service;
        private readonly IEmailTemplateViewTemplateValidatorResolver validatorResolver;

        public DeletedTemplateEventMessageHandler(IEmailTemplateViewTemplateService service, IEmailTemplateViewTemplateValidatorResolver validatorResolver)
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

            EmailTemplateViewTemplate template = service.GetById(message.Id);

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
