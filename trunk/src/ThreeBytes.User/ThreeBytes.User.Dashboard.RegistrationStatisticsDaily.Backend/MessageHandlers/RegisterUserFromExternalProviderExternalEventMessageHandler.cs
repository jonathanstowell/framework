using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Dashboard.RegistrationDaily.Validations.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Entities;
using ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Service.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsDaily.Backend.MessageHandlers
{
    public class RegisterUserFromExternalProviderExternalEventMessageHandler : IHandleMessages<IRegisterUserFromExternalProviderExternalEventMessage>
    {
        private readonly IDashboardRegistrationStatisticsDailyService service;
        private readonly IDashboardRegistrationStatisticsDailyValidatorResolver validatorResolver;

        public RegisterUserFromExternalProviderExternalEventMessageHandler(IDashboardRegistrationStatisticsDailyService service, IDashboardRegistrationStatisticsDailyValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisterUserFromExternalProviderExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            DashboardRegistrationStatisticsDaily stat = new DashboardRegistrationStatisticsDaily
                                                            {
                                                                ApplicationName = message.ApplicationName,
                                                                UserId = message.Id,
                                                                Username = message.Username,
                                                                RegistrationDateTime = message.RegistrationDateTime.Date
                                                            };

            ValidationResult result = validatorResolver.CreateValidator().Validate(stat);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Dashboard Daily Registration Statistic", result);
            }

            service.Create(stat);
        }
    }
}