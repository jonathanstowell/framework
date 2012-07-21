using System;
using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Email.Template.Widget.Entities
{
    [Serializable]
    public class EmailTemplateWidgetTemplate : BusinessObject<EmailTemplateWidgetTemplate>, IBusinessObject<EmailTemplateWidgetTemplate>
    {
        public virtual string Name { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual string Subject { get; set; }
    }
}
