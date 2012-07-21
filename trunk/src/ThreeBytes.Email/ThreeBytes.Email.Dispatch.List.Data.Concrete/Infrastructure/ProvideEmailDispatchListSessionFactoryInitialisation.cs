using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Email.Dispatch.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dispatch.List.Data.Concrete.Infrastructure
{
    public class ProvideEmailDispatchListSessionFactoryInitialisation : IProvideEmailDispatchListSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteEmailContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Email.Dispatch.List.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
