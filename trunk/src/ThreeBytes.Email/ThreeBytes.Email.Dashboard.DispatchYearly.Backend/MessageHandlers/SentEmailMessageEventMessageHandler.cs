using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Dashboard.DispatchYearly.Entities;
using ThreeBytes.Email.Dashboard.DispatchYearly.Service.Abstract;
using ThreeBytes.Email.Dashboard.DispatchYearly.Validations.Abstract;
using ThreeBytes.Email.Messages.ExternalEvents;

namespace ThreeBytes.Email.Dashboard.DispatchYearly.Backend.MessageHandlers
{
    public class SentEmailMessageEventMessageHandler : IHandleMessages<ISentEmailMessageExternalEventMessage>
    {
        private readonly IDispatchYearlyDashboardService service;
        private readonly IDashboardDispatchYearlyEmailValidatorResolver validatorResolver;

        public SentEmailMessageEventMessageHandler(IDispatchYearlyDashboardService service, IDashboardDispatchYearlyEmailValidatorResolver validatorResolver)
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

            DashboardDispatchYearlyEmail mail = new DashboardDispatchYearlyEmail();

            mail.Id = message.Id;
            mail.ApplicationName = message.ApplicationName;
            mail.Subject = message.Subject;
            mail.To = message.To;
            mail.Year = DateTime.Today.Year;

            ValidationResult result = validatorResolver.CreateValidator().Validate(mail);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create email", result);
            }

            service.Create(mail);
        }
    }
}
