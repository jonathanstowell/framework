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
    public class RegisterExistingExternalUserExternalEventMessageHandler : IHandleMessages<IRegisterExistingExternalUserExternalEventMessage>
    {
        private readonly IProfileManagementProfileService service;
        private readonly IProfileManagementProfileValidatorResolver validatorResolver;

        public RegisterExistingExternalUserExternalEventMessageHandler(IProfileManagementProfileService service, IProfileManagementProfileValidatorResolver validatorResolver)
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

            UserProfileManagementProfile profile = service.GetById(message.Id);

            if (profile == null)
                return;

            if (profile.Email != message.Email)
                profile.Email = message.Email;

            if (profile.Username != message.Username)
                profile.Username = message.Username;

            ValidationResult result = new ValidationResult();

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update Profile Management User", result);
            }

            service.Update(profile);
        }
    }
}