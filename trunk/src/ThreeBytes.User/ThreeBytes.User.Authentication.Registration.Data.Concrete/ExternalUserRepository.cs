using NHibernate.Criterion;
using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.Registration.Data.Abstract;
using ThreeBytes.User.Authentication.Registration.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Registration.Entities;

namespace ThreeBytes.User.Authentication.Registration.Data.Concrete
{
    public class ExternalUserRepository : KeyedGenericRepository<ExternalUser>, IExternalUserRepository
    {
        public ExternalUserRepository(IRegistrationUserDatabaseFactory databaseFactory, IRegistrationUserUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public bool UserExistsByEmail(string email, string applicationName)
        {
            return Session.QueryOver<ExternalUser>()
                    .Where(x => x.ApplicationName == applicationName)
                    .WithSubquery.WhereExists(QueryOver.Of<ExternalAuthenticator>()
                        .Where(y => y.Email == email && y.ApplicationName == applicationName)
                        .Select(y => y.Id))
                    .RowCount() == 1;
        }

        public ExternalUser GetUserByEmail(string email, string applicationName)
        {
            ExternalUser externalUserAlias = null;
            ExternalAuthenticator externalAuthenticator = null;

            return Session.QueryOver(() => externalUserAlias)
                .JoinAlias(() => externalUserAlias.ExternalAuthentications, () => externalAuthenticator)
                .Where(() => externalUserAlias.ApplicationName == applicationName)
                .And(() => externalAuthenticator.Email == email).SingleOrDefault();
        }

        public bool HasRecords(string applicationName)
        {
            return Session.QueryOver<ExternalUser>().Where(x => x.ApplicationName == applicationName).RowCount() > 0;
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Session.QueryOver<ExternalUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).RowCount() == 0;
        }
    }
}
