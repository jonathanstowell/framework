using System;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.User.Authentication.UserView.Entities;

namespace ThreeBytes.User.Authentication.UserView.Service.Abstract
{
    public interface IAuthenticationUserViewUserService : IHistoricKeyedGenericService<AuthenticationUserViewUser>
    {
        bool UniqueUsername(string username, string applicationName);
        bool UniqueEmail(Guid itemId, string email, string applicationName);
    }
}
