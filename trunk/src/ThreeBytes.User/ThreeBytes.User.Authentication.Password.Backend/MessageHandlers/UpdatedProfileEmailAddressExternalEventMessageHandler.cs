using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Password.Entities;
using ThreeBytes.User.Authentication.Password.Service.Abstract;
using ThreeBytes.User.Authentication.Password.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.Password.Backend.MessageHandlers
{
    public class UpdatedProfileEmailAddressExternalEventMessageHandler : IHandleMessages<IUpdatedProfileEmailAddressExternalEventMessage>
    {
        private readonly IPasswordManagementUserService service;
        private readonly IPasswordManagementUserValidatorResolver validatorResolver;

        public UpdatedProfileEmailAddressExternalEventMessageHandler(IPasswordManagementUserService service, IPasswordManagementUserValidatorResolver validatorResolver)
        {
            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdatedProfileEmailAddressExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            PasswordManagementUser user = service.GetById(message.Id);

            if (user == null)
                return;

            if (user.Email == message.NewEmail)
                return;

            user.Email = message.NewEmail;

            ValidationResult result = validatorResolver.UpdateEmailValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update User Email", result);
            }

            service.Update(user);
        }
    }
}
