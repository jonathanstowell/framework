using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Entities.Enums;
using ThreeBytes.User.Authentication.OAuth.Validations.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Frontend.PreCommands
{
    public class RegisterExternalUserPreCommand : ICommand
    {
        private readonly IProvideUserConfiguration configuration;
        private readonly IOAuthUserValidatorResolver validatorResolver;
        private bool executed;

        public RegisterExternalUserPreCommand(IProvideUserConfiguration configuration, IOAuthUserValidatorResolver validatorResolver)
        {
            this.configuration = configuration;
            this.validatorResolver = validatorResolver;
        }

        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }
        public OAuthUser User { get; set; }

        public Guid Identifier { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ExternalIdentifier { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public ExternalAuthenticationType ExternalProvider { get; set; }

        public void Execute()
        {
            Validate();

            executed = true;

            if (Results.IsValid)
            {
                Bus.Send<IRegisterUserFromExternalProviderCommandMessage>(x =>
                {
                    x.Identifier = Identifier;
                    x.ApplicationName = configuration.ApplicationName;
                    x.Username = Username;
                    x.Email = Email;
                    x.ExternalIdentifier = ExternalIdentifier;
                    x.Token = Token;
                    x.TokenSecret = TokenSecret;
                    x.ExternalProvider = ExternalProvider.ToString();
                });
            }
        }

        public void Validate()
        {
            OAuthUser user = new OAuthUser
            {
                Id = Identifier,
                ApplicationName = configuration.ApplicationName,
                Username = Username,
                Email = Email
            };

            user.AddExternalAuthenticator(new ExternalAuthenticator
            {
                ExternalIdentifier = ExternalIdentifier,
                Email = Email,
                Username = Username,
                ExternalAuthenticationType = ExternalProvider,
                Token = Token,
                TokenSecret = TokenSecret
            });

            Results = validatorResolver.CreateValidator().Validate(user);
        }

        public bool HasExecuted
        {
            get { return executed; }
        }
    }
}
