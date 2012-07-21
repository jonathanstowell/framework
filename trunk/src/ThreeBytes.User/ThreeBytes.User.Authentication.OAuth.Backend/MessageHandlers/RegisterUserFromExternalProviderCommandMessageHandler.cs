using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Entities.Enums;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Authentication.OAuth.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.OAuth.Backend.MessageHandlers
{
    public class RegisterUserFromExternalProviderCommandMessageHandler : IHandleMessages<IRegisterUserFromExternalProviderCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IOAuthUserService service;
        private readonly IOAuthUserValidatorResolver validatorResolver;

        public RegisterUserFromExternalProviderCommandMessageHandler(IOAuthUserService service, IOAuthUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisterUserFromExternalProviderCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            OAuthUser user = new OAuthUser
                                 {
                                     Id = message.Identifier,
                                     ApplicationName = message.ApplicationName,
                                     Username = message.Username,
                                     Email = message.Email
                                 };

            user.AddExternalAuthenticator(new ExternalAuthenticator
            {
                ExternalIdentifier = message.ExternalIdentifier,
                Email = message.Email,
                Username = message.Username,
                ExternalAuthenticationType = (ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider),
                Token = message.Token,
                TokenSecret = message.TokenSecret
            });

            if (!service.HasRecords(message.ApplicationName))
            {
                Bus.PublishAndSendLocal<ISetupUserSystemExternalEventMessage>(x =>
                {
                    x.ApplicationName = message.ApplicationName;
                });

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

            Bus.PublishAndSendLocal<IRegisterUserFromExternalProviderInternalEventMessage>(x =>
            {
                x.Id = user.Id;
                x.Username = message.Username;
                x.Email = message.Email;
                x.ExternalIdentifier = message.ExternalIdentifier;
                x.ExternalProvider = message.ExternalProvider;
                x.ApplicationName = user.ApplicationName;
                x.Token = message.Token;
                x.TokenSecret = message.TokenSecret;
                x.ApplicationName = user.ApplicationName;
                x.RegistrationDateTime = DateTime.Now;
            });
        }
    }
}
