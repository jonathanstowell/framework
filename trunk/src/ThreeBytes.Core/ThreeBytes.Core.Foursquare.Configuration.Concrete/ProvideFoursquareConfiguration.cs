using System.Configuration;
using ThreeBytes.Core.Foursquare.Configuration.Abstract;

namespace ThreeBytes.Core.Foursquare.Configuration.Concrete
{
    public class ProvideFoursquareConfiguration : IProvideFoursquareConfiguration
    {
        private readonly FoursquareConfigurationSection configManager;

        public ProvideFoursquareConfiguration()
        {
            configManager = (FoursquareConfigurationSection)ConfigurationManager.GetSection("foursquareSettings");
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
