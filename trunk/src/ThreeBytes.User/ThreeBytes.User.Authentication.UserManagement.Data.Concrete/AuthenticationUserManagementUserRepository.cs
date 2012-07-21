using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.UserManagement.Data.Abstract;
using ThreeBytes.User.Authentication.UserManagement.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.UserManagement.Entities;

namespace ThreeBytes.User.Authentication.UserManagement.Data.Concrete
{
    public class AuthenticationUserManagementUserRepository : KeyedGenericRepository<AuthenticationUserManagementUser>, IAuthenticationUserManagementUserRepository
    {
        public AuthenticationUserManagementUserRepository(IAuthenticationUserManagementUserDatabaseFactory databaseFactory, IAuthenticationUserManagementUserUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public AuthenticationUserManagementUser GetByUsernameOrEmail(string userIdentifier, string applicationName)
        {
            return Session.QueryOver<AuthenticationUserManagementUser>().Where(x => (x.Username == userIdentifier || x.Email == userIdentifier) && x.ApplicationName == applicationName).SingleOrDefault();
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Session.QueryOver<AuthenticationUserManagementUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).RowCount() == 0;
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Session.QueryOver<AuthenticationUserManagementUser>().Where(x => x.Email == email && x.ApplicationName == applicationName).RowCount() == 0;
        }
    }
}
