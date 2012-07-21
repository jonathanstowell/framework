using System;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.Password.Data.Abstract;
using ThreeBytes.User.Authentication.Password.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Password.Entities;

namespace ThreeBytes.User.Authentication.Password.Data.Concrete
{
    public class PasswordManagementUserRepository : KeyedGenericRepository<PasswordManagementUser>, IPasswordManagementUserRepository
    {
        public PasswordManagementUserRepository(IPasswordManagementDatabaseFactory databaseFactory, IPasswordManagementUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public PasswordManagementUser GetByUsernameOrEmail(string userIdentifier, string applicationName)
        {
            return Session.QueryOver<PasswordManagementUser>().Where(x => (x.Username == userIdentifier || x.Email == userIdentifier) && x.ApplicationName == applicationName).SingleOrDefault();
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Session.QueryOver<PasswordManagementUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).RowCount() == 0;
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Session.QueryOver<PasswordManagementUser>().Where(x => x.Email == email && x.ApplicationName == applicationName).RowCount() == 0;
        }

        public bool ResetPasswordCodeMatches(Guid id, Guid code)
        {
            return Session.Get<PasswordManagementUser>(id).ResetPasswordCode == code;
        }
    }
}
