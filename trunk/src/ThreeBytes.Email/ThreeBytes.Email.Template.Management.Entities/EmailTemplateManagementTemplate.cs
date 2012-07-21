using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.Email.Template.Management.Entities.Enums;

namespace ThreeBytes.Email.Template.Management.Entities
{
    [Serializable]
    public class EmailTemplateManagementTemplate : BusinessObject<EmailTemplateManagementTemplate>, IBusinessObject<EmailTemplateManagementTemplate>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string From { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
        public virtual bool IsHtml { get; set; }
        public virtual Encoding Encoding { get; set; }
    }
}
