using System.Configuration;

namespace ThreeBytes.Core.Email.Configuration.Concrete
{
    public class EmailConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty deliveryMethod = new ConfigurationProperty("deliveryMethod", typeof(string), "SpecifiedPickupDirectory");
        private static readonly ConfigurationProperty host = new ConfigurationProperty("host", typeof(string), "ignored");
        private static readonly ConfigurationProperty port = new ConfigurationProperty("port", typeof(int), 25);
        private static readonly ConfigurationProperty username = new ConfigurationProperty("username", typeof(string), "");
        private static readonly ConfigurationProperty password = new ConfigurationProperty("password", typeof(string), "");
        private static readonly ConfigurationProperty from = new ConfigurationProperty("from", typeof(string), "");
        private static readonly ConfigurationProperty pickupDirectoryLocation = new ConfigurationProperty("pickupDirectoryLocation", typeof(string), @"c:\email");
        private static readonly ConfigurationProperty enableSSL = new ConfigurationProperty("enableSSL", typeof(bool), false);

        public EmailConfigurationSection()
        {
            base.Properties.Add(deliveryMethod);
            base.Properties.Add(host);
            base.Properties.Add(port);
            base.Properties.Add(username);
            base.Properties.Add(password);
            base.Properties.Add(from);
            base.Properties.Add(pickupDirectoryLocation);
            base.Properties.Add(enableSSL);
        }

        [ConfigurationProperty("deliveryMethod", DefaultValue = "SpecifiedPickupDirectory", IsKey = false, IsRequired = false)]
        public string DeliveryMethod
        {
            get { return (string)this[deliveryMethod]; }
        }

        [ConfigurationProperty("host", DefaultValue = "ignored", IsKey = false, IsRequired = false)]
        public string Host
        {
            get { return (string)this[host]; }
        }

        [ConfigurationProperty("port", DefaultValue = 25, IsKey = false, IsRequired = false)]
        public int Port
        {
            get { return (int)this[port]; }
        }

        [ConfigurationProperty("username", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Username
        {
            get { return (string)this[username]; }
        }

        [ConfigurationProperty("password", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Password
        {
            get { return (string)this[password]; }
        }

        [ConfigurationProperty("from", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string From
        {
            get { return (string)this[from]; }
        }

        [ConfigurationProperty("pickupDirectoryLocation", DefaultValue = @"c:\email", IsKey = false, IsRequired = false)]
        public string PickupDirectoryLocation
        {
            get { return (string)this[pickupDirectoryLocation]; }
        }

        [ConfigurationProperty("enableSSL", DefaultValue = false, IsKey = false, IsRequired = false)]
        public bool EnableSSL
        {
            get { return (bool)this[enableSSL]; }
        }
    }
}
