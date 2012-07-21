using System;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Core.Facebook.Abstract;
using ThreeBytes.Core.Facebook.Entities.Abstract;
using ThreeBytes.User.Authentication.Messages.Commands;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Entities.Enums;
using ThreeBytes.User.Authentication.OAuth.Frontend.PreCommands;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Frontend.Commands
{
    public class FacebookLoginCommand : ICommand
    {
        public IBus Bus { get; set; }
        public bool Success { get; set; }

        private readonly IOAuthUserService service;
        private readonly IFacebookClient facebookClient;

        private readonly IProvideUserConfiguration configuration;
        private readonly Func<RegisterExternalUserPreCommand> registerExternalUserPreCommandAccessor;
        private readonly Func<LinkExistingUserToExternalProviderPreCommand> linkExistingUserToExternalProviderPreCommandAccessor;

        public Uri Url { get; set; }
        public string Path { get; set; }
        public string Code { get; set; }

        private bool executed;

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ExternalIdentifier { get; set; }
        public string Roles { get; set; }
        public Guid Identifier { get; set; }
        public ExternalAuthenticationType ExternalProvider { get; set; }

        public FacebookLoginCommand(IOAuthUserService service, IProvideUserConfiguration configuration, Func<RegisterExternalUserPreCommand> registerExternalUserPreCommandAccessor, Func<LinkExistingUserToExternalProviderPreCommand> linkExistingUserToExternalProviderPreCommandAccessor, IFacebookClient facebookClient)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (configuration == null)
                throw new ArgumentNullException("configuration");

            this.service = service;
            this.configuration = configuration;
            this.registerExternalUserPreCommandAccessor = registerExternalUserPreCommandAccessor;
            this.linkExistingUserToExternalProviderPreCommandAccessor = linkExistingUserToExternalProviderPreCommandAccessor;
            this.facebookClient = facebookClient;
        }

        public void Execute()
        {
            if (facebookClient.HasLoginBeenSuccessful(Url.ToString()))
            {
                IFacebookUserProfile profile = facebookClient.GetUserFromCode(Code);

                OAuthUser user = service.GetByEmail(profile.Email, configuration.ApplicationName);

                if (user == null)
                {
                    var registerCommand = registerExternalUserPreCommandAccessor();

                    registerCommand.Identifier = Identifier = Guid.NewGuid();
                    registerCommand.Username = Username = profile.Username;
                    registerCommand.Email = Email = profile.Email;
                    registerCommand.ExternalIdentifier = ExternalIdentifier = profile.Identifier;
                    registerCommand.ExternalProvider = ExternalProvider = ExternalAuthenticationType.Facebook;
                    registerCommand.Token = profile.Token;

                    registerCommand.Execute();
                }
                else if (!user.HasLinkedExternalProvider(ExternalAuthenticationType.Facebook))
                {
                    var linkCommand = linkExistingUserToExternalProviderPreCommandAccessor();

                    linkCommand.Identifier = Identifier = user.Id;
                    linkCommand.Username = Username = profile.Username;
                    linkCommand.Email = Email = profile.Email;
                    linkCommand.ExternalIdentifier = ExternalIdentifier = profile.Identifier;
                    linkCommand.ExternalProvider = ExternalProvider = ExternalAuthenticationType.Facebook;
                    linkCommand.Token = profile.Token;

                    Roles = user.RolesAsString;

                    linkCommand.Execute();
                }
                else
                {
                    Identifier = user.Id;
                    Username = user.Username;
                    Email = profile.Email;
                    ExternalIdentifier = profile.Identifier;
                    ExternalProvider = ExternalAuthenticationType.Facebook;
                    Roles = user.RolesAsString;
                }

                Bus.Send<ILoggedUserInUsingOAuthProviderCommandMessage>(x =>
                {
                    x.UserId = Identifier;
                    x.Username = Username;
                    x.ApplicationName = configuration.ApplicationName;
                    x.LoginDate = DateTime.Now;
                });

                Success = true;
            }

            executed = true;
        }

        public bool HasExecuted { get { return executed; } }
    }
}
