using ThreeBytes.Caching.Core.Configuration.Entities.Conrete;
using ThreeBytes.Caching.Core.Loquacious.Abstract;
using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Loquacious.Concrete
{
    public class CacheDependencyConfigurationCreator : ICacheDependencyConfigurationCreator
    {
        private readonly ICacheDependencyConfiguration configuration;

        public CacheDependencyConfigurationCreator()
        {
            configuration = new CacheDependencyConfiguration();
        }

        public void Alias(string alias)
        {
            configuration.Alias = alias;
        }

        public ICacheDependencyConfiguration Configuration { get { return configuration; } }
    }
}
