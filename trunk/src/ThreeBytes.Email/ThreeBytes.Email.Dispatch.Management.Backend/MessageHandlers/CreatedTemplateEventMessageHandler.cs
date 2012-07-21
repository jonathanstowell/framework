using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Dispatch.Management.Entities;
using ThreeBytes.Email.Dispatch.Management.Entities.Enums;
using ThreeBytes.Email.Dispatch.Management.Service.Abstract;
using ThreeBytes.Email.Dispatch.Management.Validations.Abstract;
using ThreeBytes.Email.Messages.ExternalEvents;

namespace ThreeBytes.Email.Dispatch.Management.Backend.MessageHandlers
{
    public class CreatedTemplateEventMessageHandler : IHandleMessages<ICreatedTemplateExternalEventMessage>
    {
        private readonly IEmailDispatchManagementTemplateService service;
        private readonly IEmailDispatchManagementTemplateValidatorResolver validatorResolver;

        public CreatedTemplateEventMessageHandler(IEmailDispatchManagementTemplateService service, IEmailDispatchManagementTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreatedTemplateExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailDispatchManagementTemplate template = new EmailDispatchManagementTemplate
            {
                Id = message.Id,
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
                throw new AsyncServiceValidationException("Could not create template", result);
            }

            service.Create(template);
        }
    }
}
