using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Messages.ExternalEvents;
using ThreeBytes.User.Profile.Management.Entities;
using ThreeBytes.User.Profile.Management.Entities.Enums;
using ThreeBytes.User.Profile.Management.Service.Abstract;
using ThreeBytes.User.Profile.Management.Validations.Abstract;

namespace ThreeBytes.User.Profile.Management.Backend.MessageHandlers
{
    public class LinkExistingUserToExternalProviderInternalEventMessage : IHandleMessages<ILinkExistingUserToExternalProviderExternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IProfileManagementProfileService service;
        private readonly IProfileManagementProfileValidatorResolver validatorResolver;

        public LinkExistingUserToExternalProviderInternalEventMessage(IProfileManagementProfileService service, IProfileManagementProfileValidatorResolver validatorResolver)
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

            UserProfileManagementProfile profile = service.GetById(message.Id);

            if (profile == null)
                return;

            if (profile.HasLinkedExternalProvider((ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider)))
                return;

            profile.AddExternalAuthenticator(new UserProfileManagementExternalAuthenticator
            {
                ExternalIdentifier = message.ExternalIdentifier,
                Username = message.Username,
                Email = message.Email,
                ExternalAuthenticationType = (ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider),
                CreationDateTime = DateTime.Now
            });

            ValidationResult result = validatorResolver.LinkExternalProviderValidator().Validate(profile);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            service.Update(profile);
        }
    }
}