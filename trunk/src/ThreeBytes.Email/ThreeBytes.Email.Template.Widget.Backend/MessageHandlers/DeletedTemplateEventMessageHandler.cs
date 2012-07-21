using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.Messages.Commands;
using ThreeBytes.Email.Template.Widget.Entities;
using ThreeBytes.Email.Template.Widget.Service.Abstract;
using ThreeBytes.Email.Template.Widget.Validations.Abstract;

namespace ThreeBytes.Email.Template.Widget.Backend.MessageHandlers
{
    public class DeletedTemplateEventMessageHandler : IHandleMessages<IDeleteTemplateCommandMessage>
    {
        private readonly IEmailTemplateWidgetTemplateService service;
        private readonly IEmailTemplateWidgetTemplateValidatorResolver validatorResolver;

        public DeletedTemplateEventMessageHandler(IEmailTemplateWidgetTemplateService service, IEmailTemplateWidgetTemplateValidatorResolver validatorResolver)
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

            EmailTemplateWidgetTemplate template = service.GetById(message.Id);

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
