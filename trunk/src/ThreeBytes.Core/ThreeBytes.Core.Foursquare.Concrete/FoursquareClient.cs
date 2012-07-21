using System.Collections.Generic;
using Igloo.SharpSquare.Core;
using ThreeBytes.Core.Extensions.Dictionary;
using ThreeBytes.Core.Extensions.SharpSquare;
using ThreeBytes.Core.Foursquare.Abstract;
using ThreeBytes.Core.Foursquare.Configuration.Abstract;
using ThreeBytes.Core.Foursquare.Entities.Abstract;
using ThreeBytes.Core.Foursquare.Entities.Concrete;

namespace ThreeBytes.Core.Foursquare.Concrete
{
    public class FoursquareClient : IFoursquareClient
    {
        private readonly SharpSquare client;
        private readonly IProvideFoursquareConfiguration configuration;

        public FoursquareClient(IProvideFoursquareConfiguration configuration)
        {
            this.configuration = configuration;
            client = new SharpSquare(configuration.ClientId, configuration.ClientSecret);
        }

        public string GetLoginUrl(string redirect)
        {
            return GetLoginUrl(redirect, null);
        }

        public string GetLoginUrl(string redirect, IDictionary<string, object> parameters)
        {
            if (parameters != null)
                return client.GetAuthenticateUrl(redirect) + parameters.ToQueryString();
                
            return client.GetAuthenticateUrl(redirect);
        }

        public IFoursquareUserProfile GetUserFromCode(string code, string redirect)
        {
            string tokenResult = client.GetAccessToken(redirect, code);

            dynamic me = client.GetUserUsingToken(tokenResult);

            FoursquareUserProfile profile = new FoursquareUserProfile();

            profile.Identifier = (string)me.id;
            profile.FacebookIdentifier = (string)me.contact.facebook;
            profile.Username = (string)me.contact.email;
            profile.Forename = (string)me.firstName;
            profile.Surname = (string)me.lastName;
            profile.Email = (string)me.contact.email;
            profile.Token = tokenResult;

            return profile;
        }
    }
}
