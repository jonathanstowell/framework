using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.Messages.InternalEvents;
using ThreeBytes.Email.Template.View.Entities;
using ThreeBytes.Email.Template.View.Service.Abstract;
using ThreeBytes.Email.Template.View.Validations.Abstract;

namespace ThreeBytes.Email.Template.View.Backend.MessageHandlers
{
    public class UpdateTemplateFromEmailAddressEventMessageHandler : IHandleMessages<ITemplateFromEmailAddressUpdatedInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateViewTemplateService service;
        private readonly IEmailTemplateViewTemplateValidatorResolver validatorResolver;

        public UpdateTemplateFromEmailAddressEventMessageHandler(IEmailTemplateViewTemplateService service, IEmailTemplateViewTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ITemplateFromEmailAddressUpdatedInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailTemplateViewTemplate oldTemplate = service.GetById(message.Id);

            if (oldTemplate == null)
                return;

            EmailTemplateViewTemplate newTemplate = new EmailTemplateViewTemplate(oldTemplate);

            newTemplate.From = message.From;

            ValidationResult result = validatorResolver.UpdateFromAddressValidator().Validate(newTemplate);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            IHistoricalUpdateOperation<EmailTemplateViewTemplate> updateOperation = new HistoricalUpdateOperation<EmailTemplateViewTemplate>
            {
                OldItem = oldTemplate,
                NewItem = newTemplate,
                OperationDescription = string.Format("Updated Email From {0} to {1}", oldTemplate.From, newTemplate.From)
            };

            service.Update(updateOperation);
        }
    }
}
