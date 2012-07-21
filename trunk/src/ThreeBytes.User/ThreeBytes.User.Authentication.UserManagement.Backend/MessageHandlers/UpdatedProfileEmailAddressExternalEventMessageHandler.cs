using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.UserManagement.Backend.MessageHandlers
{
    public class UpdatedProfileEmailAddressExternalEventMessageHandler : IHandleMessages<IUpdatedProfileEmailAddressExternalEventMessage>
    {
        private readonly IAuthenticationUserManagementUserService service;
        private readonly IAuthenticationUserManagementUserValidatorResolver validatorResolver;

        public UpdatedProfileEmailAddressExternalEventMessageHandler(IAuthenticationUserManagementUserService service, IAuthenticationUserManagementUserValidatorResolver validatorResolver)
        {
            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdatedProfileEmailAddressExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserManagementUser user = service.GetById(message.Id);

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
