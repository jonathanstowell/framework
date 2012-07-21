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
    public class VerifyUserInternalEventMessageHandler : IHandleMessages<IVerifiedUserInternalEventMessage>
    {
        private readonly IPasswordManagementUserService service;
        private readonly IPasswordManagementUserValidatorResolver validatorResolver;

        public VerifyUserInternalEventMessageHandler(IPasswordManagementUserService service, IPasswordManagementUserValidatorResolver validatorResolver)
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

            PasswordManagementUser user = service.GetById(message.Id);

            if (user == null)
                return;

            if (user.IsVerified)
                return;

            user.IsVerified = true;

            ValidationResult result = validatorResolver.VerifyUserValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            service.Update(user);
        }
    }
}
