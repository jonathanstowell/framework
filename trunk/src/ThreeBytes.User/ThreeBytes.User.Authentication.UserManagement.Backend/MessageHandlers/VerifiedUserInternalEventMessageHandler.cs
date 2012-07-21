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
    public class VerifiedUserInternalEventMessageHandler : IHandleMessages<IVerifiedUserInternalEventMessage>
    {
        private readonly IAuthenticationUserManagementUserService service;
        private readonly IAuthenticationUserManagementUserValidatorResolver validatorResolver;

        public VerifiedUserInternalEventMessageHandler(IAuthenticationUserManagementUserService service, IAuthenticationUserManagementUserValidatorResolver validatorResolver)
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

            AuthenticationUserManagementUser user = service.GetById(message.Id);

            if (user == null)
                return;

            if (user.IsVerified)
                return;

            user.IsVerified = true;

            ValidationResult result = validatorResolver.VerifyUserValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User Role association", result);
            }

            service.Update(user);
        }
    }
}
