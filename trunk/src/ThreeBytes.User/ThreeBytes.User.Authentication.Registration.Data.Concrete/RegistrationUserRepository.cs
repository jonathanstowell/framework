using System;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.Registration.Data.Abstract;
using ThreeBytes.User.Authentication.Registration.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Registration.Entities;

namespace ThreeBytes.User.Authentication.Registration.Data.Concrete
{
    public class RegistrationUserRepository : KeyedGenericRepository<RegistrationUser>, IRegistrationUserRepository
    {
        public RegistrationUserRepository(IRegistrationUserDatabaseFactory databaseFactory, IRegistrationUserUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public RegistrationUser GetByUsername(string username, string applicationName)
        {
            return Session.QueryOver<RegistrationUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).SingleOrDefault();
        }

        public RegistrationUser GetByUsernameOrEmail(string userIdentifier, string applicationName)
        {
            return Session.QueryOver<RegistrationUser>().Where(x => (x.Username == userIdentifier || x.Email == userIdentifier) && x.ApplicationName == applicationName).SingleOrDefault();
        }

        public bool HasRecords(string applicationName)
        {
            return Session.QueryOver<RegistrationUser>().Where(x => x.ApplicationName == applicationName).RowCount() > 0;
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Session.QueryOver<RegistrationUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).RowCount() == 0;
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Session.QueryOver<RegistrationUser>().Where(x => x.Email == email && x.ApplicationName == applicationName).RowCount() == 0;
        }

        public bool VerifyCodeMatches(Guid id, Guid verifiedCode)
        {
            return Session.QueryOver<RegistrationUser>().Where(x => x.Id == id && x.VerifiedCode == verifiedCode).SingleOrDefault() != null;
        }
    }
}
