using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Profile.Messages.InternalEvents;
using ThreeBytes.User.Profile.View.Entities;
using ThreeBytes.User.Profile.View.Service.Abstract;
using ThreeBytes.User.Profile.View.Validations.Abstract;

namespace ThreeBytes.User.Profile.View.Backend.MessageHandlers
{
    public class UpdatedProfileNameInternalEventMessage : IHandleMessages<IUpdatedProfileNameInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IProfileViewProfileService service;
        private readonly IProfileViewProfileValidatorResolver validatorResolver;

        public UpdatedProfileNameInternalEventMessage(IProfileViewProfileService service, IProfileViewProfileValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdatedProfileNameInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            UserProfileViewProfile oldProfile = service.GetById(message.Id);

            if (oldProfile == null)
                return;

            if (oldProfile.Forename == message.NewForename && oldProfile.Surname == message.NewSurname)
                return;

            UserProfileViewProfile newProfile = new UserProfileViewProfile(oldProfile);

            newProfile.Forename = message.NewForename;
            newProfile.Surname = message.NewSurname;

            ValidationResult result = validatorResolver.UpdateEmailAddressValidator().Validate(newProfile);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not rename User Profile", result);
            }

            IHistoricalUpdateOperation<UserProfileViewProfile> updateOperation = new HistoricalUpdateOperation<UserProfileViewProfile>
            {
                OldItem = oldProfile,
                NewItem = newProfile,
                OperationDescription = string.Format("Renamed From {0} {1} to {2} {3}", oldProfile.Forename, oldProfile.Surname, newProfile.Forename, newProfile.Surname)
            };

            service.Update(updateOperation);
        }
    }
}
