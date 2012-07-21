using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Entities;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Service.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsDaily.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Dashboard.LoginStatisticsDaily.Backend.MessageHandlers
{
    public class UserLoggedInExternalEventMessageHandler : IHandleMessages<IUserLoggedInExternalEventMessage>
    {
        private readonly IDashboardLoginStatisticsDailyService service;
        private readonly IDashboardLoginStatisticsDailyValidatorResolver validatorResolver;

        public UserLoggedInExternalEventMessageHandler(IDashboardLoginStatisticsDailyService service, IDashboardLoginStatisticsDailyValidatorResolver validatorResolver)
        {
            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUserLoggedInExternalEventMessage message)
        {
            bool hasUserLoggedIn = service.HasUserHasLoggedInToday(message.UserId, message.ApplicationName, DateTime.Today);

            if (hasUserLoggedIn)
                return;

            DashboardLoginStatisticsDaily stat = new DashboardLoginStatisticsDaily
                                                {
                                                    ApplicationName = message.ApplicationName,
                                                    UserId = message.UserId,
                                                    Username = message.Username,
                                                    LoginDate = DateTime.Today
                                                };

            ValidationResult result = validatorResolver.CreateValidator().Validate(stat);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Dashboard Daily Login Statistic", result);
            }

            service.Create(stat);
        }
    }
}
