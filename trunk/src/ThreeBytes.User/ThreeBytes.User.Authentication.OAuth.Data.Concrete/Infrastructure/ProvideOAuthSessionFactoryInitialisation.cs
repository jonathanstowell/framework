using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Authentication.OAuth.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.OAuth.Data.Concrete.Infrastructure
{
    public class ProvideOAuthSessionFactoryInitialisation : IProvideOAuthSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Authentication.OAuth.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
