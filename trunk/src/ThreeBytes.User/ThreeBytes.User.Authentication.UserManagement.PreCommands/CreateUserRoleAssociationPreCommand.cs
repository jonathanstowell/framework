using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;

namespace ThreeBytes.User.Authentication.UserManagement.PreCommands
{
    public class CreateUserRoleAssociationPreCommand : ICommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        private bool executed;

        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<ICreateUserRoleAssociationCommandMessage>(x =>
                {
                    x.UserId = UserId;
                    x.RoleId = RoleId;
                });
            }
        }

        public void Validate()
        {
            Results = new ValidationResult();
        }

        public bool HasExecuted { get { return executed; } }
    }
}
