using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.ProjectHollywood.Team.List.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Team.List.Data.Concrete.Infrastructure
{
    public class ProvideTeamListSessionFactoryInitialisation : IProvideTeamListSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ProjectHollywoodContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.ProjectHollywood.Team.List.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
