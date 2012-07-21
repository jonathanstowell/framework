using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Messages.ExternalEvents;
using ThreeBytes.User.Profile.View.Entities;
using ThreeBytes.User.Profile.View.Entities.Enums;
using ThreeBytes.User.Profile.View.Service.Abstract;
using ThreeBytes.User.Profile.View.Validations.Abstract;

namespace ThreeBytes.User.Profile.View.Backend.MessageHandlers
{
    public class RegisterUserFromExternalProviderExternalEventMessageHandler : IHandleMessages<IRegisterUserFromExternalProviderExternalEventMessage>
    {
        private readonly IProfileViewProfileService service;
        private readonly IProfileViewProfileValidatorResolver validatorResolver;

        public RegisterUserFromExternalProviderExternalEventMessageHandler(IProfileViewProfileService service, IProfileViewProfileValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisterUserFromExternalProviderExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            UserProfileViewProfile profile = new UserProfileViewProfile
                                                 {
                                                     Id = message.Id,
                                                     ItemId = message.Id,
                                                     Username = message.Username,
                                                     ApplicationName = message.ApplicationName,
                                                     Email = message.Email
                                                 };

            profile.AddExternalAuthenticator(new UserProfileExternalAuthenticator
            {
                ExternalIdentifier = message.ExternalIdentifier,
                Email = message.Email,
                Username = message.Username,
                ExternalAuthenticationType = (ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider),
                CreationDateTime = DateTime.Now
            });

            ValidationResult result = validatorResolver.CreateValidator().Validate(profile);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Profile View User", result);
            }

            service.Create(profile);
        }
    }
}