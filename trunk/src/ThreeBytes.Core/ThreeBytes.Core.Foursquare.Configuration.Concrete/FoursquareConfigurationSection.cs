using System.Configuration;

namespace ThreeBytes.Core.Foursquare.Configuration.Concrete
{
    public class FoursquareConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty clientId = new ConfigurationProperty("clientId", typeof(string));
        private static readonly ConfigurationProperty clientSecret = new ConfigurationProperty("clientSecret", typeof(string));

        public FoursquareConfigurationSection()
        {
            base.Properties.Add(clientId);
            base.Properties.Add(clientSecret);
        }

        [ConfigurationProperty("clientId", IsKey = false, IsRequired = true)]
        public string ClientId
        {
            get { return (string)this[clientId]; }
        }

        [ConfigurationProperty("clientSecret", IsKey = false, IsRequired = true)]
        public string ClientSecret
        {
            get { return (string)this[clientSecret]; }
        }
    }
}
