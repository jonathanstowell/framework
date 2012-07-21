using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Profile.Management.Entities;
using ThreeBytes.User.Profile.Management.Service.Abstract;
using ThreeBytes.User.Profile.Management.Validations.Abstract;
using ThreeBytes.User.Profile.Messages.Commands;
using ThreeBytes.User.Profile.Messages.InternalEvents;

namespace ThreeBytes.User.Profile.Management.Backend.MessageHandlers
{
    public class UpdateProfileEmailAddressCommandMessage : IHandleMessages<IUpdateProfileEmailAddressCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IProfileManagementProfileService service;
        private readonly IProfileManagementProfileValidatorResolver validatorResolver;

        public UpdateProfileEmailAddressCommandMessage(IProfileManagementProfileService service, IProfileManagementProfileValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdateProfileEmailAddressCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            UserProfileManagementProfile profile = service.GetById(message.Id);

            if (profile == null)
                return;

            if (profile.Email == message.NewEmail)
                return;

            profile.Email = message.NewEmail;

            ValidationResult result = validatorResolver.UpdateEmailAddressValidator().Validate(profile);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update User Profile email address", result);
            }

            service.Update(profile);

            Bus.PublishAndSendLocal<IUpdatedProfileEmailAddressInternalEventMessage>(x =>
                                                                                         {
                                                                                             x.Id = profile.Id;
                                                                                             x.NewEmail = profile.Email;
                                                                                         });
        }
    }
}