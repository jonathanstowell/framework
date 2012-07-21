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
    public class RegisterExistingExternalUserInternalEventMessageHandler : IHandleMessages<IRegisterExistingExternalUserInternalEventMessage>
    {
        private readonly IAuthenticationUserManagementUserService service;
        private readonly IAuthenticationUserManagementUserValidatorResolver validatorResolver;

        public RegisterExistingExternalUserInternalEventMessageHandler(IAuthenticationUserManagementUserService service, IAuthenticationUserManagementUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisterExistingExternalUserInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserManagementUser profile = service.GetById(message.Id);

            if (profile == null)
                return;

            if (profile.Email != message.Email)
                profile.Email = message.Email;

            if (profile.Username != message.Username)
                profile.Username = message.Username;

            ValidationResult result = new ValidationResult();

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update User List User", result);
            }

            service.Update(profile);
        }
    }
}