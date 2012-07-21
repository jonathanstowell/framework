using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Profile.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Profile.Management.Data.Concrete.Infrastructure
{
    public class ProvideProfileManagementSessionFactoryInitialisation : IProvideProfileManagementSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Profile.Management.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
