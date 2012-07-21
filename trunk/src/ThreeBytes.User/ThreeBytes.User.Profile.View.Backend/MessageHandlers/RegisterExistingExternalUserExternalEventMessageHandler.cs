using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Messages.ExternalEvents;
using ThreeBytes.User.Profile.View.Entities;
using ThreeBytes.User.Profile.View.Service.Abstract;
using ThreeBytes.User.Profile.View.Validations.Abstract;

namespace ThreeBytes.User.Profile.View.Backend.MessageHandlers
{
    public class RegisterExistingExternalUserExternalEventMessageHandler : IHandleMessages<IRegisterExistingExternalUserExternalEventMessage>
    {
        private readonly IProfileViewProfileService service;
        private readonly IProfileViewProfileValidatorResolver validatorResolver;

        public RegisterExistingExternalUserExternalEventMessageHandler(IProfileViewProfileService service, IProfileViewProfileValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisterExistingExternalUserExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            UserProfileViewProfile oldProfile = service.GetById(message.Id);

            if (oldProfile == null)
                return;

            if (oldProfile.Email == message.Email && oldProfile.Username == message.Username)
                return;

            UserProfileViewProfile newProfile = new UserProfileViewProfile(oldProfile);

            newProfile.Email = message.Email;
            newProfile.Username = message.Username;

            ValidationResult result = validatorResolver.UpdateEmailAddressValidator().Validate(newProfile);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update User Profile email address", result);
            }

            IHistoricalUpdateOperation<UserProfileViewProfile> updateOperation = new HistoricalUpdateOperation<UserProfileViewProfile>
            {
                OldItem = oldProfile,
                NewItem = newProfile,
                OperationDescription = string.Format("Updated Existing External Account due to Application Registration. Email Updated From {0} to {1}. Username From {2} to {3}", oldProfile.Email, newProfile.Email, oldProfile.Username, newProfile.Username)
            };

            service.Update(updateOperation);
        }
    }
}