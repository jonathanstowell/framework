using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.UserManagement.Entities;
using ThreeBytes.User.Authentication.UserManagement.Service.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Validations.Abstract;

namespace ThreeBytes.User.Authentication.UserManagement.Backend.MessageHandlers
{
    public class RemoveUserRoleAssociationCommandMessageHandler : IHandleMessages<IRemoveUserRoleAssociationCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IAuthenticationUserManagementUserService userService;
        private readonly IAuthenticationUserManagementRoleService roleService;
        private readonly IAuthenticationUserManagementUserValidatorResolver validatorResolver;

        public RemoveUserRoleAssociationCommandMessageHandler(IAuthenticationUserManagementUserService userService, IAuthenticationUserManagementRoleService roleService, IAuthenticationUserManagementUserValidatorResolver validatorResolver)
        {
            if (userService == null)
                throw new ArgumentNullException("userService");

            if (roleService == null)
                throw new ArgumentNullException("roleService");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.userService = userService;
            this.roleService = roleService;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRemoveUserRoleAssociationCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserManagementUser user = userService.GetById(message.UserId);

            if (user == null)
                return;

            AuthenticationUserManagementRole role = roleService.GetById(message.RoleId);

            if (role == null)
                return;

            if (!user.Roles.Contains(role))
                return;

            user.RemoveRole(role);

            ValidationResult result = validatorResolver.UpdateRolesValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not remove User Role association", result);
            }

            userService.Update(user);

            Bus.PublishAndSendLocal<IRemoveUserRoleAssociationInternalEventMessage>(x =>
                                                                                        {
                                                                                            x.UserId = user.Id;
                                                                                            x.RoleId = role.Id;
                                                                                        });
        }
    }
}