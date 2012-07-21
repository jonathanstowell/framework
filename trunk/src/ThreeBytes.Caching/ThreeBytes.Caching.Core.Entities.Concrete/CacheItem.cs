using System;
using ThreeBytes.Caching.Core.Entities.Abstract;

namespace ThreeBytes.Caching.Core.Entities.Concrete
{
    [Serializable]
    public class CacheItem : ICacheItem
    {
        private readonly DateTime timestamp;
        private readonly object value;
        private readonly object version;

        public CacheItem(object value)
        {
            this.value = value;
            timestamp = DateTime.Now;
            this.version = version;
        }


        public DateTime Timestamp
        {
            get { return timestamp; }
        }

        public object Value
        {
            get { return value; }
        }

        public object Version
        {
            get { return version; }
        }
    }
}
