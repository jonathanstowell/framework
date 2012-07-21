using System.Collections.Generic;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Email.Template.Widget.Entities;

namespace ThreeBytes.Email.Template.Widget.Data.Abstract
{
    public interface IEmailTemplateWidgetTemplateRepository : IKeyedGenericRepository<EmailTemplateWidgetTemplate>
    {
        IList<EmailTemplateWidgetTemplate> GetMostRecent(int take, string applicationName);
        bool UniqueTemplate(string name, string applicationName);
    }
}
