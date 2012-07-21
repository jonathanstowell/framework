using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Logging.Exceptions.View.Entities
{
    [Serializable]
    public class ExceptionView : BusinessObject<ExceptionView>, IBusinessObject<ExceptionView>
    {
        public virtual string Message { get; set; }
        public virtual string Source { get; set; }
        public virtual string StackTrace { get; set; }
        public virtual string InnerException { get; set; }
    }
}
