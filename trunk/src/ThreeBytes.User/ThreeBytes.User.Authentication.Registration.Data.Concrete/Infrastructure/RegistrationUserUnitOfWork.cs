using ThreeBytes.Core.Data.nHibernate.Concrete;
using ThreeBytes.User.Authentication.Registration.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.Registration.Data.Concrete.Infrastructure
{
    public class RegistrationUserUnitOfWork : UnitOfWork, IRegistrationUserUnitOfWork
    {
        public RegistrationUserUnitOfWork(IRegistrationUserDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
