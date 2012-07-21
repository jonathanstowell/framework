using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Service.Abstract
{
    public interface ILoginRoleService : IKeyedGenericService<LoginRole>
    {
        bool Exists(string name, string applicationName);
    }
}
