using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Role.List.Entities;
using ThreeBytes.User.Role.List.Service.Abstract;
using ThreeBytes.User.Role.List.Validations.Abstract;
using ThreeBytes.User.Role.Messages.Commands;

namespace ThreeBytes.User.Role.List.Backend.MessageHandlers
{
    public class RenamedRoleEventMessageHandler : IHandleMessages<IRenameRoleCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IRoleListRoleService service;
        private readonly IRoleListRoleValidatorResolver validatorResolver;

        public RenamedRoleEventMessageHandler(IRoleListRoleService service, IRoleListRoleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRenameRoleCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            RoleListRole role = service.GetById(message.Id);

            if (role == null)
                return;

            if (role.Name == message.NewName)
                return;

            role.Name = message.NewName;

            ValidationResult result = validatorResolver.RenameValidator().Validate(role);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not rename Role", result);
            }

            service.Update(role);
        }
    }
}
