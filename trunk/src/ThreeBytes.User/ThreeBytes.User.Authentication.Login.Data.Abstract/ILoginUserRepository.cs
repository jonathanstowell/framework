using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Data.Abstract
{
    public interface ILoginUserRepository : IKeyedGenericRepository<LoginUser>
    {
        LoginUser GetBy(string username, string applicationName);
        LoginUser GetBy(string username, string password, string applicationName);
        LoginUser GetByUsernameOrEmail(string userIdentifier, string applicationName);
        bool HasRecords(string applicationName);
        bool UniqueUsername(string username, string applicationName);
        bool UniqueEmail(string email, string applicationName);
        bool PasswordMatches(string username, string password, string applicationName);
    }
}
