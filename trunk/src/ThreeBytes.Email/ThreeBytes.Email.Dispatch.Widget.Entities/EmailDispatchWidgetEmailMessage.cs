using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Email.Dispatch.Widget.Entities
{
    [Serializable]
    public class EmailDispatchWidgetEmailMessage : BusinessObject<EmailDispatchWidgetEmailMessage>, IBusinessObject<EmailDispatchWidgetEmailMessage>
    {
        public virtual string ApplicationName { get; set; }
        public virtual string To { get; set; }
        public virtual string Subject { get; set; }
    }
}
