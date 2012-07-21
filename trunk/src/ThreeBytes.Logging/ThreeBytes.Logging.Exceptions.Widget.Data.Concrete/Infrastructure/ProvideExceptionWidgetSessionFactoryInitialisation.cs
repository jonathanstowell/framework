using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Logging.Exceptions.Widget.Data.Abstract.Infrastructure;

namespace ThreeBytes.Logging.Exceptions.Widget.Data.Concrete.Infrastructure
{
    public class ProvideExceptionWidgetSessionFactoryInitialisation : IProvideExceptionWidgetSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteLoggingContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Logging.Exceptions.Widget.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
