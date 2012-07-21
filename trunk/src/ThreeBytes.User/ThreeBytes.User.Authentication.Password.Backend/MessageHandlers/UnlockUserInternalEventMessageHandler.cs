using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.Password.Entities;
using ThreeBytes.User.Authentication.Password.Service.Abstract;
using ThreeBytes.User.Authentication.Password.Validations.Abstract;

namespace ThreeBytes.User.Authentication.Password.Backend.MessageHandlers
{
    public class UnlockUserInternalEventMessageHandler : IHandleMessages<IUnlockUserInternalEventMessage>
    {
        private readonly IPasswordManagementUserService service;
        private readonly IPasswordManagementUserValidatorResolver validatorResolver;

        public UnlockUserInternalEventMessageHandler(IPasswordManagementUserService service, IPasswordManagementUserValidatorResolver validatorResolver)
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

            PasswordManagementUser user = service.GetById(message.Id);

            if (user == null)
                return;

            if (!user.IsLockedOut)
                return;

            user.IsLockedOut = false;
            user.UnlockCode = null;

            ValidationResult result = validatorResolver.UnlockUserValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            service.Update(user);
        }
    }
}
