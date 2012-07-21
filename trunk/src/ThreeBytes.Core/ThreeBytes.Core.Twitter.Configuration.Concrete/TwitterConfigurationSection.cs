using System.Configuration;

namespace ThreeBytes.Core.Twitter.Configuration.Concrete
{
    public class TwitterConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty consumerKey = new ConfigurationProperty("consumerKey", typeof(string));
        private static readonly ConfigurationProperty consumerSecret = new ConfigurationProperty("consumerSecret", typeof(string));

        public TwitterConfigurationSection()
        {
            base.Properties.Add(consumerKey);
            base.Properties.Add(consumerSecret);
        }

        [ConfigurationProperty("consumerKey", IsKey = false, IsRequired = true)]
        public string ConsumerKey
        {
            get { return (string)this[consumerKey]; }
        }

        [ConfigurationProperty("consumerSecret", IsKey = false, IsRequired = true)]
        public string ConsumerSecret
        {
            get { return (string)this[consumerSecret]; }
        }
    }
}
