using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Email.Template.Widget.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Template.Widget.Data.Concrete.Infrastructure
{
    public class ProvideEmailTemplateWidgetSessionFactoryInitialisation : IProvideEmailTemplateWidgetSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteEmailContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Email.Template.Widget.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
