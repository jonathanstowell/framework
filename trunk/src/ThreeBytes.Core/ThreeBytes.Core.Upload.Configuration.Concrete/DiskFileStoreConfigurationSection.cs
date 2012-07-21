using System.Configuration;

namespace ThreeBytes.Core.Upload.Configuration.Concrete
{
    public class DiskFileStoreConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty directory =
            new ConfigurationProperty("directory", typeof(string), "img/uploads", ConfigurationPropertyOptions.IsRequired);

        private static readonly ConfigurationProperty tempDirectory =
            new ConfigurationProperty("tempDirectory", typeof(string), "img/uploads/temp", ConfigurationPropertyOptions.IsRequired);

        public DiskFileStoreConfigurationSection()
        {
            base.Properties.Add(directory);
            base.Properties.Add(tempDirectory);
        }

        [ConfigurationProperty("directory", IsRequired = true)]
        public string Directory
        {
            get { return (string)this[directory]; }
        }

        [ConfigurationProperty("tempDirectory", IsRequired = true)]
        public string TemporaryDirectory
        {
            get { return (string)this[tempDirectory]; }
        }
    }
}
