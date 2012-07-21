using System;

namespace ThreeBytes.Core.Caching.Abstract
{
    public interface ICacheKeyGenerator
    {
        string BusinessObjectCacheKey<T>(object identifier);
        string BusinessObjectCacheKey(Type type, object identifier);
        string BusinessObjectCacheKeyViaAlias(string alias, object identifier);
        string CollectionPrimaryCacheKey<T>();
        string CollectionPrimaryCacheKey(Type type);
        string CollectionPrimaryCacheKeyViaAlias(string alias);
        string CollectionSecondaryCacheKey(string order, string sortedBy);
        string PagedPrimaryCacheKey<T>();
        string PagedPrimaryCacheKey(Type type);
        string PagedPrimaryCacheKeyViaAlias(string alias);
        string PagedSecondaryCacheKey(DateTime? dateTime);
        string PagedTertiaryCacheKey(string orderedBy, string sortedBy);
        string MostRecentPrimaryCacheKey<T>();
        string MostRecentPrimaryCacheKey(Type type);
        string MostRecentPrimaryCacheKeyViaAlias(string alias);
        string MostRecentSecondaryCacheKey(DateTime dateTime);
        string CurrentlyViewingUsersCacheKey(object id, Type typeFor);
    }
}
