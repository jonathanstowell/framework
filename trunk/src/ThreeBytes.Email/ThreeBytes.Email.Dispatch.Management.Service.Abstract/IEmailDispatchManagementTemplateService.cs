using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Email.Dispatch.Management.Entities;

namespace ThreeBytes.Email.Dispatch.Management.Service.Abstract
{
    public interface IEmailDispatchManagementTemplateService : IKeyedGenericService<EmailDispatchManagementTemplate>
    {
        EmailDispatchManagementTemplate GetBy(string name, string applicationName);
        bool UniqueTemplate(string name, string applicationName);
    }
}
