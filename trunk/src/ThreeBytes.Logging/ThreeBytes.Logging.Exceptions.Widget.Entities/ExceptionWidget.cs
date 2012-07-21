using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Logging.Exceptions.Widget.Entities
{
    [Serializable]
    public class ExceptionWidget : BusinessObject<ExceptionWidget>, IBusinessObject<ExceptionWidget>
    {
        public virtual string Message { get; set; }
        public virtual string Source { get; set; }
    }
}
