using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Data.Entities.Abstract;
using ThreeBytes.Core.Data.Entities.Concrete;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.UserView.Entities;
using ThreeBytes.User.Authentication.UserView.Service.Abstract;
using ThreeBytes.User.Authentication.UserView.Validations.Abstract;

namespace ThreeBytes.User.Authentication.UserView.Backend.MessageHandlers
{
    public class CreatedUserAssociationInternalEventMessageHandler : IHandleMessages<ICreatedUserRoleAssociationInternalEventMessage>
    {
        private readonly IAuthenticationUserViewUserService userService;
        private readonly IAuthenticationUserViewRoleService roleService;
        private readonly IAuthenticationUserViewUserValidatorResolver validatorResolver;

        public CreatedUserAssociationInternalEventMessageHandler(IAuthenticationUserViewUserService userService, IAuthenticationUserViewRoleService roleService, IAuthenticationUserViewUserValidatorResolver validatorResolver)
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

        public void Handle(ICreatedUserRoleAssociationInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            AuthenticationUserViewUser oldAuthenticationUser = userService.GetById(message.UserId);

            if (oldAuthenticationUser == null)
                return;

            AuthenticationUserViewUser newAuthenticationUser = new AuthenticationUserViewUser(oldAuthenticationUser);

            AuthenticationUserViewRole role = roleService.GetById(message.RoleId);

            if (role == null)
                return;

            if (newAuthenticationUser.Roles.Contains(role))
                return;

            newAuthenticationUser.AddRole(role);

            ValidationResult result = validatorResolver.UpdateRolesValidator().Validate(newAuthenticationUser);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User Role association", result);
            }

            IHistoricalUpdateOperation<AuthenticationUserViewUser> updateOperation = new HistoricalUpdateOperation<AuthenticationUserViewUser>
            {
                OldItem = oldAuthenticationUser,
                NewItem = newAuthenticationUser,
                OperationDescription = string.Format("Added new Role '{0}'.", role.Name)
            };

            userService.Update(updateOperation);
        }
    }
}
