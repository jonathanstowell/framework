using ThreeBytes.ProjectHollywood.Configuration.Abstract;
using ThreeBytes.ProjectHollywood.Configuration.Abstract.Paging;

namespace ThreeBytes.ProjectHollywood.Configuration.Concrete
{
    public class ProjectHollywoodConfiguration : IProjectHollywoodConfiguration
    {
        private readonly IProvidePagingSettings _pagingSettings;

        public ProjectHollywoodConfiguration(IProvidePagingSettings pagingSettings)
        {
            _pagingSettings = pagingSettings;
        }

        public int GetPageSizeFor(string entity)
        {
            return _pagingSettings.GetPageSizeFor(entity);
        }
    }
}
