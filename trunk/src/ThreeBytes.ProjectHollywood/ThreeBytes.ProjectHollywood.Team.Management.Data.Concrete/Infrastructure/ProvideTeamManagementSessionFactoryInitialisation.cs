using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.ProjectHollywood.Team.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.ProjectHollywood.Team.Management.Data.Concrete.Infrastructure
{
    public class ProvideTeamManagementSessionFactoryInitialisation : IProvideTeamManagementSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ProjectHollywoodContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.ProjectHollywood.Team.Management.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
