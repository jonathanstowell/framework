using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Role.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Role.List.Data.Concrete.Infrastructure
{
    public class ProvideRoleListSessionFactoryInitialisation : IProvideRoleListSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Role.List.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
