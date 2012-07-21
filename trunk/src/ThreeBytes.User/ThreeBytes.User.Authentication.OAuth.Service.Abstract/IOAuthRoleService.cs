using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Authentication.OAuth.Entities;

namespace ThreeBytes.User.Authentication.OAuth.Service.Abstract
{
    public interface IOAuthRoleService : IKeyedGenericService<OAuthRole>
    {
        bool Exists(string name, string applicationName);
    }
}
