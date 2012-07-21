using System.Configuration;
using ThreeBytes.User.Authentication.Login.Configuration.Abstract;

namespace ThreeBytes.User.Authentication.Login.Configuration.Concrete
{
    public class ProvideLoginConfiguration : IProvideLoginConfiguration
    {
        private readonly LoginConfigurationSection configManager;

        public ProvideLoginConfiguration()
        {
            configManager = (LoginConfigurationSection)ConfigurationManager.GetSection("threeBytesLogin");
        }

        public int LockUserOutAfterNAttempts
        {
            get { return configManager.LockUserOutAfterNAttempts; }
        }
    }
}
