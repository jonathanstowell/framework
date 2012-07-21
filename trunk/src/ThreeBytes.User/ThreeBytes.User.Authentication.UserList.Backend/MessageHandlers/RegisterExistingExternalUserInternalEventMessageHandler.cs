using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.UserList.Entities;
using ThreeBytes.User.Authentication.UserList.Service.Abstract;
using ThreeBytes.User.Authentication.UserList.Validations.Abstract;

namespace ThreeBytes.User.Authentication.UserList.Backend.MessageHandlers
{
    public class RegisterExistingExternalUserInternalEventMessageHandler : IHandleMessages<IRegisterExistingExternalUserInternalEventMessage>
    {
        private readonly IAuthenticationUserListUserService service;
        private readonly IAuthenticationUserListUserValidatorResolver validatorResolver;

        public RegisterExistingExternalUserInternalEventMessageHandler(IAuthenticationUserListUserService service, IAuthenticationUserListUserValidatorResolver validatorResolver)
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

            AuthenticationUserListUser profile = service.GetById(message.Id);

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