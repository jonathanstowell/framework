using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Entities;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Service.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.DashBoard.LoginStatisticsMonthly.Backend.MessageHandlers
{
    public class UserLoggedInExternalEventMessageHandler : IHandleMessages<IUserLoggedInExternalEventMessage>
    {
        private readonly IDashboardLoginStatisticsMonthlyService service;
        private readonly IDashboardLoginStatisticsMonthlyValidatorResolver validatorResolver;

        public UserLoggedInExternalEventMessageHandler(IDashboardLoginStatisticsMonthlyService service, IDashboardLoginStatisticsMonthlyValidatorResolver validatorResolver)
        {
            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUserLoggedInExternalEventMessage message)
        {
            bool hasUserLoggedIn = service.HasUserHasLoggedInThisMonth(message.UserId, message.ApplicationName);

            if (hasUserLoggedIn)
                return;

            DashboardLoginStatisticsMonthly stat = new DashboardLoginStatisticsMonthly
                                                {
                                                    ApplicationName = message.ApplicationName,
                                                    UserId = message.UserId,
                                                    Username = message.Username,
                                                    Month = DateTime.Today.Month,
                                                    Year = DateTime.Today.Year
                                                };

            ValidationResult result = validatorResolver.CreateValidator().Validate(stat);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Dashboard Monthly Login Statistic", result);
            }

            service.Create(stat);
        }
    }
}
