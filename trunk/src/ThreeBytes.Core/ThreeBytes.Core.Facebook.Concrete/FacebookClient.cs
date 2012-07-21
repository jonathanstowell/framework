using System;
using System.Collections.Generic;
using Facebook;
using ThreeBytes.Core.Facebook.Configuration.Abstract;
using ThreeBytes.Core.Facebook.Entities.Abstract;
using ThreeBytes.Core.Facebook.Entities.Concrete;
using ExternalFacebook = Facebook;
using ThreeBytes.Core.Facebook.Abstract;

namespace ThreeBytes.Core.Facebook.Concrete
{
    public class FacebookClient : IFacebookClient
    {
        private readonly ExternalFacebook.FacebookOAuthClient client;
        private readonly IProvideFacebookConfiguration configuration;

        public FacebookClient(IProvideFacebookConfiguration configuration)
        {
            this.configuration = configuration;
            client = new ExternalFacebook.FacebookOAuthClient();
            client.AppId = configuration.AppId;
            client.AppSecret = configuration.AppSecret;
        }

        public string GetLoginUrl(string redirect)
        {
            return GetLoginUrl(redirect, null);
        }

        public string GetLoginUrl(string redirect, IDictionary<string, object> parameters)
        {
            client.RedirectUri = new Uri(redirect);

            if (parameters != null)
                return client.GetLoginUrl(parameters).ToString();
                
            return client.GetLoginUrl().ToString();
        }

        public IFacebookUserProfile GetUserFromCode(string code)
        {
            dynamic tokenResult = client.ExchangeCodeForAccessToken(code);
            string accessToken = tokenResult.access_token;

            if (tokenResult.ContainsKey("expires"))
            {
                ExternalFacebook.DateTimeConvertor.FromUnixTime(tokenResult.expires);
            }

            ExternalFacebook.FacebookClient fbClient = new ExternalFacebook.FacebookClient(accessToken);

            dynamic me = fbClient.Get("/me");

            FacebookUserProfile profile = new FacebookUserProfile();

            profile.Identifier = (string) me.id;
            profile.Username = (string) me.username;
            profile.Email = (string) me.email;
            profile.Token = accessToken;

            return profile;
        }

        public bool HasLoginBeenSuccessful(string url)
        {
             FacebookOAuthResult oauthResult;
             if (FacebookOAuthResult.TryParse(url, out oauthResult))
             {
                 if (oauthResult.IsSuccess)
                 {
                     return true;
                 }
             }

            return false;
        }
    }
}
