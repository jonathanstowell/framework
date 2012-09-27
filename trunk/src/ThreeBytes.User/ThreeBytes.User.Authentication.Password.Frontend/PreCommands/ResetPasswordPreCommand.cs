using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.Password.Entities;
using ThreeBytes.User.Authentication.Password.Service.Abstract;
using ThreeBytes.User.Authentication.Password.Validations.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Password.Frontend.PreCommands
{
    public class ResetPasswordPreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        public string UserIdentifier { get; set; }

        private readonly IPasswordManagementUserService service;
        private readonly IPasswordManagementUserValidatorResolver validatorResolver;
        private readonly IProvideUserConfiguration configuration;
        private bool executed;

        public ResetPasswordPreCommand(IProvideUserConfiguration configuration, IPasswordManagementUserService service, IPasswordManagementUserValidatorResolver validatorResolver)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");

            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            this.configuration = configuration;
            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IResetPasswordInitialCommandMessage>(x =>
                {
                    x.ApplicationName = configuration.ApplicationName;
                    x.UserIdentifier = UserIdentifier;
                });
            }
        }

        public void Validate()
        {
            PasswordManagementUser user = service.GetByUsernameOrEmail(UserIdentifier, configuration.ApplicationName);
            Results = validatorResolver.ResetPasswordValidator().Validate(user);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
