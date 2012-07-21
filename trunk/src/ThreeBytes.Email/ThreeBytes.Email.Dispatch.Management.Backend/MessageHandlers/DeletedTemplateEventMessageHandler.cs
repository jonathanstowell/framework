using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Dispatch.Management.Entities;
using ThreeBytes.Email.Dispatch.Management.Service.Abstract;
using ThreeBytes.Email.Dispatch.Management.Validations.Abstract;
using ThreeBytes.Email.Messages.ExternalEvents;

namespace ThreeBytes.Email.Dispatch.Management.Backend.MessageHandlers
{
    public class DeletedTemplateEventMessageHandler : IHandleMessages<IDeletedTemplateExternalEventMessage>
    {
        private readonly IEmailDispatchManagementTemplateService service;
        private readonly IEmailDispatchManagementTemplateValidatorResolver validatorResolver;

        public DeletedTemplateEventMessageHandler(IEmailDispatchManagementTemplateService service, IEmailDispatchManagementTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IDeletedTemplateExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailDispatchManagementTemplate template = service.GetById(message.Id);

            if (template == null)
                return;

            ValidationResult result = validatorResolver.DeleteValidator().Validate(template);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not delete template", result);
            }

            service.Delete(template);
        }
    }
}
