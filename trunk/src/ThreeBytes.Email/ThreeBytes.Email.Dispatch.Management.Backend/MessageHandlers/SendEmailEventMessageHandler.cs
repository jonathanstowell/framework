using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Email.Abstract;
using ThreeBytes.Core.Email.Exceptions;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Dispatch.Management.Entities;
using ThreeBytes.Email.Dispatch.Management.Entities.Enums;
using ThreeBytes.Email.Dispatch.Management.Validations.Abstract;
using ThreeBytes.Email.Dispatch.Messages.InternalEvents;
using ThreeBytes.Email.Messages.ExternalCommands;

namespace ThreeBytes.Email.Dispatch.Management.Backend.MessageHandlers
{
    public class SendEmailEventMessageHandler : IHandleMessages<ISendEmailExternalCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IEmailDispatcher emailDispatcher;
        private readonly IEmailDispatchManagementEmailMessageValidatorResolver validatorResolver;

        public SendEmailEventMessageHandler(IEmailDispatcher emailDispatcher, IEmailDispatchManagementEmailMessageValidatorResolver validatorResolver)
        {
            if (emailDispatcher == null)
                throw new ArgumentNullException("emailDispatcher");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.emailDispatcher = emailDispatcher;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ISendEmailExternalCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            var mail = new EmailDispatchManagementEmailMessage();

            mail.ApplicationName = message.ApplicationName;
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.From = message.From;
            mail.To = message.To;
            mail.CC = message.CC;
            mail.BCC = message.BCC;
            mail.IsHtml = message.IsHtml;

            if (message.Encoding != null)
                mail.Encoding = (Encoding) Enum.Parse(typeof (Encoding), message.Encoding);
            else
                mail.Encoding = Encoding.ASCII;

            ValidationResult valResult = validatorResolver.SendValidator().Validate(mail);

            if (!valResult.IsValid)
            {
                throw new AsyncServiceValidationException("Could not send Email", valResult);
            }

            ISendEmailResult result = emailDispatcher.Dispatch(mail);

            if (result.Success)
            {
                Bus.PublishAndSendLocal<ISentEmailMessageEventMessage>(x =>
                                                                           {
                                                                               x.Id = Guid.NewGuid();
                                                                               x.ApplicationName = mail.ApplicationName;
                                                                               x.From = mail.From;
                                                                               x.To = mail.To;
                                                                               x.CC = mail.CC;
                                                                               x.BCC = mail.BCC;
                                                                               x.Subject = mail.Subject;
                                                                               x.Body = mail.Body;
                                                                               x.IsHtml = mail.IsHtml;
                                                                               x.Encoding = mail.Encoding.ToString();
                                                                           });
            }
            else
            {
                throw new AsyncServiceEmailException("Could not send email", result);
            }
        }
    }
}
