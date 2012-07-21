using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Validations.Abstract;

namespace ThreeBytes.User.Authentication.UserManagement.Frontend.PreCommands
{
    public class RemoveUserRoleAssociationPreCommand : ICommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        private readonly IAuthenticationUserManagementUserService userService;
        private readonly IAuthenticationUserManagementRoleService roleService;
        private readonly IAuthenticationUserManagementUserValidatorResolver validatorResolver;
        private bool executed;

        public RemoveUserRoleAssociationPreCommand(IAuthenticationUserManagementUserService userService, IAuthenticationUserManagementUserValidatorResolver validatorResolver, IAuthenticationUserManagementRoleService roleService)
        {
            if (userService == null)
                throw new ArgumentNullException("userService");

            if (roleService == null)
                throw new ArgumentNullException("roleService");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.userService = userService;
            this.validatorResolver = validatorResolver;
            this.roleService = roleService;
        }

        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IRemoveUserRoleAssociationCommandMessage>(x =>
                                                                       {
                                                                           x.UserId = UserId;
                                                                           x.RoleId = RoleId;
                                                                       });
            }
        }

        public void Validate()
        {
            AuthenticationUserManagementUser user = userService.GetById(UserId);
            AuthenticationUserManagementRole role = roleService.GetById(RoleId);

            if (user != null)
            {
                if (role == null)
                    throw new ArgumentNullException("role");

                user.RemoveRole(role);
            }

            Results = validatorResolver.UpdateRolesValidator().Validate(user);
        }

        public bool HasExecuted { get { return executed; } }
    }
}