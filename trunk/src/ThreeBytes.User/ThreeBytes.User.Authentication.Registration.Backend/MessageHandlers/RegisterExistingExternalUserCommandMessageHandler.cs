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
    public class RegisterExistingExternalUserCommandMessageHandler : IHandleMessages<IRegisterExistingExternalUserCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly IRegistrationUserService service;
        private readonly IExternalUserService externalUserService;
        private readonly IRegistrationUserValidatorResolver validatorResolver;

        public RegisterExistingExternalUserCommandMessageHandler(IRegistrationUserService service, IRegistrationUserValidatorResolver validatorResolver, IExternalUserService externalUserService)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
            this.externalUserService = externalUserService;
        }

        public void Handle(IRegisterExistingExternalUserCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

            ExternalUser externalUser = externalUserService.GetUserByEmail(message.Email, message.ApplicationName);

            RegistrationUser user = new RegistrationUser
                                        {
                                            Username = message.Username,
                                            Email = message.Email,
                                            ApplicationName = message.ApplicationName,
                                            IsVerified = true,
                                            VerifiedCode = Guid.NewGuid(),
                                            Password = message.Password,
                                            ConfirmPassword = message.ConfirmPassword
                                        };

            ValidationResult result = validatorResolver.CreateValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not register User", result);
            }

            service.Create(user);

            Bus.PublishAndSendLocal<IRegisterExistingExternalUserInternalEventMessage>(x =>
                                                                             {
                                                                                 x.Id = externalUser.Id;
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