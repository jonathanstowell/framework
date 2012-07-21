using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Service.Abstract
{
    public interface IAuthenticationUserManagementUserService : IKeyedGenericService<AuthenticationUserManagementUser>
    {
        bool UniqueUsername(string username, string applicationName);
        bool UniqueEmail(string email, string applicationName);
        AuthenticationUserManagementUser GetByUsernameOrEmail(string userIdentifier, string applicationName);
    }
}
