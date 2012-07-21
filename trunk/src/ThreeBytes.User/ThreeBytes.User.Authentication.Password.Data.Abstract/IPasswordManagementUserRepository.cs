using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Authentication.Password.Entities;

namespace ThreeBytes.User.Authentication.Password.Data.Abstract
{
    public interface IPasswordManagementUserRepository : IKeyedGenericRepository<PasswordManagementUser>
    {
        PasswordManagementUser GetByUsernameOrEmail(string userIdentifier, string applicationName);
        bool UniqueUsername(string username, string applicationName);
        bool UniqueEmail(string email, string applicationName);
        bool ResetPasswordCodeMatches(Guid id, Guid code);
    }
}
