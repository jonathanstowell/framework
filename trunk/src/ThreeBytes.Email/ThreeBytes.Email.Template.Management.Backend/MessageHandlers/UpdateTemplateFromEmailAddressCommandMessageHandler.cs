using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.Management.Entities;
using ThreeBytes.Email.Template.Management.Service.Abstract;
using ThreeBytes.Email.Template.Management.Validations.Abstract;
using ThreeBytes.Email.Template.Messages.Commands;
using ThreeBytes.Email.Template.Messages.InternalEvents;

namespace ThreeBytes.Email.Template.Management.Backend.MessageHandlers
{
    public class UpdateTemplateFromEmailAddressCommandMessageHandler : IHandleMessages<IUpdateTemplateFromEmailAddressCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateManagementTemplateService service;
        private readonly IEmailTemplateManagementTemplateValidatorResolver validatorResolver;

        public UpdateTemplateFromEmailAddressCommandMessageHandler(IEmailTemplateManagementTemplateService service, IEmailTemplateManagementTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdateTemplateFromEmailAddressCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailTemplateManagementTemplate templateToUpdate = service.GetById(message.Id);

            if (templateToUpdate == null)
                return;

            templateToUpdate.From = message.From;

            ValidationResult result = validatorResolver.UpdateFromAddressValidator().Validate(templateToUpdate);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            service.Update(templateToUpdate);

            Bus.PublishAndSendLocal<ITemplateFromEmailAddressUpdatedInternalEventMessage>(x =>
            {
                x.Id = templateToUpdate.Id;
                x.From = templateToUpdate.From;
            });
        }
    }
}
