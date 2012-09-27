using System;
using NServiceBus;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Core.Security.Utilities.Abstract;
using ThreeBytes.Core.Twitter.Abstract;
using ThreeBytes.Core.Twitter.Entities.Abstract;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Entities.Enums;
using ThreeBytes.User.Authentication.OAuth.Frontend.PreCommands;
using ThreeBytes.User.Authentication.OAuth.Service.Abstract;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Frontend.Commands
{
    public class TwitterLoginCommand : IPreCommand
    {
        public IBus Bus { get; set; }
        public bool Success { get; set; }

        private readonly IOAuthUserService service;
        private readonly ITwitterClient twitterClient;
        private readonly IProvideCurrentUserDetails currentUserDetails;

        private readonly IProvideUserConfiguration configuration;
        private readonly Func<LinkExistingUserToExternalProviderPreCommand> linkExistingUserToExternalProviderPreCommandAccessor;

        public Uri Url { get; set; }
        public string Path { get; set; }
        public string OAuthToken { get; set; }
        public string OAuthVerifier { get; set; }

        private bool executed;

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ExternalIdentifier { get; set; }
        public string Roles { get; set; }
        public Guid Identifier { get; set; }
        public ExternalAuthenticationType ExternalProvider { get; set; }

        public TwitterLoginCommand(IOAuthUserService service, IProvideUserConfiguration configuration, Func<LinkExistingUserToExternalProviderPreCommand> linkExistingUserToExternalProviderPreCommandAccessor, ITwitterClient twitterClient, IProvideCurrentUserDetails currentUserDetails)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            if (configuration == null)
                throw new ArgumentNullException("configuration");

            this.service = service;
            this.configuration = configuration;
            this.linkExistingUserToExternalProviderPreCommandAccessor = linkExistingUserToExternalProviderPreCommandAccessor;
            this.twitterClient = twitterClient;
            this.currentUserDetails = currentUserDetails;
        }

        public void Execute()
        {
            ITwitterUserProfile profile = twitterClient.GetUser(OAuthToken, OAuthVerifier);

            OAuthUser user = service.GetById(currentUserDetails.UserId);

            if (user == null)
                return;

            if (!user.HasLinkedExternalProvider(ExternalAuthenticationType.Twitter))
            {
                var linkCommand = linkExistingUserToExternalProviderPreCommandAccessor();

                linkCommand.Identifier = Identifier = user.Id;
                linkCommand.Username = Username = profile.Username;
                linkCommand.Email = Email = "temporaryemail@email.com";
                linkCommand.ExternalIdentifier = ExternalIdentifier = profile.Identifier;
                linkCommand.ExternalProvider = ExternalProvider = ExternalAuthenticationType.Twitter;
                linkCommand.Token = profile.Token;
                linkCommand.TokenSecret = profile.TokenSecret;

                Roles = user.RolesAsString;

                linkCommand.Execute();
            }

            Success = true;
            executed = true;
        }

        public bool HasExecuted { get { return executed; } }
    }
}