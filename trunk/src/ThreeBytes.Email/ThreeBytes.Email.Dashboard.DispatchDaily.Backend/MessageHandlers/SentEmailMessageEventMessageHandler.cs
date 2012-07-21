using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Dashboard.DispatchDaily.Entities;
using ThreeBytes.Email.Dashboard.DispatchDaily.Service.Abstract;
using ThreeBytes.Email.Dashboard.DispatchDaily.Validations.Abstract;
using ThreeBytes.Email.Messages.ExternalEvents;

namespace ThreeBytes.Email.Dashboard.DispatchDaily.Backend.MessageHandlers
{
    public class SentEmailMessageEventMessageHandler : IHandleMessages<ISentEmailMessageExternalEventMessage>
    {
        private readonly IDispatchDailyDashboardService service;
        private readonly IDashboardDispatchDailyEmailValidatorResolver validatorResolver;

        public SentEmailMessageEventMessageHandler(IDispatchDailyDashboardService service, IDashboardDispatchDailyEmailValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ISentEmailMessageExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            DashboardDispatchDailyEmail mail = new DashboardDispatchDailyEmail();

            mail.Id = message.Id;
            mail.ApplicationName = message.ApplicationName;
            mail.Subject = message.Subject;
            mail.To = message.To;
            mail.DispatchDate = DateTime.Today;

            ValidationResult result = validatorResolver.CreateValidator().Validate(mail);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create email", result);
            }

            service.Create(mail);
        }
    }
}
