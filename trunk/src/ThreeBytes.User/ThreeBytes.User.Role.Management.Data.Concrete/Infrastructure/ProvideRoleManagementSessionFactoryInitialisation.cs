using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Role.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Role.Management.Data.Concrete.Infrastructure
{
    public class ProvideRoleManagementSessionFactoryInitialisation : IProvideRoleManagementSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Role.Management.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
