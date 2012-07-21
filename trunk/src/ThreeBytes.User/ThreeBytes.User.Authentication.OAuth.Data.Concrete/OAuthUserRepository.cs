using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.OAuth.Entities;
using ThreeBytes.User.Authentication.OAuth.Entities.Enums;

namespace ThreeBytes.User.Authentication.OAuth.Data.Concrete
{
    public class OAuthUserRepository : KeyedGenericRepository<OAuthUser>, IOAuthUserRepository
    {
        public OAuthUserRepository(IOAuthDatabaseFactory databaseFactory, IOAuthUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public OAuthUser GetBy(string username, string applicationName)
        {
            return Session.QueryOver<OAuthUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).SingleOrDefault();
        }

        public OAuthUser GetByEmail(string email, string applicationName)
        {
            OAuthUser OAuthUserAlias = null;
            ExternalAuthenticator externalAuthenticatorAlias = null;

            return Session.QueryOver(() => OAuthUserAlias)
                .Left.JoinAlias(() => OAuthUserAlias.ExternalAuthentications, () => externalAuthenticatorAlias)
                .Where(() => OAuthUserAlias.ApplicationName == applicationName && (OAuthUserAlias.Email == email || externalAuthenticatorAlias.Email == email))
                .SingleOrDefault();
        }

        public OAuthUser GetByUsernameOrEmail(string userIdentifier, string applicationName)
        {
            OAuthUser OAuthUserAlias = null;
            ExternalAuthenticator externalAuthenticatorAlias = null;

            return Session.QueryOver(() => OAuthUserAlias)
                .Left.JoinAlias(() => OAuthUserAlias.ExternalAuthentications, () => externalAuthenticatorAlias)
                .Where(() => OAuthUserAlias.ApplicationName == applicationName && (externalAuthenticatorAlias.Email == userIdentifier || externalAuthenticatorAlias.Email == userIdentifier))
                .SingleOrDefault();
        }

        public OAuthUser GetByExternalAuthenticatorIdentifier(string identifier, ExternalAuthenticationType provider, string applicationName)
        {
            OAuthUser OAuthUserAlias = null;
            ExternalAuthenticator externalAuthenticatorAlias = null;

            return Session.QueryOver(() => OAuthUserAlias)
                .JoinAlias(() => OAuthUserAlias.ExternalAuthentications, () => externalAuthenticatorAlias)
                .Where(() => OAuthUserAlias.ApplicationName == applicationName)
                .And(() => externalAuthenticatorAlias.ExternalAuthenticationType == provider && externalAuthenticatorAlias.ExternalIdentifier == identifier)
                .SingleOrDefault();
        }

        public bool HasRecords(string applicationName)
        {
            return Session.QueryOver<OAuthUser>().Where(x => x.ApplicationName == applicationName).RowCount() > 0;
        }

        public bool UniqueUsername(string username, string applicationName)
        {
            return Session.QueryOver<OAuthUser>().Where(x => x.Username == username && x.ApplicationName == applicationName).RowCount() == 0;
        }

        public bool UniqueEmail(string email, string applicationName)
        {
            return Session.QueryOver<OAuthUser>().Where(x => x.Email == email && x.ApplicationName == applicationName).RowCount() == 0;
        }
    }
}
