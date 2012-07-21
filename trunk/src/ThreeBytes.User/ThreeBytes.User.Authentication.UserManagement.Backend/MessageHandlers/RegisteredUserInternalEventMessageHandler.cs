using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Validations.Abstract;

namespace ThreeBytes.User.Authentication.UserManagement.Backend.MessageHandlers
{
    public class RegisteredUserInternalEventMessageHandler : IHandleMessages<IRegisteredUserInternalEventMessage>
    {
        private readonly IAuthenticationUserManagementUserService service;
        private readonly IAuthenticationUserManagementUserValidatorResolver validatorResolver;

        public RegisteredUserInternalEventMessageHandler(IAuthenticationUserManagementUserService service, IAuthenticationUserManagementUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisteredUserInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserManagementUser user = new AuthenticationUserManagementUser
                                 {
                                     Id = message.Id,
                                     Username = message.Username,
                                     ApplicationName = message.ApplicationName,
                                     Email = message.Email,
                                     IsVerified = false,
                                     IsLockedOut = false
                                 };

            ValidationResult result = validatorResolver.CreateValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            service.Create(user);
        }
    }
}
