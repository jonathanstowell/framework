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
    public class LockOutUserInternalEventMessageHandler : IHandleMessages<ILockUserOutInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IAuthenticationUserManagementUserService service;
        private readonly IAuthenticationUserManagementUserValidatorResolver validatorResolver;

        public LockOutUserInternalEventMessageHandler(IAuthenticationUserManagementUserService service, IAuthenticationUserManagementUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ILockUserOutInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserManagementUser user = service.GetById(message.Id);

            if (user.IsLockedOut)
                return;

            user.IsLockedOut = true;

            ValidationResult result = validatorResolver.LockAuthenticationUserManagementUserOutValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User Role association", result);
            }

            service.Update(user);
        }
    }
}
