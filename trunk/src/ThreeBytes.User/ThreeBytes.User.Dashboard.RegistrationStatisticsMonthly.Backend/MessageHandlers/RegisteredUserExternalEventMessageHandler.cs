using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Dashboard.RegistrationMonthly.Validations.Abstract;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Entities;
using ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Service.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Dashboard.RegistrationStatisticsMonthly.Backend.MessageHandlers
{
    public class RegisteredUserExternalEventMessageHandler : IHandleMessages<IRegisteredUserExternalEventMessage>
    {
        private readonly IDashboardRegistrationStatisticsMonthlyService service;
        private readonly IDashboardRegistrationStatisticsMonthlyValidatorResolver validatorResolver;

        public RegisteredUserExternalEventMessageHandler(IDashboardRegistrationStatisticsMonthlyService service, IDashboardRegistrationStatisticsMonthlyValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisteredUserExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            DashboardRegistrationStatisticsMonthly stat = new DashboardRegistrationStatisticsMonthly
                                 {
                                     ApplicationName = message.ApplicationName,
                                     UserId = message.Id,
                                     Username = message.Username,
                                     Month = message.RegistrationDateTime.Month,
                                     Year = message.RegistrationDateTime.Year
                                 };

            ValidationResult result = validatorResolver.CreateValidator().Validate(stat);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Dashboard Monthly Registration Statistic", result);
            }

            service.Create(stat);
        }
    }
}
