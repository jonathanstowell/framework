using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Profile.Management.Entities;

namespace ThreeBytes.User.Profile.Management.Data.Abstract
{
    public interface IProfileManagementProfileRepository : IKeyedGenericRepository<UserProfileManagementProfile>
    {
        bool UniqueEmail(string email, string applicationName);
    }
}
