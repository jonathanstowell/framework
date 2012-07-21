using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Entities;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Service.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsYearly.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Dashboard.LoginStatisticsYearly.Backend.MessageHandlers
{
    public class UserLoggedInExternalEventMessageHandler : IHandleMessages<IUserLoggedInExternalEventMessage>
    {
        private readonly IDashboardLoginStatisticsYearlyService service;
        private readonly IDashboardLoginStatisticsYearlyValidatorResolver validatorResolver;

        public UserLoggedInExternalEventMessageHandler(IDashboardLoginStatisticsYearlyService service, IDashboardLoginStatisticsYearlyValidatorResolver validatorResolver)
        {
            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUserLoggedInExternalEventMessage message)
        {
            bool hasUserLoggedIn = service.HasUserHasLoggedInThisYear(message.UserId, message.ApplicationName);

            if (hasUserLoggedIn)
                return;

            DashboardLoginStatisticsYearly stat = new DashboardLoginStatisticsYearly
                                                {
                                                    ApplicationName = message.ApplicationName,
                                                    UserId = message.UserId,
                                                    Username = message.Username,
                                                    Year = DateTime.Today.Year
                                                };

            ValidationResult result = validatorResolver.CreateValidator().Validate(stat);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Dashboard Yearly Login Statistic", result);
            }

            service.Create(stat);
        }
    }
}
