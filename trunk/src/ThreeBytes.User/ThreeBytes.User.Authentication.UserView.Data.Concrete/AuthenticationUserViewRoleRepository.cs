using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.UserView.Data.Abstract;
using ThreeBytes.User.Authentication.UserView.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.UserView.Entities;

namespace ThreeBytes.User.Authentication.UserView.Data.Concrete
{
    public class AuthenticationUserViewRoleRepository : KeyedGenericRepository<AuthenticationUserViewRole>, IAuthenticationUserViewRoleRepository
    {
        public AuthenticationUserViewRoleRepository(IAuthenticationUserViewUserDatabaseFactory databaseFactory, IAuthenticationUserViewUserUnitOfWork unitOfWork)
            : base(databaseFactory, unitOfWork)
        {
        }

        public bool Exists(string name, string applicationName)
        {
            return Session.QueryOver<AuthenticationUserViewRole>()
                       .Where(x => x.Name == name)
                       .And(x => x.ApplicationName == applicationName)
                       .RowCount() != 0;
        }
    }
}
