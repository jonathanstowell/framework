using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Entities;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Service.Abstract;
using ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Validations.Abstract;
using ThreeBytes.User.Dashboard.LoginStatisticsQuarterly.Configuration.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.DashBoard.LoginStatisticsQuarterly.Backend.MessageHandlers
{
    public class UserLoggedInExternalEventMessageHandler : IHandleMessages<IUserLoggedInExternalEventMessage>
    {
        private readonly IDashboardLoginStatisticsQuarterlyService service;
        private readonly IProvideLoginStatisticsQuarterlyConfiguration configuration;
        private readonly IDashboardLoginStatisticsQuarterlyValidatorResolver validatorResolver;

        public UserLoggedInExternalEventMessageHandler(IDashboardLoginStatisticsQuarterlyService service, IProvideLoginStatisticsQuarterlyConfiguration configuration, IDashboardLoginStatisticsQuarterlyValidatorResolver validatorResolver)
        {
            this.service = service;
            this.configuration = configuration;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUserLoggedInExternalEventMessage message)
        {
            bool hasUserLoggedIn = service.HasUserHasLoggedInThisQuarter(message.UserId, message.ApplicationName);

            if (hasUserLoggedIn)
                return;

            DashboardLoginStatisticsQuarterly stat = new DashboardLoginStatisticsQuarterly
                                                {
                                                    ApplicationName = message.ApplicationName,
                                                    UserId = message.UserId,
                                                    Username = message.Username,
                                                    Quarter = configuration.GetThisQuarter,
                                                    Year = DateTime.Today.Year
                                                };

            ValidationResult result = validatorResolver.CreateValidator().Validate(stat);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Dashboard Quarterly Login Statistic", result);
            }

            service.Create(stat);
        }
    }
}
