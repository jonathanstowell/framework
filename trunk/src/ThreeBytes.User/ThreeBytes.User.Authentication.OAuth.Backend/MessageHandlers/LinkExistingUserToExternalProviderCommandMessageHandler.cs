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

namespace ThreeBytes.User.Authentication.OAuth.Backend.MessageHandlers
{
    public class LinkExistingUserToExternalProviderCommandMessageHandler : IHandleMessages<ILinkExistingUserToExternalProviderCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IOAuthUserService service;
        private readonly IOAuthUserValidatorResolver validatorResolver;

        public LinkExistingUserToExternalProviderCommandMessageHandler(IOAuthUserService service, IOAuthUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ILinkExistingUserToExternalProviderCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            OAuthUser user = service.GetById(message.Identifier);

            if (user.HasLinkedExternalProvider((ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider)))
                return;

            user.AddExternalAuthenticator(new ExternalAuthenticator
            {
                ExternalIdentifier = message.ExternalIdentifier,
                Username = message.Username,
                Email = message.Email,
                ExternalAuthenticationType = (ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider),
                Token = message.Token,
                TokenSecret = message.TokenSecret
            });

            ValidationResult result = validatorResolver.LinkExternalProviderValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException(string.Format("Could not link external provider to User with id: {0}", user.Id), result);
            }

            service.Update(user);

            Bus.PublishAndSendLocal<ILinkExistingUserToExternalProviderInternalEventMessage>(x =>
            {
                x.Id = user.Id;
                x.Username = message.Username;
                x.Email = message.Email;
                x.ExternalIdentifier = message.ExternalIdentifier;
                x.ExternalProvider = message.ExternalProvider;
                x.ApplicationName = user.ApplicationName;
                x.Token = message.Token;
                x.TokenSecret = message.TokenSecret;
                x.LinkDateTime = DateTime.Now;
            });
        }
    }
}