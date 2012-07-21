using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Dispatch.List.Entities;
using ThreeBytes.Email.Dispatch.List.Entities.Enums;
using ThreeBytes.Email.Dispatch.List.Service.Abstract;
using ThreeBytes.Email.Dispatch.List.Validations.Abstract;
using ThreeBytes.Email.Dispatch.Messages.InternalEvents;

namespace ThreeBytes.Email.Dispatch.List.Backend.MessageHandlers
{
    public class SentEmailMessageEventMessageHandler : IHandleMessages<ISentEmailMessageEventMessage>
    {
        private readonly IEmailDispatchListEmailMessageService service;
        private readonly IEmailDispatchListEmailMessageValidatorResolver validatorResolver;

        public SentEmailMessageEventMessageHandler(IEmailDispatchListEmailMessageService service, IEmailDispatchListEmailMessageValidatorResolver validatorResolver)
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

            EmailDispatchListEmailMessage mail = new EmailDispatchListEmailMessage();

            mail.Id = message.Id;
            mail.ApplicationName = message.ApplicationName;
            mail.Subject = message.Subject;
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
