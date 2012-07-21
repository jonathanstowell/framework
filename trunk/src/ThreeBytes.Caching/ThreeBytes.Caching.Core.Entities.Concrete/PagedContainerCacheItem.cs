using System;
using System.Collections.Generic;
using ThreeBytes.Caching.Core.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Entities.Concrete
{
    [Serializable]
    public class PagedContainerCacheItem : IPagedContainerCacheItem
    {
        private readonly IDictionary<string, IPagedOrderedContainerCacheItem> value;

        public PagedContainerCacheItem()
        {
            value = new Dictionary<string, IPagedOrderedContainerCacheItem>();
        }

        public IDictionary<string, IPagedOrderedContainerCacheItem> Value
        {
            get { return value; }
        }

        public void Add(string key, IPagedOrderedContainerCacheItem item)
        {
            if (value.ContainsKey(key))
                value[key] = item;
            else
                value.Add(key, item);
        }
    }
}
