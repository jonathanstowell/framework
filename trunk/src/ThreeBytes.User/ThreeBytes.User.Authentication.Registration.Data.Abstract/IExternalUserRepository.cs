using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Authentication.Registration.Entities;

namespace ThreeBytes.User.Authentication.Registration.Data.Abstract
{
    public interface IExternalUserRepository : IKeyedGenericRepository<ExternalUser>
    {
        bool UserExistsByEmail(string email, string applicationName);
        ExternalUser GetUserByEmail(string email, string applicationName);
        bool HasRecords(string applicationName);
        bool UniqueUsername(string username, string applicationName);
    }
}
