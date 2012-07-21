using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Entities;
using ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Service.Abstract;
using ThreeBytes.User.Dashboard.RegistrationYearly.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsYearly.Backend.MessageHandlers
{
    public class RegisterUserFromExternalProviderExternalEventMessageHandler : IHandleMessages<IRegisterUserFromExternalProviderExternalEventMessage>
    {
        private readonly IDashboardRegistrationStatisticsYearlyService service;
        private readonly IDashboardRegistrationStatisticsYearlyValidatorResolver validatorResolver;

        public RegisterUserFromExternalProviderExternalEventMessageHandler(IDashboardRegistrationStatisticsYearlyService service, IDashboardRegistrationStatisticsYearlyValidatorResolver validatorResolver)
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

            DashboardRegistrationStatisticsYearly stat = new DashboardRegistrationStatisticsYearly
                                                             {
                                                                 ApplicationName = message.ApplicationName,
                                                                 UserId = message.Id,
                                                                 Username = message.Username,
                                                                 Year = message.RegistrationDateTime.Year
                                                             };

            ValidationResult result = validatorResolver.CreateValidator().Validate(stat);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Dashboard Yearly Registration Statistic", result);
            }

            service.Create(stat);
        }
    }
}