using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Authentication.Registration.Entities;

namespace ThreeBytes.User.Authentication.Registration.Service.Abstract
{
    public interface IExternalUserService : IKeyedGenericService<ExternalUser>
    {
        bool UserExistsByEmail(string email, string applicationName);
        ExternalUser GetUserByEmail(string email, string applicationName);
        bool HasRecords(string applicationName);
        bool UniqueUsername(string username, string applicationName);
    }
}
