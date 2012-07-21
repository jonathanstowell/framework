using System;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.UserView.Data.Abstract;
using ThreeBytes.User.Authentication.UserView.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.UserView.Entities;

namespace ThreeBytes.User.Authentication.UserView.Data.Concrete
{
    public class AuthenticationUserViewUserRepository : HistoricKeyedGenericRepository<AuthenticationUserViewUser>, IAuthenticationUserViewUserRepository
    {
        public AuthenticationUserViewUserRepository(IAuthenticationUserViewUserDatabaseFactory databaseFactory, IAuthenticationUserViewUserUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Session.QueryOver<AuthenticationUserViewUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).RowCount() == 0;
        }

        public bool UniqueEmail(Guid itemId, string email, string applicationName)
        {
            return Session.QueryOver<AuthenticationUserViewUser>().Where(x => x.Email == email && x.ApplicationName == applicationName && x.ItemId != itemId).RowCount() == 0;
        }
    }
}
