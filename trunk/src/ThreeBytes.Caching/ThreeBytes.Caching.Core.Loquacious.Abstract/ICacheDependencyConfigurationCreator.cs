using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Loquacious.Abstract
{
    public interface ICacheDependencyConfigurationCreator
    {
        void Alias(string alias);
        ICacheDependencyConfiguration Configuration { get; }
    }
}
