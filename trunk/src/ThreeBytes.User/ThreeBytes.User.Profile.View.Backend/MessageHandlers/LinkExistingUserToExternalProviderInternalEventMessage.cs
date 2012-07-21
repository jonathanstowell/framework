using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Messages.ExternalEvents;
using ThreeBytes.User.Profile.View.Entities;
using ThreeBytes.User.Profile.View.Entities.Enums;
using ThreeBytes.User.Profile.View.Service.Abstract;
using ThreeBytes.User.Profile.View.Validations.Abstract;

namespace ThreeBytes.User.Profile.View.Backend.MessageHandlers
{
    public class LinkExistingUserToExternalProviderInternalEventMessage : IHandleMessages<ILinkExistingUserToExternalProviderExternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IProfileViewProfileService service;
        private readonly IProfileViewProfileValidatorResolver validatorResolver;

        public LinkExistingUserToExternalProviderInternalEventMessage(IProfileViewProfileService service, IProfileViewProfileValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ILinkExistingUserToExternalProviderExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            UserProfileViewProfile oldProfile = service.GetById(message.Id);

            if (oldProfile == null)
                return;

            if (oldProfile.HasLinkedExternalProvider((ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider)))
                return;

            UserProfileViewProfile newProfile = new UserProfileViewProfile(oldProfile);

            newProfile.AddExternalAuthenticator(new UserProfileExternalAuthenticator
            {
                ExternalIdentifier = message.ExternalIdentifier,
                Username = message.Username,
                Email = message.Email,
                ExternalAuthenticationType = (ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider),
                CreationDateTime = DateTime.Now
            });

            ValidationResult result = validatorResolver.LinkExternalProviderValidator().Validate(newProfile);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            IHistoricalUpdateOperation<UserProfileViewProfile> updateOperation = new HistoricalUpdateOperation<UserProfileViewProfile>
            {
                OldItem = oldProfile,
                NewItem = newProfile,
                OperationDescription = string.Format("Added a new {0} linked external account", message.ExternalProvider)
            };

            service.Update(updateOperation);
        }
    }
}