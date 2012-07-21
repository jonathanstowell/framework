using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Authentication.Registration.Entities;

namespace ThreeBytes.User.Authentication.Registration.Data.Abstract
{
    public interface IRegistrationUserRepository : IKeyedGenericRepository<RegistrationUser>
    {
        RegistrationUser GetByUsername(string username, string applicationName);
        RegistrationUser GetByUsernameOrEmail(string userIdentifier, string applicationName);
        bool HasRecords(string applicationName);
        bool UniqueUsername(string username, string applicationName);
        bool UniqueEmail(string email, string applicationName);
        bool VerifyCodeMatches(Guid id, Guid verifiedCode);
    }
}
