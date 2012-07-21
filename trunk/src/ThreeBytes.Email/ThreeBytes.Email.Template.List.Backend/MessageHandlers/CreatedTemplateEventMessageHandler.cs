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
    public class CreatedTemplateEventMessageHandler : IHandleMessages<ICreatedTemplateInternalEventMessage>
    {
        private readonly IEmailTemplateListTemplateService service;
        private readonly IEmailTemplateListTemplateValidatorResolver validatorResolver;

        public CreatedTemplateEventMessageHandler(IEmailTemplateListTemplateService service, IEmailTemplateListTemplateValidatorResolver validatorResolver)
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

            EmailTemplateListTemplate role = new EmailTemplateListTemplate
            {
                Id = message.Id,
                Name = message.Name,
                ApplicationName = message.ApplicationName,
                Encoding = (Encoding)Enum.Parse(typeof(Encoding), message.Encoding),
                From = message.From,
                IsHtml = message.IsHtml,
                Subject = message.Subject
            };

            ValidationResult result = validatorResolver.CreateValidator().Validate(role);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add Template", result);
            }

            service.Create(role);
        }
    }
}
