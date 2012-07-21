using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Logging.Exceptions.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.Logging.Exceptions.List.Data.Concrete.Infrastructure
{
    public class ProvideExceptionListSessionFactoryInitialisation : IProvideExceptionListSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteLoggingContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Logging.Exceptions.List.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
