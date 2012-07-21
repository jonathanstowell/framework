using System;
using FluentValidation.Results;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Entities.Enums;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Authentication.OAuth.Validations.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Frontend.PreCommands
{
    public class LinkExistingUserToExternalProviderPreCommand : ICommand
    {
        private readonly IProvideUserConfiguration configuration;
        private readonly IOAuthUserService service;
        private readonly IOAuthUserValidatorResolver validatorResolver;
        private bool executed;

        public LinkExistingUserToExternalProviderPreCommand(IProvideUserConfiguration configuration, IOAuthUserService service, IOAuthUserValidatorResolver validatorResolver)
        {
            this.configuration = configuration;
            this.service = service;
            this.validatorResolver = validatorResolver;
        }

        public IBus Bus { get; set; }
        public ValidationResult Results { get; set; }

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
                Bus.Send<ILinkExistingUserToExternalProviderCommandMessage>(x =>
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
            OAuthUser user = service.GetById(Identifier);

            if (user != null)
            {
                user.AddExternalAuthenticator(new ExternalAuthenticator
                {
                    ExternalIdentifier = ExternalIdentifier,
                    Username = Username,
                    Email = Email,
                    ExternalAuthenticationType = ExternalProvider,
                    Token = Token,
                    TokenSecret = TokenSecret
                });
            }

            Results = validatorResolver.LinkExternalProviderValidator().Validate(user);
        }

        public bool HasExecuted
        {
            get { return executed; }
        }
    }
}