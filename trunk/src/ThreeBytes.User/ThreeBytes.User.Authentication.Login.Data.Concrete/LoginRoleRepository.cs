using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.Login.Data.Abstract;
using ThreeBytes.User.Authentication.Login.Data.Abstract.Infrastructure;
using ThreeBytes.User.Authentication.Login.Entities;

namespace ThreeBytes.User.Authentication.Login.Data.Concrete
{
    public class LoginRoleRepository : KeyedGenericRepository<LoginRole>, ILoginRoleRepository
    {
        public LoginRoleRepository(ILoginUserDatabaseFactory databaseFactory, ILoginUserUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {
        }

        public bool Exists(string name, string applicationName)
        {
            return Session.QueryOver<LoginRole>()
                        .Where(x => x.Name == name)
                        .And(x => x.ApplicationName == applicationName)
                        .RowCount() != 0;
        }
    }
}
