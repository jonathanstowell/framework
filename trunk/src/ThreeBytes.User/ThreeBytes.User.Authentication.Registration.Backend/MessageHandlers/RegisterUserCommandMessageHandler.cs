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
using ThreeBytes.User.Messages.ExternalEvents;

namespace ThreeBytes.User.Authentication.Registration.Backend.MessageHandlers
{
    public class RegisterUserCommandMessageHandler : IHandleMessages<IRegisterUserCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IRegistrationUserService service;
        private readonly IExternalUserService externalUserService;
        private readonly IRegistrationUserValidatorResolver validatorResolver;

        public RegisterUserCommandMessageHandler(IRegistrationUserService service, IRegistrationUserValidatorResolver validatorResolver, IExternalUserService externalUserService)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
            this.externalUserService = externalUserService;
        }

        public void Handle(IRegisterUserCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            RegistrationUser user = new RegistrationUser
                                        {
                                            Username = message.Username,
                                            Email = message.Email,
                                            ApplicationName = message.ApplicationName,
                                            IsVerified = false,
                                            VerifiedCode = Guid.NewGuid(),
                                            Password = message.Password,
                                            ConfirmPassword = message.ConfirmPassword
                                        };

            ValidationResult result = validatorResolver.CreateValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not register User", result);
            }

            if (!service.HasRecords(message.ApplicationName) && !externalUserService.HasRecords(message.ApplicationName))
            {
                Bus.PublishAndSendLocal<ISetupUserSystemExternalEventMessage>(x =>
                {
                    x.ApplicationName = message.ApplicationName;
                });
            }

            service.Create(user);

            Bus.PublishAndSendLocal<IRegisteredUserInternalEventMessage>(x =>
            {
                x.Id = user.Id;
                x.Username = user.Username;
                x.Email = user.Email;
                x.Password = message.Password;
                x.VerifiedCode = user.VerifiedCode;
                x.ApplicationName = user.ApplicationName;
                x.RegistrationDateTime = DateTime.Now;
            });
        }
    }
}
