using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Messages.ExternalEvents;
using ThreeBytes.User.Profile.Management.Entities;
using ThreeBytes.User.Profile.Management.Service.Abstract;
using ThreeBytes.User.Profile.Management.Validations.Abstract;

namespace ThreeBytes.User.Profile.Management.Backend.MessageHandlers
{
    public class RegisteredUserExternalEventMessageHandler : IHandleMessages<IRegisteredUserExternalEventMessage>
    {
        private readonly IProfileManagementProfileService service;
        private readonly IProfileManagementProfileValidatorResolver validatorResolver;

        public RegisteredUserExternalEventMessageHandler(IProfileManagementProfileService service, IProfileManagementProfileValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisteredUserExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            UserProfileManagementProfile profile = new UserProfileManagementProfile
                                 {
                                     Id = message.Id,
                                     Username = message.Username,
                                     ApplicationName = message.ApplicationName,
                                     Email = message.Email
                                 };

            ValidationResult result = validatorResolver.CreateValidator().Validate(profile);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Profile Management User", result);
            }

            service.Create(profile);
        }
    }
}
