using System.Configuration;
using ThreeBytes.Core.Twitter.Configuration.Abstract;

namespace ThreeBytes.Core.Twitter.Configuration.Concrete
{
    public class ProvideTwitterConfiguration : IProvideTwitterConfiguration
    {
        private readonly TwitterConfigurationSection configManager;

        public ProvideTwitterConfiguration()
        {
            configManager = (TwitterConfigurationSection)ConfigurationManager.GetSection("twitterSettings");
        }

        public string ConsumerKey
        {
            get { return configManager.ConsumerKey; }
        }

        public string ConsumerSecret
        {
            get { return configManager.ConsumerSecret; }
        }
    }
}
