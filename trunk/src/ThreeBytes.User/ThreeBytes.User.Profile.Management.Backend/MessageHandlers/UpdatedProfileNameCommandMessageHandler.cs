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
    public class UpdatedProfileNameCommandMessageHandler : IHandleMessages<IUpdatedProfileNameCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IProfileManagementProfileService service;
        private readonly IProfileManagementProfileValidatorResolver validatorResolver;

        public UpdatedProfileNameCommandMessageHandler(IProfileManagementProfileService service, IProfileManagementProfileValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdatedProfileNameCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            UserProfileManagementProfile profile = service.GetById(message.Id);

            if (profile == null)
                return;

            if (profile.Forename == message.NewForename && profile.Surname == message.NewSurname)
                return;

            profile.Forename = message.NewForename;
            profile.Surname = message.NewSurname;

            ValidationResult result = validatorResolver.UpdateNameValidator().Validate(profile);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not rename User Profile", result);
            }

            service.Update(profile);

            Bus.PublishAndSendLocal<IUpdatedProfileNameInternalEventMessage>(x =>
            {
                x.Id = profile.Id;
                x.NewForename = profile.Forename;
                x.NewSurname = profile.Surname;
            });
        }
    }
}
