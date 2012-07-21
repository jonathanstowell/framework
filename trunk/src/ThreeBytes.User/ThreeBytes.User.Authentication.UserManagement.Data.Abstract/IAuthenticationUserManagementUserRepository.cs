using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Data.Abstract
{
    public interface IAuthenticationUserManagementUserRepository : IKeyedGenericRepository<AuthenticationUserManagementUser>
    {
        AuthenticationUserManagementUser GetByUsernameOrEmail(string userIdentifier, string applicationName);
        bool UniqueUsername(string username, string applicationName);
        bool UniqueEmail(string email, string applicationName);
    }
}
