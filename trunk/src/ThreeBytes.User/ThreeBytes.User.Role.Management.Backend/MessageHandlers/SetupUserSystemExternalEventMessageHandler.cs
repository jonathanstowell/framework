using System;
using System.Collections.Generic;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Messages.ExternalEvents;
using ThreeBytes.User.Role.Management.Entities;
using ThreeBytes.User.Role.Management.Service.Abstract;
using ThreeBytes.User.Role.Management.Validations.Abstract;
using ThreeBytes.User.Role.Messages.InternalEvents;

namespace ThreeBytes.User.Role.Management.Backend.MessageHandlers
{
    public class SetupUserSystemExternalEventMessageHandler : IHandleMessages<ISetupUserSystemExternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IRoleManagementRoleService service;
        private readonly IRoleManagementRoleValidatorResolver validatorResolver;

        public SetupUserSystemExternalEventMessageHandler(IRoleManagementRoleService service, IRoleManagementRoleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(ISetupUserSystemExternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            IList<RoleManagementRole> roles = new List<RoleManagementRole>();

            roles.Add(new RoleManagementRole
            {
                Name = "Admin",
                ApplicationName = message.ApplicationName
            });

            roles.Add(new RoleManagementRole
            {
                Name = "RoleManagement",
                ApplicationName = message.ApplicationName
            });

            roles.Add(new RoleManagementRole
            {
                Name = "UserManagement",
                ApplicationName = message.ApplicationName
            });

            foreach (var role in roles)
            {
                ValidationResult result = validatorResolver.CreateValidator().Validate(role);

                if (!result.IsValid)
                {
                    throw new AsyncServiceValidationException("Could not create Role", result);
                }   
            }

            service.Create(roles);

            foreach (var role in roles)
            {
                Bus.PublishAndSendLocal<ICreatedRoleInternalEventMessage>(x =>
                {
                    x.Id = role.Id;
                    x.Name = role.Name;
                    x.ApplicationName = role.ApplicationName;
                });
            }
        }
    }
}
