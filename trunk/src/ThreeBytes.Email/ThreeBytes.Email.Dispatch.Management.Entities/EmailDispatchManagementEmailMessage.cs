using ThreeBytes.Core.Email.Abstract;
using ThreeBytes.Email.Dispatch.Management.Entities.Enums;

namespace ThreeBytes.Email.Dispatch.Management.Entities
{
    public class EmailDispatchManagementEmailMessage : IEmailMessage
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
