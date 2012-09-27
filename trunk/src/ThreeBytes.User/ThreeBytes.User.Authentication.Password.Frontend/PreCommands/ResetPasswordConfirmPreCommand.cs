using System;
using FluentValidation;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Core.Security.Encryption.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.Password.Entities;
using ThreeBytes.User.Authentication.Password.Service.Abstract;
using ThreeBytes.User.Authentication.Password.Validations.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Password.Frontend.PreCommands
{
    public class ResetPasswordConfirmPreCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        public string UserIdentifier { get; set; }
        public Guid ResetPasswordCode { get; set; }
        public string NewPassword { get; set; }
        public string NewConfirmPassword { get; set; }

        private readonly IPasswordManagementUserService service;
        private readonly IPasswordManagementUserValidatorResolver validatorResolver;
        private readonly IProvideUserConfiguration configuration;
        private readonly IPasswordEncoder passwordEncoder;
        private bool executed;

        public ResetPasswordConfirmPreCommand(IProvideUserConfiguration configuration, IPasswordEncoder passwordEncoder, IPasswordManagementUserValidatorResolver validatorResolver, IPasswordManagementUserService service)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");

            if (passwordEncoder == null)
                throw new ArgumentNullException("passwordEncoder");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            if (service == null)
                throw new ArgumentNullException("service");

            this.configuration = configuration;
            this.passwordEncoder = passwordEncoder;
            this.validatorResolver = validatorResolver;
            this.service = service;
        }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IResetPasswordConfirmCommandMessage>(x =>
                {
                    x.ApplicationName = configuration.ApplicationName;
                    x.UserIdentifier = UserIdentifier;
                    x.ResetPasswordCode = ResetPasswordCode;
                    x.NewPassword = passwordEncoder.EncodePassword(NewPassword);
                    x.NewConfirmPassword = passwordEncoder.EncodePassword(NewConfirmPassword);
                });
            }
        }

        public void Validate()
        {
            PasswordManagementUser user = service.GetByUsernameOrEmail(UserIdentifier, configuration.ApplicationName);

            if (user != null)
            {
                user.Password = passwordEncoder.EncodePassword(NewPassword);
                user.ConfirmPassword = passwordEncoder.EncodePassword(NewConfirmPassword);
                user.ResetPasswordCode = ResetPasswordCode;
            }

            Results = validatorResolver.ResetPasswordConfirmValidator().Validate(user);
        }

        public bool HasExecuted { get { return executed; } }
    }
}
