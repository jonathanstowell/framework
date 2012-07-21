using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Role.Management.Entities;
using ThreeBytes.User.Role.Management.Service.Abstract;
using ThreeBytes.User.Role.Management.Validations.Abstract;
using ThreeBytes.User.Role.Messages.Commands;
using ThreeBytes.User.Role.Messages.InternalEvents;

namespace ThreeBytes.User.Role.Management.Backend.MessageHandlers
{
    public class RenameRoleCommandMessageHandler : IHandleMessages<IRenameRoleCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IRoleManagementRoleService service;
        private readonly IRoleManagementRoleValidatorResolver validatorResolver;

        public RenameRoleCommandMessageHandler(IRoleManagementRoleService service, IRoleManagementRoleValidatorResolver validatorResolver)
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

            RoleManagementRole role = service.GetById(message.Id);

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

            Bus.PublishAndSendLocal<IRenamedRoleInternalEventMessage>(x =>
            {
                x.Id = role.Id;
                x.NewName = role.Name;
            });
        }
    }
}
