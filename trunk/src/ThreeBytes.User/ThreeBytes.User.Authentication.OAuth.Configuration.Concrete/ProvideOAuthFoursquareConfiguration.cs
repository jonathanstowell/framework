using System.Configuration;
using ThreeBytes.User.Authentication.OAuth.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.OAuth.Configuration.Concrete
{
    public class ProvideOAuthFoursquareConfiguration : IProvideOAuthFoursquareConfiguration
    {
        private readonly FoursquareConfigurationSection configManager;

        public ProvideOAuthFoursquareConfiguration()
        {
            configManager = (FoursquareConfigurationSection)ConfigurationManager.GetSection("oAuthFoursquareSettings");
        }

        public string ClientId
        {
            get { return configManager.ClientId; }
        }

        public string ClientSecret
        {
            get { return configManager.ClientSecret; }
        }
    }
}
