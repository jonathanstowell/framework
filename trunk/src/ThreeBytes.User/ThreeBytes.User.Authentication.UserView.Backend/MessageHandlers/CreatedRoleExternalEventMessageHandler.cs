using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;
using ThreeBytes.User.Authentication.UserView.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.UserView.Backend.MessageHandlers
{
    public class CreatedRoleExternalEventMessageHandler : IHandleMessages<ICreatedRoleExternalEventMessage>
    {
        private readonly IAuthenticationUserViewRoleService service;
        private readonly IAuthenticationUserViewRoleValidatorResolver validatorResolver;

        public CreatedRoleExternalEventMessageHandler(IAuthenticationUserViewRoleService service, IAuthenticationUserViewRoleValidatorResolver validatorResolver)
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

            AuthenticationUserViewRole role = new AuthenticationUserViewRole
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
