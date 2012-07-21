using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Authentication.OAuth.Validations.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Backend.MessageHandlers
{
    public class RemoveUserAssociationInternalEventMessageHandler : IHandleMessages<IRemoveUserRoleAssociationInternalEventMessage>
    {
        private readonly IOAuthUserService userService;
        private readonly IOAuthRoleService roleService;
        private readonly IOAuthUserValidatorResolver validatorResolver;

        public RemoveUserAssociationInternalEventMessageHandler(IOAuthUserService userService, IOAuthRoleService roleService, IOAuthUserValidatorResolver validatorResolver)
        {
            if (roleService == null)
                throw new ArgumentNullException("roleService");

            if (userService == null)
                throw new ArgumentNullException("userService");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.userService = userService;
            this.roleService = roleService;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRemoveUserRoleAssociationInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            OAuthUser user = userService.GetById(message.UserId);
            OAuthRole role = roleService.GetById(message.RoleId);

            if (user == null)
                return;

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
        }
    }
}