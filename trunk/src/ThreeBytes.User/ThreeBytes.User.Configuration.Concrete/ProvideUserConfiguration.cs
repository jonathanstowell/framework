using System.Configuration;
using ThreeBytes.User.Configuration.Abstract;

namespace ThreeBytes.User.Configuration.Concrete
{
    public class ProvideUserConfiguration : IProvideUserConfiguration
    {
        private readonly UserConfigurationSection configManager;

        public ProvideUserConfiguration()
        {
            configManager = (UserConfigurationSection) ConfigurationManager.GetSection("threeBytesUser");
        }

        public string ApplicationName
        {
            get { return configManager.ApplicationName; }
        }

        public string RedirectController
        {
            get { return configManager.Controller; }
        }

        public string RedirectAction
        {
            get { return configManager.Action; }
        }

        public int MinimumPasswordLength
        {
            get { return configManager.MinimumPasswordLength; }
        }

        public int MaximumPasswordLength
        {
            get { return configManager.MaximumPasswordLength; }
        }

        public int MinimumUsernameLength
        {
            get { return configManager.MinimumUsernameLength; }
        }

        public int MaximumUsernameLength
        {
            get { return configManager.MaximumUsernameLength; }
        }
    }
}
