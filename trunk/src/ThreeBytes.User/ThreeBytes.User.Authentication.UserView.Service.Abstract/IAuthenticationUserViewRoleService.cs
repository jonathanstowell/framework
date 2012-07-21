using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Authentication.UserView.Entities;

namespace ThreeBytes.User.Authentication.UserView.Service.Abstract
{
    public interface IAuthenticationUserViewRoleService : IKeyedGenericService<AuthenticationUserViewRole>
    {
        bool Exists(string name, string applicationName);
    }
}
