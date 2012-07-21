using System.Configuration;

namespace ThreeBytes.User.Configuration.Concrete
{
    public class UserConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty applicationName = new ConfigurationProperty("applicationName", typeof(string), null);
        private static readonly ConfigurationProperty controller = new ConfigurationProperty("controller", typeof(string), "Home");
        private static readonly ConfigurationProperty action = new ConfigurationProperty("action", typeof(string), "Index");
        private static readonly ConfigurationProperty minimumPasswordLength = new ConfigurationProperty("minimumPasswordLength", typeof(int), 6);
        private static readonly ConfigurationProperty maximumPasswordLength = new ConfigurationProperty("maximumPasswordLength", typeof(int), 30);
        private static readonly ConfigurationProperty minimumUsernameLength = new ConfigurationProperty("minimumUsernameLength", typeof(int), 6);
        private static readonly ConfigurationProperty maximumUsernameLength = new ConfigurationProperty("maximumUsernameLength", typeof(int), 30);

        public UserConfigurationSection()
        {
            base.Properties.Add(applicationName);
            base.Properties.Add(controller);
            base.Properties.Add(action);
            base.Properties.Add(minimumPasswordLength);
            base.Properties.Add(maximumPasswordLength);
            base.Properties.Add(minimumUsernameLength);
            base.Properties.Add(maximumUsernameLength);
        }

        [ConfigurationProperty("applicationName", DefaultValue = "threeBytes", IsKey = false, IsRequired = false)]
        public string ApplicationName
        {
            get { return (string)this[applicationName]; }
        }

        [ConfigurationProperty("controller", DefaultValue = "Home", IsKey = false, IsRequired = false)]
        public string Controller
        {
            get { return (string)this[controller]; }
        }

        [ConfigurationProperty("action", DefaultValue = "Index", IsKey = false, IsRequired = false)]
        public string Action
        {
            get { return (string)this[action]; }
        }

        [ConfigurationProperty("minimumPasswordLength", DefaultValue = 6, IsKey = false, IsRequired = false)]
        public int MinimumPasswordLength
        {
            get { return (int)this[minimumPasswordLength]; }
        }

        [ConfigurationProperty("maximumPasswordLength", DefaultValue = 30, IsKey = false, IsRequired = false)]
        public int MaximumPasswordLength
        {
            get { return (int)this[maximumPasswordLength]; }
        }

        [ConfigurationProperty("minimumUsernameLength", DefaultValue = 6, IsKey = false, IsRequired = false)]
        public int MinimumUsernameLength
        {
            get { return (int)this[minimumUsernameLength]; }
        }

        [ConfigurationProperty("maximumUsernameLength", DefaultValue = 30, IsKey = false, IsRequired = false)]
        public int MaximumUsernameLength
        {
            get { return (int)this[maximumUsernameLength]; }
        }
    }
}
