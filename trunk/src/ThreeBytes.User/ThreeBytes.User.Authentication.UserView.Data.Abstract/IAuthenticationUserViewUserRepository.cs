using System;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.User.Authentication.UserView.Entities;

namespace ThreeBytes.User.Authentication.UserView.Data.Abstract
{
    public interface IAuthenticationUserViewUserRepository : IHistoricKeyedGenericRepository<AuthenticationUserViewUser>
    {
        bool UniqueUsername(string username, string applicationName);
        bool UniqueEmail(Guid itemId, string email, string applicationName);
    }
}
