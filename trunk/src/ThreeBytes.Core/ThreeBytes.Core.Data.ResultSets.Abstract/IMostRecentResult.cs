using System;
using System.Collections.Generic;

namespace ThreeBytes.Core.Data.ResultSets.Abstract
{
    public interface IMostRecentResult<T> where T : class
    {
        IList<T> Items { get; set; }
        DateTime OriginalRequestDateTime { get; set; }
        DateTime RequestDateTime { get; set; }
    }
}
