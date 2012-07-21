using ThreeBytes.ProjectHollywood.Configuration.Abstract.Paging;

namespace ThreeBytes.ProjectHollywood.Configuration.Concrete.Paging
{
    public class ProvidePagingSettings : IProvidePagingSettings
    {
        private readonly PagingConfigurationSection _pagingConfiguration;

        public ProvidePagingSettings()
        {
            _pagingConfiguration = PagingConfigurationManager.GetInstance();
        }

        public int GetPageSizeFor(string entity)
        {
            return int.Parse(_pagingConfiguration.Paging[entity].PageSize);
        }
    }
}
