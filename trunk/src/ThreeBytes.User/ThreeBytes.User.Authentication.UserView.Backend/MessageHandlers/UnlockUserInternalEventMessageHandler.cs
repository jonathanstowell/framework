using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;
using ThreeBytes.User.Authentication.UserView.Validations.Abstract;

namespace ThreeBytes.User.Authentication.UserView.Backend.MessageHandlers
{
    public class UnlockUserInternalEventMessageHandler : IHandleMessages<IUnlockUserInternalEventMessage>
    {
        private readonly IAuthenticationUserViewUserService service;
        private readonly IAuthenticationUserViewUserValidatorResolver validatorResolver;

        public UnlockUserInternalEventMessageHandler(IAuthenticationUserViewUserService service, IAuthenticationUserViewUserValidatorResolver validatorResolver)
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

            AuthenticationUserViewUser oldAuthenticationUser = service.GetById(message.Id);

            if (oldAuthenticationUser == null)
                return;

            if (!oldAuthenticationUser.IsLockedOut)
                return;

            AuthenticationUserViewUser newAuthenticationUser = new AuthenticationUserViewUser(oldAuthenticationUser);  

            newAuthenticationUser.IsLockedOut = false;

            ValidationResult result = validatorResolver.UnlockUserValidator().Validate(newAuthenticationUser);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            IHistoricalUpdateOperation<AuthenticationUserViewUser> updateOperation = new HistoricalUpdateOperation<AuthenticationUserViewUser>
            {
                OldItem = oldAuthenticationUser,
                NewItem = newAuthenticationUser,
                OperationDescription = "Unlocked Account."
            };

            service.Update(updateOperation);
        }
    }
}
