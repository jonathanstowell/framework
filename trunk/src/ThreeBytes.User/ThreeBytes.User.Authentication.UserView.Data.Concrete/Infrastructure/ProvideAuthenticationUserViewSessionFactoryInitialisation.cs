using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.User.Authentication.UserView.Data.Abstract.Infrastructure;

namespace ThreeBytes.User.Authentication.UserView.Data.Concrete.Infrastructure
{
    public class ProvideAuthenticationUserViewSessionFactoryInitialisation : IProvideAuthenticationUserViewSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteUsersContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.User.Authentication.UserView.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
