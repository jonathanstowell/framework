using System.Collections.Generic;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Data.Abstract
{
    public interface IAuthenticationUserManagementRoleRepository : IKeyedGenericRepository<AuthenticationUserManagementRole>
    {
        IList<AuthenticationUserManagementRole> GetAll(string applicationName);
        AuthenticationUserManagementRole GetByName(string name);
        bool Exists(string name, string applicationName);
    }
}
