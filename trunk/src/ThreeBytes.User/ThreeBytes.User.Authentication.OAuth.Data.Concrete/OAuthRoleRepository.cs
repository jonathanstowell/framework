using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.OAuth.Entities;

namespace ThreeBytes.User.Authentication.OAuth.Data.Concrete
{
    public class OAuthRoleRepository : KeyedGenericRepository<OAuthRole>, IOAuthRoleRepository
    {
        public OAuthRoleRepository(IOAuthDatabaseFactory databaseFactory, IOAuthUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public bool Exists(string name, string applicationName)
        {
            return Session.QueryOver<OAuthRole>()
                        .Where(x => x.Name == name)
                        .And(x => x.ApplicationName == applicationName)
                        .RowCount() != 0;
        }
    }
}
