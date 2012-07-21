using System.Collections.Generic;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Frontend.Models
{
    public class UpdateUserViewModel
    {
        public AuthenticationUserManagementUser User { get; set; }
        public IList<AuthenticationUserManagementRole> Roles { get; set; }

        public UpdateUserViewModel()
        {
            User = new AuthenticationUserManagementUser();
            Roles = new List<AuthenticationUserManagementRole>();
        }
    }
}
