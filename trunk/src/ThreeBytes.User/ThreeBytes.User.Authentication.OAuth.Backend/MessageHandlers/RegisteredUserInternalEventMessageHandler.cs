using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Authentication.OAuth.Validations.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Backend.MessageHandlers
{
    public class RegisteredUserInternalEventMessageHandler : IHandleMessages<IRegisteredUserInternalEventMessage>
    {
        private readonly IOAuthUserService service;
        private readonly IOAuthUserValidatorResolver validatorResolver;

        public RegisteredUserInternalEventMessageHandler(IOAuthUserService service, IOAuthUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisteredUserInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            OAuthUser user = new OAuthUser
            {
                Id = message.Id,
                Username = message.Username,
                ApplicationName = message.ApplicationName,
                Email = message.Email
            };

            if (!service.HasRecords(message.ApplicationName))
            {
                OAuthRole theCreator = new OAuthRole("Creator", message.ApplicationName) { Id = Guid.NewGuid() };

                if (!user.Roles.Contains(theCreator))
                    user.AddRole(theCreator);
            }

            ValidationResult result = validatorResolver.CreateValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create user", result);
            }

            service.Create(user);
        }
    }
}
