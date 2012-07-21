using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.Password.Entities;
using ThreeBytes.User.Authentication.Password.Service.Abstract;
using ThreeBytes.User.Authentication.Password.Validations.Abstract;

namespace ThreeBytes.User.Authentication.Password.Backend.MessageHandlers
{
    public class ResetPasswordCommandMessageHandler : IHandleMessages<IResetPasswordInitialCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IPasswordManagementUserService service;
        private readonly IPasswordManagementUserValidatorResolver validatorResolver;

        public ResetPasswordCommandMessageHandler(IPasswordManagementUserService service, IPasswordManagementUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IResetPasswordInitialCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message"); 

            PasswordManagementUser user = service.GetByUsernameOrEmail(message.UserIdentifier, message.ApplicationName);

            if (user == null)
                return;

            if (user.ResetPasswordCode != null)
                return;

            user.ResetPasswordCode = Guid.NewGuid();

            ValidationResult result = validatorResolver.ResetPasswordValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            service.Update(user);

            Bus.PublishAndSendLocal<IResetPasswordInitialInternalEventMessage>(x =>
            {
                x.Id = user.Id;
                x.Username = user.Username;
                x.Email = user.Email;
                x.ResetPasswordCode = (Guid)user.ResetPasswordCode;
            });
        }
    }
}