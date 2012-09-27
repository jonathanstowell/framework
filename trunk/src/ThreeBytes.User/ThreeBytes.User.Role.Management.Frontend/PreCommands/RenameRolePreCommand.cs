using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.User.Role.Management.Entities;
using ThreeBytes.User.Role.Management.Service.Abstract;
using ThreeBytes.User.Role.Management.Validations.Abstract;
using ThreeBytes.User.Role.Messages.Commands;

namespace ThreeBytes.User.Role.Management.Frontend.PreCommands
{
    public class RenameRolePreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        private readonly IRoleManagementRoleValidatorResolver validatorResolver;
        private readonly IRoleManagementRoleService service;
        private bool executed;

        public RenameRolePreCommand(IRoleManagementRoleService service, IRoleManagementRoleValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public Guid Id { get; set; }
        public string NewName { get; set; }

        public RenameRolePreCommand(IBus bus)
        {
            Bus = bus;
        }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IRenameRoleCommandMessage>(x =>
                {
                    x.Id = Id;
                    x.NewName = NewName;
                });
            }
        }

        public void Validate()
        {
            RoleManagementRole role = service.GetById(Id);

            if (role == null)
            {
                Results.Errors.Add(new ValidationFailure("General", "News Article does not exist"));
                return;
            }

            role.Name = NewName;

            Results = validatorResolver.RenameValidator().Validate(role);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
