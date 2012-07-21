using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Role.Messages.InternalEvents;
using ThreeBytes.User.Role.View.Entities;
using ThreeBytes.User.Role.View.Service.Abstract;
using ThreeBytes.User.Role.View.Validations.Abstract;

namespace ThreeBytes.User.Role.View.Backend.MessageHandlers
{
    public class CreatedRoleInternalEventMessageHandler : IHandleMessages<ICreatedRoleInternalEventMessage>
    {
        private readonly IRoleViewRoleService service;
        private readonly IRoleViewRoleValidatorResolver validatorResolver;

        public CreatedRoleInternalEventMessageHandler(IRoleViewRoleService service, IRoleViewRoleValidatorResolver validatorResolver)
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

            RoleViewRole role = new RoleViewRole
            {
                ItemId = message.Id,
                Name = message.Name,
                ApplicationName = message.ApplicationName
            };

            ValidationResult result = validatorResolver.CreateValidator().Validate(role);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            service.Create(role);
        }
    }
}
