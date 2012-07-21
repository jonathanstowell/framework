using System;
using System.Collections.Generic;
using ThreeBytes.Caching.Core.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Entities.Concrete
{
    [Serializable]
    public class PagedOrderedContainerCacheItem : IPagedOrderedContainerCacheItem
    {
        private readonly IDictionary<string, IPagedCacheItem> value;

        public PagedOrderedContainerCacheItem()
        {
            value = new Dictionary<string, IPagedCacheItem>();
        }

        public IDictionary<string, IPagedCacheItem> Value
        {
            get { return value; }
        }

        public void Add(string key, IPagedCacheItem item)
        {
            if (value.ContainsKey(key))
                value[key] = item;
            else
                value.Add(key, item);
        }
    }
}
