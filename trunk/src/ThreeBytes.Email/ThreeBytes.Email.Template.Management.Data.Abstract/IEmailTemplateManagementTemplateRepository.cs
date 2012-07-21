using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Email.Template.Management.Entities;

namespace ThreeBytes.Email.Template.Management.Data.Abstract
{
    public interface IEmailTemplateManagementTemplateRepository : IKeyedGenericRepository<EmailTemplateManagementTemplate>
    {
        bool UniqueTemplate(string name, string applicationName);
    }
}
