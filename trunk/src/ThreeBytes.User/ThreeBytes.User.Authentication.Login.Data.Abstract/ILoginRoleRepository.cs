using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Data.Abstract
{
    public interface ILoginRoleRepository : IKeyedGenericRepository<LoginRole>
    {
        bool Exists(string name, string applicationName);
    }
}
