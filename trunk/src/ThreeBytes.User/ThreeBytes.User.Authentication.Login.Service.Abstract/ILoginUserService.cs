using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Service.Abstract
{
    public interface ILoginUserService : IKeyedGenericService<LoginUser>
    {
        bool PasswordMatches(string username, string password, string applicationName);
        LoginUser GetByUsernameOrEmail(string userIdentifier, string applicationName);
        bool HasRecords(string applicationName);
        bool UniqueUsername(string username, string applicationName);
        bool UniqueEmail(string email, string applicationName);
    }
}
