using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Email.Template.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Template.View.Data.Concrete.Infrastructure
{
    public class ProvideEmailTemplateViewSessionFactoryInitialisation : IProvideEmailTemplateViewSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteEmailContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Email.Template.View.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
