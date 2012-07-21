using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.Password.Entities;
using ThreeBytes.User.Authentication.Password.Service.Abstract;
using ThreeBytes.User.Authentication.Password.Validations.Abstract;

namespace ThreeBytes.User.Authentication.Password.Backend.MessageHandlers
{
    public class RegisterExistingExternalUserInternalEventMessageHandler : IHandleMessages<IRegisterExistingExternalUserInternalEventMessage>
    {
        private readonly IPasswordManagementUserService service;
        private readonly IPasswordManagementUserValidatorResolver validatorResolver;

        public RegisterExistingExternalUserInternalEventMessageHandler(IPasswordManagementUserService service, IPasswordManagementUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisterExistingExternalUserInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            PasswordManagementUser user = new PasswordManagementUser
                                              {
                                                  Id = message.Id,
                                                  Username = message.Username,
                                                  ApplicationName = message.ApplicationName,
                                                  Email = message.Email,
                                                  IsVerified = false,
                                                  IsLockedOut = false,
                                                  Password = message.Password,
                                                  ConfirmPassword = message.Password
                                              };

            ValidationResult result = validatorResolver.CreateValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            service.Create(user);
        }
    }
}