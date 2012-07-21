namespace ThreeBytes.ProjectHollywood.Configuration.Abstract.Paging
{
    public interface IProvidePagingSettings
    {
        int GetPageSizeFor(string entity);
    }
}
