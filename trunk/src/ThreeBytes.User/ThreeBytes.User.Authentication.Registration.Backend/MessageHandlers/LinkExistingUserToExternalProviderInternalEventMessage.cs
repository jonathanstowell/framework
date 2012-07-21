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
    public class LinkExistingUserToExternalProviderInternalEventMessage : IHandleMessages<ILinkExistingUserToExternalProviderInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IExternalUserService service;
        private readonly IExternalUserValidatorResolver validatorResolver;

        public LinkExistingUserToExternalProviderInternalEventMessage(IExternalUserService service, IExternalUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ILinkExistingUserToExternalProviderInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ExternalUser user = service.GetById(message.Id);

            if (user == null)
                return;

            if (user.HasLinkedExternalProvider((ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider)))
                return;

            user.AddExternalAuthenticator(new ExternalAuthenticator
            {
                ExternalIdentifier = message.ExternalIdentifier,
                ApplicationName = message.ApplicationName,
                Username = message.Username,
                Email = message.Email,
                ExternalAuthenticationType = (ExternalAuthenticationType)Enum.Parse(typeof(ExternalAuthenticationType), message.ExternalProvider),
                CreationDateTime = DateTime.Now
            });

            ValidationResult result = validatorResolver.LinkExternalProviderValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException(string.Format("Could not link external provider to User with id: {0}", user.Id), result);
            }

            service.Update(user);
        }
    }
}