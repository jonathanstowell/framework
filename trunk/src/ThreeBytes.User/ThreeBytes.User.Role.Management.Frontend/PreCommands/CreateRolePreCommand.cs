using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.User.Configuration.Abstract;
using ThreeBytes.User.Role.Management.Entities;
using ThreeBytes.User.Role.Management.Validations.Abstract;
using ThreeBytes.User.Role.Messages.Commands;

namespace ThreeBytes.User.Role.Management.Frontend.PreCommands
{
    public class CreateRolePreCommand : ICommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        private readonly IRoleManagementRoleValidatorResolver validatorResolver;
        private readonly IProvideUserConfiguration userConfiguration;
        private bool executed;

        public CreateRolePreCommand(IRoleManagementRoleValidatorResolver validatorResolver, IProvideUserConfiguration userConfiguration)
        {
            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            this.validatorResolver = validatorResolver;
            this.userConfiguration = userConfiguration;
        }

        public string Name { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<ICreateRoleCommandMessage>(x =>
                {
                    x.Name = Name;
                    x.ApplicationName = userConfiguration.ApplicationName;
                });
            }
        }

        public void Validate()
        {
            RoleManagementRole role = new RoleManagementRole
            {
                Name = Name,
                ApplicationName = userConfiguration.ApplicationName
            };

            Results = validatorResolver.CreateValidator().Validate(role);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
