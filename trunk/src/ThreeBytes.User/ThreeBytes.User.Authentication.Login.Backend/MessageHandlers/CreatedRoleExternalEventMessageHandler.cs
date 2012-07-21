using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;
using ThreeBytes.User.Authentication.Login.Validations.Abstract;
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.Login.Backend.MessageHandlers
{
    public class CreatedRoleExternalEventMessageHandler : IHandleMessages<ICreatedRoleExternalEventMessage>
    {
        private readonly ILoginRoleService service;
        private readonly ILoginRoleValidatorResolver validatorResolver;

        public CreatedRoleExternalEventMessageHandler(ILoginRoleService service, ILoginRoleValidatorResolver validatorResolver)
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

            LoginRole role = new LoginRole
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
