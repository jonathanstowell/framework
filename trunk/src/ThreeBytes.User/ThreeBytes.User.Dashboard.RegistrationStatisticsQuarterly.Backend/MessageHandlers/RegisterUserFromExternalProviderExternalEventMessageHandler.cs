using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Dashboard.RegistrationQuarterly.Validations.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Configuration.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Entities;
using ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Service.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsQuarterly.Backend.MessageHandlers
{
    public class RegisterUserFromExternalProviderExternalEventMessageHandler : IHandleMessages<IRegisterUserFromExternalProviderExternalEventMessage>
    {
        private readonly IDashboardRegistrationStatisticsQuarterlyService service;
        private readonly IProvideRegistrationStatisticsQuarterlyConfiguration configuration;
        private readonly IDashboardRegistrationStatisticsQuarterlyValidatorResolver validatorResolver;

        public RegisterUserFromExternalProviderExternalEventMessageHandler(IDashboardRegistrationStatisticsQuarterlyService service, IProvideRegistrationStatisticsQuarterlyConfiguration configuration, IDashboardRegistrationStatisticsQuarterlyValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (configuration == null)
                throw new ArgumentNullException("configuration");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.configuration = configuration;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisterUserFromExternalProviderExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            DashboardRegistrationStatisticsQuarterly stat = new DashboardRegistrationStatisticsQuarterly
                                                                {
                                                                    ApplicationName = message.ApplicationName,
                                                                    UserId = message.Id,
                                                                    Username = message.Username,
                                                                    Quarter = configuration.GetThisQuarter,
                                                                    Year = message.RegistrationDateTime.Year
                                                                };

            ValidationResult result = validatorResolver.CreateValidator().Validate(stat);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Dashboard Quarterly Registration Statistic", result);
            }

            service.Create(stat);
        }
    }
}