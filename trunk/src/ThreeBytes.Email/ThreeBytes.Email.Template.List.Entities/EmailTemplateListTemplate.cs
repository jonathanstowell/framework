using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.Email.Template.List.Entities.Enums;

namespace ThreeBytes.Email.Template.List.Entities
{
    [Serializable]
    public class EmailTemplateListTemplate : BusinessObject<EmailTemplateListTemplate>, IBusinessObject<EmailTemplateListTemplate>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string From { get; set; }
        public virtual string Subject { get; set; }
        public virtual bool IsHtml { get; set; }
        public virtual Encoding Encoding { get; set; }
    }
}
