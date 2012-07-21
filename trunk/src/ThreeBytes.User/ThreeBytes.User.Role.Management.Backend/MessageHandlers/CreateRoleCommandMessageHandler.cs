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
    public class CreateRoleCommandMessageHandler : IHandleMessages<ICreateRoleCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IRoleManagementRoleService service;
        private readonly IRoleManagementRoleValidatorResolver validatorResolver;

        public CreateRoleCommandMessageHandler(IRoleManagementRoleService service, IRoleManagementRoleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ICreateRoleCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            RoleManagementRole role = new RoleManagementRole
            {
                Name = message.Name,
                ApplicationName = message.ApplicationName
            };

            ValidationResult result = validatorResolver.CreateValidator().Validate(role);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create Role", result);
            }

            service.Create(role);

            Bus.PublishAndSendLocal<ICreatedRoleInternalEventMessage>(x =>
            {
                x.Id = role.Id;
                x.Name = role.Name;
                x.ApplicationName = role.ApplicationName;
            });
        }
    }
}
