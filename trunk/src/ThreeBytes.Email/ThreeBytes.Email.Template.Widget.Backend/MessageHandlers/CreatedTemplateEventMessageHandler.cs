using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.Messages.InternalEvents;
using ThreeBytes.Email.Template.Widget.Entities;
using ThreeBytes.Email.Template.Widget.Service.Abstract;
using ThreeBytes.Email.Template.Widget.Validations.Abstract;

namespace ThreeBytes.Email.Template.Widget.Backend.MessageHandlers
{
    public class CreatedTemplateEventMessageHandler : IHandleMessages<ICreatedTemplateInternalEventMessage>
    {
        private readonly IEmailTemplateWidgetTemplateService service;
        private readonly IEmailTemplateWidgetTemplateValidatorResolver validatorResolver;

        public CreatedTemplateEventMessageHandler(IEmailTemplateWidgetTemplateService service, IEmailTemplateWidgetTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreatedTemplateInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailTemplateWidgetTemplate template = new EmailTemplateWidgetTemplate
            {
                Id = message.Id,
                Name = message.Name,
                ApplicationName = message.ApplicationName,
                Subject = message.Subject
            };

            ValidationResult result = validatorResolver.CreateValidator().Validate(template);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add Template", result);
            }

            service.Create(template);
        }
    }
}
