using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Extensions.NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Login.Configuration.Abstract;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;
using ThreeBytes.User.Authentication.Login.Validations.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.Messages.InternalEvents;

namespace ThreeBytes.User.Authentication.Login.Backend.MessageHandlers
{
    public class UserEnteredIncorrectPasswordCommandMessageHandler : IHandleMessages<IUserEnteredIncorrectPasswordCommandMessage>
    {
        public IBus Bus { get; set; }

        private readonly ILoginUserService service;
        private readonly ILoginUserValidatorResolver validatorResolver;
        private readonly IProvideLoginConfiguration loginConfiguration;

        public UserEnteredIncorrectPasswordCommandMessageHandler(ILoginUserService service, ILoginUserValidatorResolver validatorResolver, IProvideLoginConfiguration loginConfiguration)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            if (loginConfiguration == null)
                throw new ArgumentNullException("loginConfiguration");

            this.service = service;
            this.validatorResolver = validatorResolver;
            this.loginConfiguration = loginConfiguration;
        }

        public void Handle(IUserEnteredIncorrectPasswordCommandMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message"); 

            LoginUser user = service.GetById(message.Id);

            if (user == null)
                return;

            if (user.FailedPasswordAttemptWindowStart > DateTime.Now.AddDays(1))
            {
                user.FailedPasswordAttemptWindowStart = DateTime.Now;
                user.FailedPasswordAttemptCount = 0;
            }

            user.FailedPasswordAttemptCount = user.FailedPasswordAttemptCount + 1;

            ValidationResult result = validatorResolver.UserEnteredIncorrectPasswordValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not unlock account", result);
            }

            if (user.FailedPasswordAttemptCount == loginConfiguration.LockUserOutAfterNAttempts)
                user.IsLockedOut = true;

            service.Update(user);

            Bus.PublishAndSendLocal<IAuthenticationUserEnteredIncorrectPasswordInternalEventMessage>(x =>
            {
                x.Id = user.Id;
            });

            if (user.IsLockedOut)
            {
                Bus.PublishAndSendLocal<ILockUserOutInternalEventMessage>(x =>
                {
                    x.Id = user.Id;
                });
            }
        }
    }
}
