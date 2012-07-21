using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.Email.Dispatch.List.Entities.Enums;

namespace ThreeBytes.Email.Dispatch.List.Entities
{
    [Serializable]
    public class EmailDispatchListEmailMessage : BusinessObject<EmailDispatchListEmailMessage>, IBusinessObject<EmailDispatchListEmailMessage>
    {
        public virtual string ApplicationName { get; set; }
        public virtual string From { get; set; }
        public virtual string To { get; set; }
        public virtual string CC { get; set; }
        public virtual string BCC { get; set; }
        public virtual string Subject { get; set; }
        public virtual bool IsHtml { get; set; }
        public virtual Encoding Encoding { get; set; }
    }
}
