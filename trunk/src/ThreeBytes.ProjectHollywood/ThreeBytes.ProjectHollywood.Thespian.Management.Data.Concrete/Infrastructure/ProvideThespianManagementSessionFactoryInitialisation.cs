using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.ProjectHollywood.Thespian.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Thespian.Management.Data.Concrete.Infrastructure
{
    public class ProvideThespianManagementSessionFactoryInitialisation : IProvideThespianManagementSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ProjectHollywoodContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.ProjectHollywood.Thespian.Management.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
