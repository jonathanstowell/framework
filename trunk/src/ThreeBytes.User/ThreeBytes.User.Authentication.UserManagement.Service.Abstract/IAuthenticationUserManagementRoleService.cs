using System.Collections.Generic;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Service.Abstract
{
    public interface IAuthenticationUserManagementRoleService : IKeyedGenericService<AuthenticationUserManagementRole>
    {
        IList<AuthenticationUserManagementRole> GetAll(string applicationName);
        AuthenticationUserManagementRole GetByName(string name);
        bool Exists(string name, string applicationName);
    }
}
