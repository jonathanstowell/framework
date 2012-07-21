using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Profile.Management.Entities;

namespace ThreeBytes.User.Profile.Management.Service.Abstract
{
    public interface IProfileManagementProfileService : IKeyedGenericService<UserProfileManagementProfile>
    {
        bool UniqueEmail(string email, string applicationName);
    }
}
