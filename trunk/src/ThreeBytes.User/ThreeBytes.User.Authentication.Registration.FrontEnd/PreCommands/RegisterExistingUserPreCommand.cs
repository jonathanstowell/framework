using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Core.Security.Encryption.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.Registration.Entities;
using ThreeBytes.User.Authentication.Registration.Service.Abstract;
using ThreeBytes.User.Authentication.Registration.Validations.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Registration.FrontEnd.PreCommands
{
    public class RegisterExistingUserPreCommand : ICommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        private readonly IProvideUserConfiguration configuration;
        private readonly IExternalUserService externalUserService;
        private readonly IRegistrationUserValidatorResolver validatorResolver;
        private readonly IPasswordEncoder passwordEncoder;
        private bool executed;

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterExistingUserPreCommand(IRegistrationUserValidatorResolver validatorResolver, IPasswordEncoder passwordEncoder, IProvideUserConfiguration configuration, IExternalUserService externalUserService)
        {
            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            if (passwordEncoder == null)
                throw new ArgumentNullException("passwordEncoder");

            if (configuration == null)
                throw new ArgumentNullException("configuration");

            this.passwordEncoder = passwordEncoder;
            this.validatorResolver = validatorResolver;
            this.configuration = configuration;
            this.externalUserService = externalUserService;
        }

        public void Execute()
        {
            Validate();

            executed = true;


            if (Results.IsValid)
            {
                Bus.Send<IRegisterExistingExternalUserCommandMessage>(x =>
                                                          {
                                                              x.ApplicationName = configuration.ApplicationName;
                                                              x.Username = UserName;
                                                              x.Email = Email;
                                                              x.Password = passwordEncoder.EncodePassword(Password);
                                                              x.ConfirmPassword = passwordEncoder.EncodePassword(ConfirmPassword);
                                                          });
            }
        }

        public void Validate()
        {
            RegistrationUser user = new RegistrationUser
                                        {
                                            Username = UserName,
                                            Email = Email,
                                            Password = Password,
                                            ConfirmPassword = ConfirmPassword,
                                            ApplicationName = configuration.ApplicationName
                                        };

            Results = validatorResolver.CreateValidator().Validate(user);
        }

        public bool HasExecuted { get { return executed; } }
    }
}