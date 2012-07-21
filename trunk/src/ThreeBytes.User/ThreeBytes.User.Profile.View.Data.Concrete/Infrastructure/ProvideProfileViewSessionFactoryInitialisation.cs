using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Profile.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Profile.View.Data.Concrete.Infrastructure
{
    public class ProvideProfileViewSessionFactoryInitialisation : IProvideProfileViewSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Profile.View.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
