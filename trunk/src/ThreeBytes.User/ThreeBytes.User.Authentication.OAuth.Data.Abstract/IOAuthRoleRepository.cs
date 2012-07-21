using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Authentication.OAuth.Entities;

namespace ThreeBytes.User.Authentication.OAuth.Data.Abstract
{
    public interface IOAuthRoleRepository : IKeyedGenericRepository<OAuthRole>
    {
        bool Exists(string name, string applicationName);
    }
}
