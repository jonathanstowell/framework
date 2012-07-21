using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;
using ThreeBytes.User.Authentication.Login.Validations.Abstract;
using ThreeBytes.User.Authentication.Messages.InternalEvents;

namespace ThreeBytes.User.Authentication.Login.Backend.MessageHandlers
{
    public class UnlockUserInternalEventMessageHandler : IHandleMessages<IUnlockUserInternalEventMessage>
    {
        private readonly ILoginUserService service;
        private readonly ILoginUserValidatorResolver validatorResolver;

        public UnlockUserInternalEventMessageHandler(ILoginUserService service, ILoginUserValidatorResolver validatorResolver)
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

            LoginUser user = service.GetById(message.Id);

            if (user == null)
                return;

            user.IsLockedOut = false;
            user.FailedPasswordAttemptCount = 0;

            ValidationResult result = validatorResolver.UnlockUserValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not unlock account", result);
            }

            service.Update(user);
        }
    }
}
