using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Role.List.Entities;
using ThreeBytes.User.Role.List.Service.Abstract;
using ThreeBytes.User.Role.List.Validations.Abstract;
using ThreeBytes.User.Role.Messages.InternalEvents;

namespace ThreeBytes.User.Role.List.Backend.MessageHandlers
{
    public class CreatedRoleInternalEventMessageHandler : IHandleMessages<ICreatedRoleInternalEventMessage>
    {
        private readonly IRoleListRoleService service;
        private readonly IRoleListRoleValidatorResolver validatorResolver;

        public CreatedRoleInternalEventMessageHandler(IRoleListRoleService service, IRoleListRoleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreatedRoleInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            RoleListRole role = new RoleListRole
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
