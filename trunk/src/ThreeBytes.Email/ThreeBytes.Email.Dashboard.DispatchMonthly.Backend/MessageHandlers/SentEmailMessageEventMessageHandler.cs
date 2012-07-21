using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Entities;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Service.Abstract;
using ThreeBytes.Email.Dashboard.DispatchMonthly.Validations.Abstract;
using ThreeBytes.Email.Messages.ExternalEvents;

namespace ThreeBytes.Email.Dashboard.DispatchMonthly.Backend.MessageHandlers
{
    public class SentEmailMessageEventMessageHandler : IHandleMessages<ISentEmailMessageExternalEventMessage>
    {
        private readonly IDispatchMonthlyDashboardService service;
        private readonly IDashboardDispatchMonthlyEmailValidatorResolver validatorResolver;

        public SentEmailMessageEventMessageHandler(IDispatchMonthlyDashboardService service, IDashboardDispatchMonthlyEmailValidatorResolver validatorResolver)
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

            DashboardDispatchMonthlyEmail mail = new DashboardDispatchMonthlyEmail();

            mail.Id = message.Id;
            mail.ApplicationName = message.ApplicationName;
            mail.Subject = message.Subject;
            mail.To = message.To;
            mail.Month = DateTime.Today.Month;
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
