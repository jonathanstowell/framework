using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;
using ThreeBytes.Email.Template.View.Entities.Enums;

namespace ThreeBytes.Email.Template.View.Entities
{
    [Serializable]
    public class EmailTemplateViewTemplate : HistoricBusinessObject<EmailTemplateViewTemplate>, IHistoricBusinessObject<EmailTemplateViewTemplate>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string From { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
        public virtual bool IsHtml { get; set; }
        public virtual Encoding Encoding { get; set; }

        public EmailTemplateViewTemplate(){}

        public EmailTemplateViewTemplate(EmailTemplateViewTemplate template)
        {
            Name = template.Name;
            ApplicationName = template.ApplicationName;
            ItemId = template.ItemId;
            From = template.From;
            Subject = template.Subject;
            Body = template.Body;
            IsHtml = template.IsHtml;
            Encoding = template.Encoding;
        }
    }
}
