using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Validations.Exceptions;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;
using ThreeBytes.User.Authentication.Login.Validations.Abstract;
using ThreeBytes.User.Authentication.Messages.InternalEvents;

namespace ThreeBytes.User.Authentication.Login.Backend.MessageHandlers
{
    public class RegisteredUserInternalEventMessageHandler : IHandleMessages<IRegisteredUserInternalEventMessage>
    {
        private readonly ILoginUserService service;
        private readonly ILoginUserValidatorResolver validatorResolver;

        public RegisteredUserInternalEventMessageHandler(ILoginUserService service, ILoginUserValidatorResolver validatorResolver)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Handle(IRegisteredUserInternalEventMessage message)
        {
            if (message == null)
                throw new ArgumentNullException("message"); 

            LoginUser user = new LoginUser
                                 {
                                     Id = message.Id,
                                     Username = message.Username,
                                     ApplicationName = message.ApplicationName,
                                     Email = message.Email,
                                     Password = message.Password,
                                     IsVerified = false,
                                     IsLockedOut = false,
                                     FailedPasswordAttemptCount = 0,
                                     FailedPasswordAttemptWindowStart = DateTime.Now
                                 };

            if(!service.HasRecords(message.ApplicationName))
            {
                LoginRole theCreator = new LoginRole("Creator", message.ApplicationName) { Id = Guid.NewGuid() };

                if (!user.Roles.Contains(theCreator))
                    user.AddRole(theCreator);
            }

            ValidationResult result = validatorResolver.CreateValidator().Validate(user);

            if (!result.IsValid)
            {
                throw new AsyncServiceValidationException("Could not create User", result);
            }

            service.Create(user);
        }
    }
}
