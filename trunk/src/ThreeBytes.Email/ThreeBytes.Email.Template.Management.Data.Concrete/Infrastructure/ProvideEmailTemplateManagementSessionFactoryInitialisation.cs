using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Email.Template.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Template.Management.Data.Concrete.Infrastructure
{
    public class ProvideEmailTemplateManagementSessionFactoryInitialisation : IProvideEmailTemplateManagementSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteEmailContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Email.Template.Management.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
