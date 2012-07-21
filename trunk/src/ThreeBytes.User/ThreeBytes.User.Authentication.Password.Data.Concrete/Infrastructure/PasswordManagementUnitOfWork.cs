using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.Password.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.Password.Data.Concrete.Infrastructure
{
    public class PasswordManagementUnitOfWork : UnitOfWork, IPasswordManagementUnitOfWork
    {
        public PasswordManagementUnitOfWork(IPasswordManagementDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
