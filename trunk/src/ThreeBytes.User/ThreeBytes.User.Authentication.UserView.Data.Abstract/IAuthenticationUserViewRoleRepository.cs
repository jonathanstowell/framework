using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Authentication.UserView.Entities;

namespace ThreeBytes.User.Authentication.UserView.Data.Abstract
{
    public interface IAuthenticationUserViewRoleRepository : IKeyedGenericRepository<AuthenticationUserViewRole>
    {
        bool Exists(string name, string applicationName);
    }
}
