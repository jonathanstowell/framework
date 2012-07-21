using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.ProjectHollywood.Thespian.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Thespian.List.Data.Concrete.Infrastructure
{
    public class ProvideThespianListSessionFactoryInitialisation : IProvideThespianListSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ProjectHollywoodContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.ProjectHollywood.Thespian.List.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
