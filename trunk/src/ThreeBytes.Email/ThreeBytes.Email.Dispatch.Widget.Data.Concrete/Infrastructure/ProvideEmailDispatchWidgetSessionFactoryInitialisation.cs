using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Email.Dispatch.Widget.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dispatch.Widget.Data.Concrete.Infrastructure
{
    public class ProvideEmailDispatchWidgetSessionFactoryInitialisation : IProvideEmailDispatchWidgetSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteEmailContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Email.Dispatch.Widget.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
