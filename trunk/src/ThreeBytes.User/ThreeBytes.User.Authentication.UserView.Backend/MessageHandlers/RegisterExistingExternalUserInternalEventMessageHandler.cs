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
    public class RegisterExistingExternalUserInternalEventMessageHandler : IHandleMessages<IRegisterExistingExternalUserInternalEventMessage>
    {
        private readonly IAuthenticationUserViewUserService service;
        private readonly IAuthenticationUserViewUserValidatorResolver validatorResolver;

        public RegisterExistingExternalUserInternalEventMessageHandler(IAuthenticationUserViewUserService service, IAuthenticationUserViewUserValidatorResolver validatorResolver)
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

            AuthenticationUserViewUser oldProfile = service.GetById(message.Id);

            if (oldProfile == null)
                return;

            if (oldProfile.Email == message.Email && oldProfile.Username == message.Username)
                return;

            AuthenticationUserViewUser newProfile = new AuthenticationUserViewUser(oldProfile);
            newProfile.Email = message.Email;
            newProfile.Username = message.Username;

            ValidationResult result = new ValidationResult();

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update User View email address", result);
            }

            IHistoricalUpdateOperation<AuthenticationUserViewUser> updateOperation = new HistoricalUpdateOperation<AuthenticationUserViewUser>
            {
                OldItem = oldProfile,
                NewItem = newProfile,
                OperationDescription = string.Format("Updated Existing External Account due to Application Registration. Email Updated From {0} to {1}. Username From {2} to {3}", oldProfile.Email, newProfile.Email, oldProfile.Username, newProfile.Username)
            };

            service.Update(updateOperation);
        }
    }
}