using System;
using System.Collections.Generic;
using ThreeBytes.Core.Data.ResultSets.Abstract;

namespace ThreeBytes.Core.Data.ResultSets.Concrete
{
    [Serializable]
    public class MostRecentResult<T> : IMostRecentResult<T> where T : class
    {
        public IList<T> Items { get; set; }
        public DateTime OriginalRequestDateTime { get; set; }
        public DateTime RequestDateTime { get; set; }

        public MostRecentResult()
        {
            Items = new List<T>();
        }

        public MostRecentResult(IList<T> items, DateTime originalDateTime, DateTime requestDateTime)
            : this()
        {
            Items = items;
            OriginalRequestDateTime = originalDateTime;
            RequestDateTime = requestDateTime;
        }
    }
}
