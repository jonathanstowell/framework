using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Dashboard.NewestUsers.Entities;
using ThreeBytes.User.Dashboard.NewestUsers.Service.Abstract;
using ThreeBytes.User.Dashboard.NewestUsers.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Dashboard.NewestUsers.Backend.MessageHandlers
{
    public class RegisterUserFromExternalProviderExternalEventMessageHandler : IHandleMessages<IRegisterUserFromExternalProviderExternalEventMessage>
    {
        private readonly IDashboardNewestUsersService service;
        private readonly IDashboardNewestUsersValidatorResolver validatorResolver;

        public RegisterUserFromExternalProviderExternalEventMessageHandler(IDashboardNewestUsersService service, IDashboardNewestUsersValidatorResolver validatorResolver)
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

            DashboardNewestUsers stat = new DashboardNewestUsers
                                            {
                                                Id = message.Id,
                                                ApplicationName = message.ApplicationName,
                                                Username = message.Username,
                                                RegistrationDateTime = message.RegistrationDateTime
                                            };

            ValidationResult result = validatorResolver.CreateValidator().Validate(stat);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Dashboard Newest Users Statistic", result);
            }

            service.Create(stat);
        }
    }
}