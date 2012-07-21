using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Logging.Exceptions.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.Logging.Exceptions.View.Data.Concrete.Infrastructure
{
    public class ProvideExceptionViewSessionFactoryInitialisation : IProvideExceptionViewSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteLoggingContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Logging.Exceptions.View.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
