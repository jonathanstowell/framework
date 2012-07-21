using ThreeBytes.Core.Caching.Configuration.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Configuration.Entities.Conrete
{
    public class CacheDependencyConfiguration : ICacheDependencyConfiguration
    {
        public string Alias { get; set; }
    }
}
