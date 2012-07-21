using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;
using ThreeBytes.User.Authentication.UserView.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.UserView.Backend.MessageHandlers
{
    public class UpdatedProfileEmailAddressExternalEventMessageHandler : IHandleMessages<IUpdatedProfileEmailAddressExternalEventMessage>
    {
        private readonly IAuthenticationUserViewUserService service;
        private readonly IAuthenticationUserViewUserValidatorResolver validatorResolver;

        public UpdatedProfileEmailAddressExternalEventMessageHandler(IAuthenticationUserViewUserService service, IAuthenticationUserViewUserValidatorResolver validatorResolver)
        {
            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IUpdatedProfileEmailAddressExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserViewUser oldAuthenticationUser = service.GetById(message.Id);

            if (oldAuthenticationUser == null)
                return;

            if (oldAuthenticationUser.Email == message.NewEmail)
                return;

            AuthenticationUserViewUser newAuthenticationUser = new AuthenticationUserViewUser(oldAuthenticationUser);

            newAuthenticationUser.Email = message.NewEmail;

            ValidationResult result = validatorResolver.UpdateEmailValidator().Validate(newAuthenticationUser);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not update User email", result);
            }

            IHistoricalUpdateOperation<AuthenticationUserViewUser> updateOperation = new HistoricalUpdateOperation<AuthenticationUserViewUser>
            {
                OldItem = oldAuthenticationUser,
                NewItem = newAuthenticationUser,
                OperationDescription = string.Format("Updated Email Address from {0} to {1}.", oldAuthenticationUser.Email, newAuthenticationUser.Email)
            };

            service.Update(updateOperation);
        }
    }
}
