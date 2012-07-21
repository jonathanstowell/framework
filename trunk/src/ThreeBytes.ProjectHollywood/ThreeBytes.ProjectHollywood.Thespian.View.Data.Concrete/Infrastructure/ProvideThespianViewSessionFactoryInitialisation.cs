using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.ProjectHollywood.Thespian.View.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Thespian.View.Data.Concrete.Infrastructure
{
    public class ProvideThespianViewSessionFactoryInitialisation : IProvideThespianViewSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ProjectHollywoodContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.ProjectHollywood.Thespian.View.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
