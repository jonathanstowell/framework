using System.Configuration;
using ThreeBytes.Core.Facebook.Configuration.Abstract;

namespace ThreeBytes.Core.Facebook.Configuration.Concrete
{
    public class ProvideFacebookConfiguration : IProvideFacebookConfiguration
    {
        private readonly FacebookConfigurationSection configManager;

        public ProvideFacebookConfiguration()
        {
            configManager = (FacebookConfigurationSection)ConfigurationManager.GetSection("facebookSettings");
        }

        public string AppId
        {
            get { return configManager.AppId; }
        }

        public string AppSecret
        {
            get { return configManager.AppSecret; }
        }
    }
}
