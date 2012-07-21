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
    public class CreatedRoleExternalEventMessageHandler : IHandleMessages<ICreatedRoleExternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IAuthenticationUserManagementRoleService service;
        private readonly IAuthenticationUserManagementRoleValidatorResolver validatorResolver;

        public CreatedRoleExternalEventMessageHandler(IAuthenticationUserManagementRoleService service, IAuthenticationUserManagementRoleValidatorResolver validatorResolver)
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

            AuthenticationUserManagementRole role = new AuthenticationUserManagementRole
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
