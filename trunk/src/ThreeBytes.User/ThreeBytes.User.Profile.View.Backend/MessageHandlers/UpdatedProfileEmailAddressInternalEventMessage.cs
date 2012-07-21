using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Profile.Messages.InternalEvents;
using ThreeBytes.User.Profile.View.Entities;
using ThreeBytes.User.Profile.View.Service.Abstract;
using ThreeBytes.User.Profile.View.Validations.Abstract;

namespace ThreeBytes.User.Profile.View.Backend.MessageHandlers
{
    public class UpdatedProfileEmailAddressInternalEventMessage : IHandleMessages<IUpdatedProfileEmailAddressInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IProfileViewProfileService service;
        private readonly IProfileViewProfileValidatorResolver validatorResolver;

        public UpdatedProfileEmailAddressInternalEventMessage(IProfileViewProfileService service, IProfileViewProfileValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdatedProfileEmailAddressInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            UserProfileViewProfile oldProfile = service.GetById(message.Id);

            if (oldProfile == null)
                return;

            if (oldProfile.Email == message.NewEmail)
                return;

            UserProfileViewProfile newProfile = new UserProfileViewProfile(oldProfile);
            newProfile.Email = message.NewEmail;

            ValidationResult result = validatorResolver.UpdateEmailAddressValidator().Validate(newProfile);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update User Profile email address", result);
            }

            IHistoricalUpdateOperation<UserProfileViewProfile> updateOperation = new HistoricalUpdateOperation<UserProfileViewProfile>
            {
                OldItem = oldProfile,
                NewItem = newProfile,
                OperationDescription = string.Format("Changed Email From {0} to {1}", oldProfile.Email, newProfile.Email)
            };

            service.Update(updateOperation);
        }
    }
}