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
    public class DeleteTemplateCommandMessageHandler : IHandleMessages<IDeleteTemplateCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateManagementTemplateService service;
        private readonly IEmailTemplateManagementTemplateValidatorResolver validatorResolver;

        public DeleteTemplateCommandMessageHandler(IEmailTemplateManagementTemplateService service, IEmailTemplateManagementTemplateValidatorResolver validatorResolver)
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

            EmailTemplateManagementTemplate template = service.GetById(message.Id);

            if (template == null)
                return;

            ValidationResult result = validatorResolver.DeleteValidator().Validate(template);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could delete Template", result);
            }

            service.Delete(template);

            Bus.PublishAndSendLocal<IDeletedTemplateInternalEventMessage>(x =>
            {
                x.Id = message.Id;
            });
        }
    }
}
