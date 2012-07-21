using System;
using System.Collections.Generic;
using ThreeBytes.Caching.Core.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Entities.Concrete
{
    [Serializable]
    public class PagedCacheItem : IPagedCacheItem
    {
        private readonly IDictionary<int, ICollectionCacheItem> value;

        public PagedCacheItem()
        {
            value = new Dictionary<int, ICollectionCacheItem>();
        }

        public IDictionary<int, ICollectionCacheItem> Value
        {
            get { return value; }
        }

        public void Add(int page, ICollectionCacheItem item)
        {
            if (value.ContainsKey(page))
                value[page] = item;
            else
                value.Add(page, item);
        }
    }
}