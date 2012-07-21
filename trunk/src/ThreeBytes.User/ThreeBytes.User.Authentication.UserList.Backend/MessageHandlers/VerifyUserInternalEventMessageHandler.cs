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
    public class VerifyUserInternalEventMessageHandler : IHandleMessages<IVerifiedUserInternalEventMessage>
    {
        private readonly IAuthenticationUserListUserService service;
        private readonly IAuthenticationUserListUserValidatorResolver validatorResolver;

        public VerifyUserInternalEventMessageHandler(IAuthenticationUserListUserService service, IAuthenticationUserListUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IVerifiedUserInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserListUser authenticationUser = service.GetById(message.Id);

            if (authenticationUser == null)
                return;

            if (authenticationUser.IsVerified)
                return;

            authenticationUser.IsVerified = true;

            ValidationResult result = validatorResolver.VerifyUserValidator().Validate(authenticationUser);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            service.Update(authenticationUser);
        }
    }
}
