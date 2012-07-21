using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Dispatch.Messages.InternalEvents;
using ThreeBytes.Email.Dispatch.Widget.Entities;
using ThreeBytes.Email.Dispatch.Widget.Service.Abstract;
using ThreeBytes.Email.Dispatch.Widget.Validations.Abstract;

namespace ThreeBytes.Email.Dispatch.Widget.Backend.MessageHandlers
{
    public class SentEmailMessageEventMessageHandler : IHandleMessages<ISentEmailMessageEventMessage>
    {
        private readonly IEmailDispatchWidgetEmailMessageService service;
        private readonly IEmailDispatchWidgetEmailMessageValidatorResolver validatorResolver;

        public SentEmailMessageEventMessageHandler(IEmailDispatchWidgetEmailMessageService service, IEmailDispatchWidgetEmailMessageValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ISentEmailMessageEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailDispatchWidgetEmailMessage mail = new EmailDispatchWidgetEmailMessage();

            mail.Id = message.Id;
            mail.ApplicationName = message.ApplicationName;
            mail.Subject = message.Subject;
            mail.To = message.To;

            ValidationResult result = validatorResolver.CreateValidator().Validate(mail);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create email", result);
            }

            service.Create(mail);
        }
    }
}
