using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.Login.Data.Abstract;
using ThreeBytes.User.Authentication.Login.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Data.Concrete
{
    public class LoginUserRepository : KeyedGenericRepository<LoginUser>, ILoginUserRepository
    {
        public LoginUserRepository(ILoginUserDatabaseFactory databaseFactory, ILoginUserUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public LoginUser GetBy(string username, string applicationName)
        {
            return Session.QueryOver<LoginUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).SingleOrDefault();
        }

        public LoginUser GetBy(string username, string password, string applicationName)
        {
            return Session.QueryOver<LoginUser>().Where(x => (x.Username == username || x.Email == username) && x.Password == password && x.ApplicationName == applicationName).SingleOrDefault();
        }

        public LoginUser GetByUsernameOrEmail(string userIdentifier, string applicationName)
        {
            return Session.QueryOver<LoginUser>().Where(x => (x.Username == userIdentifier || x.Email == userIdentifier) && x.ApplicationName == applicationName).SingleOrDefault();
        }

        public bool HasRecords(string applicationName)
        {
            return Session.QueryOver<LoginUser>().Where(x => x.ApplicationName == applicationName).RowCount() > 0;
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Session.QueryOver<LoginUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).RowCount() == 0;
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Session.QueryOver<LoginUser>().Where(x => x.Email == email && x.ApplicationName == applicationName).RowCount() == 0;
        }

        public bool PasswordMatches(string username, string password, string applicationName)
        {
            return Session.QueryOver<LoginUser>().Where(x => x.Username == username && x.ApplicationName == applicationName && x.Password == password).SingleOrDefault() != null;
        }
    }
}
