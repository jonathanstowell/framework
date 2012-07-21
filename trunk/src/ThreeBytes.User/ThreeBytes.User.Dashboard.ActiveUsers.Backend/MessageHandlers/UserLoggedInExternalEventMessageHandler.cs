using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Dashboard.ActiveUsers.Entities;
using ThreeBytes.User.Dashboard.ActiveUsers.Service.Abstract;
using ThreeBytes.User.Dashboard.ActiveUsers.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Dashboard.ActiveUsers.Backend.MessageHandlers
{
    public class UserLoggedInExternalEventMessageHandler : IHandleMessages<IUserLoggedInExternalEventMessage>
    {
        private readonly IDashboardActiveUsersService service;
        private readonly IDashboardActiveUsersValidatorResolver validatorResolver;

        public UserLoggedInExternalEventMessageHandler(IDashboardActiveUsersService service, IDashboardActiveUsersValidatorResolver validatorResolver)
        {
            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUserLoggedInExternalEventMessage message)
        {
            DashboardActiveUsers stat = service.GetById(message.UserId);

            if (stat == null)
            {
                stat = new DashboardActiveUsers
                {
                    Id = message.UserId,
                    ApplicationName = message.ApplicationName,
                    Username = message.Username,
                    Logins = 1
                };

                ValidationResult result = validatorResolver.CreateValidator().Validate(stat);

                if (!result.IsValid)
                {
                    throw new AsyncServiceValidationException("Could not create Active Users Statistic", result);
                }

                service.Create(stat);
            }
            else
            {
                stat.Logins = stat.Logins + 1;

                ValidationResult result = validatorResolver.UpdateValidator().Validate(stat);

                if (!result.IsValid)
                {
                    throw new AsyncServiceValidationException("Could not update Active Users Statistic", result);
                }

                service.Update(stat);
            }
        }
    }
}
