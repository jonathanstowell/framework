using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.Email.Dispatch.View.Entities.Enums;

namespace ThreeBytes.Email.Dispatch.View.Entities
{
    [Serializable]
    public class EmailDispatchViewEmailMessage : BusinessObject<EmailDispatchViewEmailMessage>, IBusinessObject<EmailDispatchViewEmailMessage>
    {
        public virtual string ApplicationName { get; set; }
        public virtual string From { get; set; }
        public virtual string To { get; set; }
        public virtual string CC { get; set; }
        public virtual string BCC { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
        public virtual bool IsHtml { get; set; }
        public virtual Encoding Encoding { get; set; }
    }
}
