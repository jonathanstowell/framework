using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Email.Dispatch.Management.Entities;

namespace ThreeBytes.Email.Dispatch.Management.Data.Abstract
{
    public interface IEmailDispatchManagementTemplateRepository : IKeyedGenericRepository<EmailDispatchManagementTemplate>
    {
        EmailDispatchManagementTemplate GetBy(string name, string applicationName);
        bool UniqueTemplate(string name, string applicationName);
    }
}
