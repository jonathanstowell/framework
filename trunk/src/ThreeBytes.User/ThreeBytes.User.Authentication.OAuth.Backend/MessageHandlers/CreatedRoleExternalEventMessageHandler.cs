using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Authentication.OAuth.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.OAuth.Backend.MessageHandlers
{
    public class CreatedRoleExternalEventMessageHandler : IHandleMessages<ICreatedRoleExternalEventMessage>
    {
        private readonly IOAuthRoleService service;
        private readonly IOAuthRoleValidatorResolver validatorResolver;

        public CreatedRoleExternalEventMessageHandler(IOAuthRoleService service, IOAuthRoleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreatedRoleExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message"); 

            OAuthRole role = new OAuthRole
            {
                Id = message.Id,
                Name = message.Name,
                ApplicationName = message.ApplicationName
            };

            ValidationResult result = validatorResolver.CreateValidator().Validate(role);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Role", result);
            }

            service.Create(role);
        }
    }
}
