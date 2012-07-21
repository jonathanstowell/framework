using System.Configuration;

namespace ThreeBytes.Email.Configuration.Concrete
{
    public class EmailConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty applicationName = new ConfigurationProperty("applicationName", typeof(string), null);

        public EmailConfigurationSection()
        {
            base.Properties.Add(applicationName);
        }

        [ConfigurationProperty("applicationName", DefaultValue = "threeBytes", IsKey = false, IsRequired = false)]
        public string ApplicationName
        {
            get { return (string)this[applicationName]; }
        }
    }
}
