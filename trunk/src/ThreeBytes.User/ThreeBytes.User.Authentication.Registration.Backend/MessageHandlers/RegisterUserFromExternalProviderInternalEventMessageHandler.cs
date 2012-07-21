using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Entities.Enums;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;
using ThreeBytes.User.Authentication.Registration.Validations.Abstract;

namespace ThreeBytes.User.Authentication.Registration.Backend.MessageHandlers
{
    public class RegisterUserFromExternalProviderInternalEventMessageHandler : IHandleMessages<IRegisterUserFromExternalProviderInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IExternalUserService service;
        private readonly IExternalUserValidatorResolver validatorResolver;

        public RegisterUserFromExternalProviderInternalEventMessageHandler(IExternalUserService service, IExternalUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisterUserFromExternalProviderInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ExternalUser user = new ExternalUser
                                 {
                                     Id = message.Id,
                                     Username = message.Username,
                                     ApplicationName = message.ApplicationName
                                 };

            user.AddExternalAuthenticator(new ExternalAuthenticator
            {
                ExternalIdentifier = message.ExternalIdentifier,
                ApplicationName = message.ApplicationName,
                Email = message.Email,
                Username = message.Username,
                ExternalAuthenticationType = (ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider),
                CreationDateTime = DateTime.Now
            });

            ValidationResult result = validatorResolver.CreateValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            service.Create(user);
        }
    }
}
