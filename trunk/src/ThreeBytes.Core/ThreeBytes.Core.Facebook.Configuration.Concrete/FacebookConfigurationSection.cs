using System.Configuration;

namespace ThreeBytes.Core.Facebook.Configuration.Concrete
{
    public class FacebookConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty appId = new ConfigurationProperty("appId", typeof(string));
        private static readonly ConfigurationProperty appSecret = new ConfigurationProperty("appSecret", typeof(string));

        public FacebookConfigurationSection()
        {
            base.Properties.Add(appId);
            base.Properties.Add(appSecret);
        }

        [ConfigurationProperty("appId", IsKey = false, IsRequired = true)]
        public string AppId
        {
            get { return (string)this[appId]; }
        }

        [ConfigurationProperty("appSecret", IsKey = false, IsRequired = true)]
        public string AppSecret
        {
            get { return (string)this[appSecret]; }
        }
    }
}
