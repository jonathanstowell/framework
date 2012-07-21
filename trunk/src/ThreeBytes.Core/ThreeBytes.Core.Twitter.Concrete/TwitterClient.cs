using System;
using System.Collections.Generic;
using System.Globalization;
using ThreeBytes.Core.Extensions.Dictionary;
using ThreeBytes.Core.Twitter.Abstract;
using ThreeBytes.Core.Twitter.Configuration.Abstract;
using ThreeBytes.Core.Twitter.Entities.Abstract;
using ThreeBytes.Core.Twitter.Entities.Concrete;
using TweetSharp;

namespace ThreeBytes.Core.Twitter.Concrete
{
    public class TwitterClient : ITwitterClient
    {
        private readonly IProvideTwitterConfiguration configuration;
        private readonly TwitterService client;

        public TwitterClient(IProvideTwitterConfiguration configuration)
        {
            this.configuration = configuration;
            client = new TwitterService(configuration.ConsumerKey, configuration.ConsumerSecret);
        }

        public string GetLoginUrl(string redirect)
        {
            return GetLoginUrl(redirect, null);
        }

        public string GetLoginUrl(string redirect, IDictionary<string, object> parameters)
        {
            if (parameters != null)
                return client.GetAuthorizationUri(client.GetRequestToken(redirect + parameters.ToQueryString())).ToString();
                
            return client.GetAuthorizationUri(client.GetRequestToken(redirect)).ToString();
        }

        public ITwitterUserProfile GetUser(string oauthToken, string oauthVerifier)
        {
            OAuthRequestToken requestToken = new OAuthRequestToken { Token = oauthToken };
            OAuthAccessToken accessToken = client.GetAccessToken(requestToken, oauthVerifier);

            client.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);

            TwitterUser user = client.VerifyCredentials();

            TwitterUserProfile profile = new TwitterUserProfile();

            profile.Identifier = user.Id.ToString(CultureInfo.InvariantCulture);
            profile.Username = user.ScreenName;
            profile.Token = accessToken.Token;
            profile.Token = accessToken.TokenSecret;

            return profile;
        }

        public bool HasLoginBeenSuccessful(string url)
        {
            throw new NotImplementedException();
        }
    }
}
