﻿using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;
using ThreeBytes.User.Authentication.Login.Validations.Abstract;
using ThreeBytes.User.Authentication.Messages.InternalEvents;

namespace ThreeBytes.User.Authentication.Login.Backend.MessageHandlers
{
    public class CreatedUserAssociationInternalEventMessageHandler : IHandleMessages<ICreatedUserRoleAssociationInternalEventMessage>
    {
        private readonly ILoginUserService userService;
        private readonly ILoginRoleService roleService;
        private readonly ILoginUserValidatorResolver validatorResolver;

        public CreatedUserAssociationInternalEventMessageHandler(ILoginUserService userService, ILoginRoleService roleService, ILoginUserValidatorResolver validatorResolver)
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

        public void Handle(ICreatedUserRoleAssociationInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message"); 

            LoginUser user = userService.GetById(message.UserId);
            LoginRole role = roleService.GetById(message.RoleId);

            if (user == null)
                return;

            if (role == null)
                return;

            if (user.Roles.Contains(role))
                return;

            ValidationResult result = validatorResolver.UpdateRolesValidator().Validate(user);

            user.AddRole(role);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User Role association", result);
            }

            userService.Update(user);
        }
    }
}
