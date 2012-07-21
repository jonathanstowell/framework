using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.Messages.InternalEvents;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;
using ThreeBytes.User.Authentication.Registration.Validations.Abstract;

namespace ThreeBytes.User.Authentication.Registration.Backend.MessageHandlers
{
    public class VerifyUserCommandMessageHandler : IHandleMessages<IVerifyUserCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IRegistrationUserService service;
        private readonly IRegistrationUserValidatorResolver validatorResolver;

        public VerifyUserCommandMessageHandler(IRegistrationUserService service, IRegistrationUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IVerifyUserCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message"); 

            RegistrationUser user = service.GetByUsernameOrEmail(message.UserIdentifier, message.ApplicationName);

            if (user == null)
                return;

            if (user.IsVerified)
                return;

            if (user.VerifiedCode != message.VerifiedCode)
                return;

            user.IsVerified = true;

            ValidationResult result = validatorResolver.VerifyUserValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not register User", result);
            }

            service.Update(user);

            Bus.PublishAndSendLocal<IVerifiedUserInternalEventMessage>(x =>
            {
                x.Id = user.Id;
            });
        }
    }
}
