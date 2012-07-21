using System;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Authentication.Password.Entities;

namespace ThreeBytes.User.Authentication.Password.Service.Abstract
{
    public interface IPasswordManagementUserService : IKeyedGenericService<PasswordManagementUser>
    {
        PasswordManagementUser GetByUsernameOrEmail(string userIdentifier, string applicationName);
        bool UniqueUsername(string username, string applicationName);
        bool UniqueEmail(string email, string applicationName);
        bool ResetPasswordCodeMatches(Guid id, Guid code);
    }
}
