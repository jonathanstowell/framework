using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.Messages.InternalEvents;
using ThreeBytes.Email.Template.View.Entities;
using ThreeBytes.Email.Template.View.Entities.Enums;
using ThreeBytes.Email.Template.View.Service.Abstract;
using ThreeBytes.Email.Template.View.Validations.Abstract;

namespace ThreeBytes.Email.Template.View.Backend.MessageHandlers
{
    public class CreatedTemplateEventMessageHandler : IHandleMessages<ICreatedTemplateInternalEventMessage>
    {
        private readonly IEmailTemplateViewTemplateService service;
        private readonly IEmailTemplateViewTemplateValidatorResolver validatorResolver;

        public CreatedTemplateEventMessageHandler(IEmailTemplateViewTemplateService service, IEmailTemplateViewTemplateValidatorResolver validatorResolver)
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

            EmailTemplateViewTemplate template = new EmailTemplateViewTemplate
            {
                ItemId = message.Id,
                Name = message.Name,
                ApplicationName = message.ApplicationName,
                Encoding = (Encoding)Enum.Parse(typeof(Encoding), message.Encoding),
                From = message.From,
                IsHtml = message.IsHtml,
                Subject = message.Subject,
                Body = message.Body
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
