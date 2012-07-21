using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Email.Template.View.Entities;

namespace ThreeBytes.Email.Template.View.Service.Abstract
{
    public interface IEmailTemplateViewTemplateService : IHistoricKeyedGenericService<EmailTemplateViewTemplate>
    {
        bool UniqueTemplate(string name, string applicationName);
    }
}
