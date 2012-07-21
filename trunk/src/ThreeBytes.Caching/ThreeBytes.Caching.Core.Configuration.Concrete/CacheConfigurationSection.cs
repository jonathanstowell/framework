using System.Configuration;

namespace ThreeBytes.Caching.Core.Configuration.Concrete
{
    public class CacheConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty enabled =
            new ConfigurationProperty("enabled", typeof(bool), false, ConfigurationPropertyOptions.IsRequired);

        public CacheConfigurationSection()
        {
            base.Properties.Add(enabled);
        }

        [ConfigurationProperty("enabled", IsRequired = true)]
        public bool Enabled
        {
            get { return (bool)this[enabled]; }
        }
    }
}
