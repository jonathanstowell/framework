using System.Collections.Generic;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Email.Template.Widget.Entities;

namespace ThreeBytes.Email.Template.Widget.Service.Abstract
{
    public interface IEmailTemplateWidgetTemplateService : IKeyedGenericService<EmailTemplateWidgetTemplate>
    {
        IList<EmailTemplateWidgetTemplate> GetMostRecent(int take, string applicationName);
        bool UniqueTemplate(string name, string applicationName);
    }
}
