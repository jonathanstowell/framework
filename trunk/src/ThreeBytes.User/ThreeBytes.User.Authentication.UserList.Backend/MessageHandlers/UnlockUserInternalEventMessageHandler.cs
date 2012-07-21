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
    public class UnlockUserInternalEventMessageHandler : IHandleMessages<IUnlockUserInternalEventMessage>
    {
        private readonly IAuthenticationUserListUserService service;
        private readonly IAuthenticationUserListUserValidatorResolver validatorResolver;

        public UnlockUserInternalEventMessageHandler(IAuthenticationUserListUserService service, IAuthenticationUserListUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUnlockUserInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserListUser authenticationUser = service.GetById(message.Id);

            if (authenticationUser == null)
                return;

            if (!authenticationUser.IsLockedOut)
                return;

            authenticationUser.IsLockedOut = false;

            ValidationResult result = validatorResolver.UnlockUserValidator().Validate(authenticationUser);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            service.Update(authenticationUser);
        }
    }
}
