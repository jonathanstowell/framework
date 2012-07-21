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
    public class RenameTemplateEventMessageHandler : IHandleMessages<IRenamedTemplateInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateWidgetTemplateService service;
        private readonly IEmailTemplateWidgetTemplateValidatorResolver validatorResolver;

        public RenameTemplateEventMessageHandler(IEmailTemplateWidgetTemplateService service, IEmailTemplateWidgetTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRenamedTemplateInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailTemplateWidgetTemplate templateToUpdate = service.GetById(message.Id);

            if (templateToUpdate == null)
                return;

            templateToUpdate.Name = message.Name;

            ValidationResult result = validatorResolver.RenameValidator().Validate(templateToUpdate);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            service.Update(templateToUpdate);
        }
    }
}
