using System.Configuration;

namespace ThreeBytes.User.Authentication.Login.Configuration.Concrete
{
    public class LoginConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty lockUserOutAfterNAttempts = new ConfigurationProperty("barUserAfterNAttempts", typeof(int), 5);

        public LoginConfigurationSection()
        {
            base.Properties.Add(lockUserOutAfterNAttempts);
        }

        [ConfigurationProperty("barUserAfterNAttempts", DefaultValue = 5, IsKey = false, IsRequired = false)]
        public int LockUserOutAfterNAttempts
        {
            get { return (int)this[lockUserOutAfterNAttempts]; }
        }
    }
}
