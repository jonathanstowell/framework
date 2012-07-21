using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Email.Template.View.Entities;

namespace ThreeBytes.Email.Template.View.Data.Abstract
{
    public interface IEmailTemplateViewTemplateRepository : IHistoricKeyedGenericRepository<EmailTemplateViewTemplate>
    {
        bool UniqueTemplate(string name, string applicationName);
    }
}
