using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Role.Messages.InternalEvents;
using ThreeBytes.User.Role.View.Entities;
using ThreeBytes.User.Role.View.Service.Abstract;
using ThreeBytes.User.Role.View.Validations.Abstract;

namespace ThreeBytes.User.Role.View.Backend.MessageHandlers
{
    public class RenamedRoleInternalEventMessageHandler : IHandleMessages<IRenamedRoleInternalEventMessage>
    {
        public IBus Bus { get; set; }

        private readonly IRoleViewRoleService service;
        private readonly IRoleViewRoleValidatorResolver validatorResolver;

        public RenamedRoleInternalEventMessageHandler(IRoleViewRoleService service, IRoleViewRoleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRenamedRoleInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            RoleViewRole oldRole = service.GetById(message.Id);

            if (oldRole == null)
                return;

            RoleViewRole newRole = new RoleViewRole(oldRole);
            newRole.Name = message.NewName;

            ValidationResult result = validatorResolver.RenameValidator().Validate(newRole);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not add User", result);
            }

            IHistoricalUpdateOperation<RoleViewRole> updateOperation = new HistoricalUpdateOperation<RoleViewRole>
            {
                OldItem = oldRole,
                NewItem = newRole,
                OperationDescription = string.Format("Renamed From {0} to {1}", oldRole.Name, newRole.Name)
            };

            service.Update(updateOperation);
        }
    }
}
