using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Configuration.Abstract;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Entities;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Service.Abstract;
using ThreeBytes.Email.Dashboard.DispatchQuarterly.Validations.Abstract;
using ThreeBytes.Email.Messages.ExternalEvents;

namespace ThreeBytes.Email.Dashboard.DispatchQuarterly.Backend.MessageHandlers
{
    public class SentEmailMessageEventMessageHandler : IHandleMessages<ISentEmailMessageExternalEventMessage>
    {
        private readonly IDispatchQuarterlyDashboardService service;
        private readonly IDashboardDispatchQuarterlyEmailValidatorResolver validatorResolver;
        private readonly IProvideEmailDispatchQuarterlyConfiguration configuration;

        public SentEmailMessageEventMessageHandler(IDispatchQuarterlyDashboardService service, IDashboardDispatchQuarterlyEmailValidatorResolver validatorResolver, IProvideEmailDispatchQuarterlyConfiguration configuration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            if (configuration == null)
                throw new ArgumentNullException("configuration");

            this.service = service;
            this.validatorResolver = validatorResolver;
            this.configuration = configuration;
        }

        public void Handle(ISentEmailMessageExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            DashboardDispatchQuarterlyEmail mail = new DashboardDispatchQuarterlyEmail();

            mail.Id = message.Id;
            mail.ApplicationName = message.ApplicationName;
            mail.Subject = message.Subject;
            mail.To = message.To;
            mail.Quarter = configuration.GetThisQuarter;
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
