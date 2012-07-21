using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;
using ThreeBytes.User.Authentication.UserView.Validations.Abstract;

namespace ThreeBytes.User.Authentication.UserView.Backend.MessageHandlers
{
    public class RegisterUserFromExternalProviderInternalEventMessageHandler : IHandleMessages<IRegisterUserFromExternalProviderInternalEventMessage>
    {
        private readonly IAuthenticationUserViewUserService service;
        private readonly IAuthenticationUserViewUserValidatorResolver validatorResolver;

        public RegisterUserFromExternalProviderInternalEventMessageHandler(IAuthenticationUserViewUserService service, IAuthenticationUserViewUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisterUserFromExternalProviderInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserViewUser authenticationUser = new AuthenticationUserViewUser
                                                                {
                                                                    ItemId = message.Id,
                                                                    Username = message.Username,
                                                                    ApplicationName = message.ApplicationName,
                                                                    Email = message.Email,
                                                                    IsVerified = false,
                                                                    IsLockedOut = false
                                                                };

            ValidationResult result = validatorResolver.CreateValidator().Validate(authenticationUser);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            service.Create(authenticationUser);
        }
    }
}