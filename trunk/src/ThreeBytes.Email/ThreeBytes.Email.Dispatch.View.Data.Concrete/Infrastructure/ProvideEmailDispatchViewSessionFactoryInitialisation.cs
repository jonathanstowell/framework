using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Email.Dispatch.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dispatch.View.Data.Concrete.Infrastructure
{
    public class ProvideEmailDispatchViewSessionFactoryInitialisation : IProvideEmailDispatchViewSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteEmailContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Email.Dispatch.View.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
