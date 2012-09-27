using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;
using ThreeBytes.User.Authentication.Registration.Validations.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Registration.FrontEnd.PreCommands
{
    public class VerifyAccountPreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        private readonly IRegistrationUserService service;
        private readonly IRegistrationUserValidatorResolver validatorResolver;
        private readonly IProvideUserConfiguration configuration;
        private bool executed;

        public string UserIdentifier { get; set; }
        public Guid VerifiedCode { get; set; }

        public VerifyAccountPreCommand(IRegistrationUserValidatorResolver validatorResolver, IRegistrationUserService service, IProvideUserConfiguration configuration)
        {
            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            if (service == null)
                throw new ArgumentNullException("service");

            if (configuration == null)
                throw new ArgumentNullException("configuration");

            this.validatorResolver = validatorResolver;
            this.service = service;
            this.configuration = configuration;
        }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IVerifyUserCommandMessage>(x =>
                {
                    x.UserIdentifier = UserIdentifier;
                    x.VerifiedCode = VerifiedCode;
                    x.ApplicationName = configuration.ApplicationName;
                });
            }
        }

        public void Validate()
        {
            RegistrationUser user = service.GetByUsernameOrEmail(UserIdentifier, configuration.ApplicationName);
     
            if (user != null)
                user.VerifiedCode = VerifiedCode;
                
            Results = validatorResolver.VerifyUserValidator().Validate(user);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
