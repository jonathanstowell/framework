using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Core.Security.Encryption.Abstract;
using ThreeBytes.User.Authentication.Login.Entities;
using ThreeBytes.User.Authentication.Login.Service.Abstract;
using ThreeBytes.User.Authentication.Login.Validations.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Login.Frontend.Commands
{
    public class LoginUserCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

        private readonly ILoginUserService service;
        private readonly ILoginUserValidatorResolver validatorResolver;
        private readonly IProvideUserConfiguration userConfiguration;
        private readonly IPasswordEncoder passwordEncoder;
        private bool executed;
        private LoginUser user;

        public LoginUserCommand(ILoginUserValidatorResolver validatorResolver, ILoginUserService service, IProvideUserConfiguration userConfiguration, IPasswordEncoder passwordEncoder)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (validatorResolver == null)
                throw new ArgumentNullException("validatorResolver");

            if (userConfiguration == null)
                throw new ArgumentNullException("userConfiguration");

            if (passwordEncoder == null)
                throw new ArgumentNullException("passwordEncoder");

            this.validatorResolver = validatorResolver;
            this.service = service;
            this.userConfiguration = userConfiguration;
            this.passwordEncoder = passwordEncoder;
        }

        public string UserIdentifier { get; set; }
        public string Password { get; set; }

        public void Execute()
        {
            Validate();
            executed = true;
        }

        public void Validate()
        {
            user = service.GetByUsernameOrEmail(UserIdentifier, userConfiguration.ApplicationName);
            Results = validatorResolver.AuthenticateUserValidator().Validate(user);

            if (Results.IsValid)
            {
                if (user.Password != passwordEncoder.EncodePassword(Password))
                {
                    Results.Errors.Add(new ValidationFailure("Password", "Incorrect Password"));
                }

                if (Results.IsValid)
                {
                    Bus.Send<IUserLoggedInCommandMessage>(x =>
                    {
                        x.UserId = user.Id;
                        x.Username = user.Username;
                        x.ApplicationName = user.ApplicationName;
                        x.LoginDate = DateTime.Now;
                    });
                }
            }
        }

        public bool HasExecuted { get { return executed; } }
        public LoginUser User { get { return user; } }
    }
}
