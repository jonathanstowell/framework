using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Role.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Role.View.Data.Concrete.Infrastructure
{
    public class ProvideRoleViewSessionFactoryInitialisation : IProvideRoleViewSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Role.View.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
