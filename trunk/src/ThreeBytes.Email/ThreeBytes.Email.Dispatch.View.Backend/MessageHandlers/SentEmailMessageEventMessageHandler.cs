using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Dispatch.Messages.InternalEvents;
using ThreeBytes.Email.Dispatch.View.Entities;
using ThreeBytes.Email.Dispatch.View.Entities.Enums;
using ThreeBytes.Email.Dispatch.View.Service.Abstract;
using ThreeBytes.Email.Dispatch.View.Validations.Abstract;

namespace ThreeBytes.Email.Dispatch.View.Backend.MessageHandlers
{
    public class SentEmailMessageEventMessageHandler : IHandleMessages<ISentEmailMessageEventMessage>
    {
        private readonly IEmailDispatchViewEmailMessageService service;
        private readonly IEmailDispatchViewEmailMessageValidatorResolver validatorResolver;

        public SentEmailMessageEventMessageHandler(IEmailDispatchViewEmailMessageService service, IEmailDispatchViewEmailMessageValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ISentEmailMessageEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            EmailDispatchViewEmailMessage mail = new EmailDispatchViewEmailMessage();

            mail.Id = message.Id;
            mail.ApplicationName = message.ApplicationName;
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.From = message.From;
            mail.To = message.To;
            mail.CC = message.CC;
            mail.BCC = message.BCC;
            mail.IsHtml = message.IsHtml;
            mail.Encoding = (Encoding)Enum.Parse(typeof(Encoding), message.Encoding);

            ValidationResult result = validatorResolver.CreateValidator().Validate(mail);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create email", result);
            }

            service.Create(mail);
        }
    }
}
