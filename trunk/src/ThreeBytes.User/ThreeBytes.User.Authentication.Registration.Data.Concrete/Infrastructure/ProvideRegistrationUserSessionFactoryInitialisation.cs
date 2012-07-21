using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Authentication.Registration.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.Registration.Data.Concrete.Infrastructure
{
    public class ProvideRegistrationUserSessionFactoryInitialisation : IProvideRegistrationUserSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Authentication.Registration.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
