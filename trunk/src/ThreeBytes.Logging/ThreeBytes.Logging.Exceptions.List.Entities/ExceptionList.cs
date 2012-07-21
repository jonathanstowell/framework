using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Logging.Exceptions.List.Entities
{
    [Serializable]
    public class ExceptionList : BusinessObject<ExceptionList>, IBusinessObject<ExceptionList>
    {
        public virtual string Message { get; set; }
        public virtual string Source { get; set; }
    }
}
