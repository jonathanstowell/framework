using System.Configuration;
using ThreeBytes.Core.Upload.Configuration.Abstract;

namespace ThreeBytes.Core.Upload.Configuration.Concrete
{
    public class DiskFileStoreConfiguration : IDiskFileStoreConfiguration
    {
        private readonly DiskFileStoreConfigurationSection configurationSection;

        public DiskFileStoreConfiguration()
        {
            configurationSection = (DiskFileStoreConfigurationSection)ConfigurationManager.GetSection("threeBytesDiskFileStore"); ;
        }

        public string Directory
        {
            get { return configurationSection.Directory; }
        }

        public string TemporaryDirectory
        {
            get { return configurationSection.TemporaryDirectory; }
        }
    }
}
