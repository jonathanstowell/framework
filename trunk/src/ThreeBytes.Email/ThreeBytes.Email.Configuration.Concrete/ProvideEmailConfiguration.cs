using System.Configuration;
using ThreeBytes.Email.Configuration.Abstract;

namespace ThreeBytes.Email.Configuration.Concrete
{
    public class ProvideEmailConfiguration : IProvideEmailConfiguration
    {
        private readonly EmailConfigurationSection configManager;

        public ProvideEmailConfiguration()
        {
            configManager = (EmailConfigurationSection)ConfigurationManager.GetSection("threeBytesEmail");
        }

        public string ApplicationName
        {
            get { return configManager.ApplicationName; }
        }
    }
}
