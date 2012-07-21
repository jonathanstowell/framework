using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Template.Messages.InternalEvents;
using ThreeBytes.Email.Template.View.Entities;
using ThreeBytes.Email.Template.View.Entities.Enums;
using ThreeBytes.Email.Template.View.Service.Abstract;
using ThreeBytes.Email.Template.View.Validations.Abstract;

namespace ThreeBytes.Email.Template.View.Backend.MessageHandlers
{
    public class UpdateTemplateEmailContentsEventMessageHandler : IHandleMessages<ITemplateEmailContentsUpdatedInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailTemplateViewTemplateService service;
        private readonly IEmailTemplateViewTemplateValidatorResolver validatorResolver;

        public UpdateTemplateEmailContentsEventMessageHandler(IEmailTemplateViewTemplateService service, IEmailTemplateViewTemplateValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ITemplateEmailContentsUpdatedInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailTemplateViewTemplate oldTemplate = service.GetById(message.Id);

            if (oldTemplate == null)
                return;

            EmailTemplateViewTemplate newTemplate = new EmailTemplateViewTemplate(oldTemplate);

            newTemplate.Subject = message.Subject;
            newTemplate.Body = message.Body;
            newTemplate.IsHtml = message.IsHtml;
            newTemplate.Encoding = (Encoding)Enum.Parse(typeof(Encoding), message.Encoding);

            ValidationResult result = validatorResolver.UpdateContentsValidator().Validate(newTemplate);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            IHistoricalUpdateOperation<EmailTemplateViewTemplate> updateOperation = new HistoricalUpdateOperation<EmailTemplateViewTemplate>
            {
                OldItem = oldTemplate,
                NewItem = newTemplate,
                OperationDescription = string.Format("Updated Template: Subject From {0} to {1}, Body From {2} to {3}, IsHtml From {4} to {5}, Encoding From {6} to {7}"
                , oldTemplate.Subject, newTemplate.Subject
                , oldTemplate.Body, newTemplate.Body
                , oldTemplate.IsHtml, newTemplate.IsHtml
                , oldTemplate.Encoding, newTemplate.Encoding)
            };

            service.Update(updateOperation);
        }
    }
}
