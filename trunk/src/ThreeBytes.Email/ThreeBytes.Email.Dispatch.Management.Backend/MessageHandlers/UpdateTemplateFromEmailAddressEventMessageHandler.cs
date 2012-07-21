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
    public class UpdateTemplateFromEmailAddressEventMessageHandler : IHandleMessages<ITemplateFromEmailAddressUpdatedExternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailDispatchManagementTemplateService service;
        private readonly IEmailDispatchManagementTemplateValidatorResolver validatorResolver;

        public UpdateTemplateFromEmailAddressEventMessageHandler(IEmailDispatchManagementTemplateService service, IEmailDispatchManagementTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ITemplateFromEmailAddressUpdatedExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailDispatchManagementTemplate templateToUpdate = service.GetById(message.Id);

            if (templateToUpdate == null)
                return;

            templateToUpdate.From = message.From;

            ValidationResult result = validatorResolver.UpdateFromAddressValidator().Validate(templateToUpdate);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            service.Update(templateToUpdate);
        }
    }
}
