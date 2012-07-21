using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Email.Template.Management.Entities;

namespace ThreeBytes.Email.Template.Management.Service.Abstract
{
    public interface IEmailTemplateManagementTemplateService : IKeyedGenericService<EmailTemplateManagementTemplate>
    {
        bool UniqueTemplate(string name, string applicationName);
    }
}
