using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ThreeBytes.Email.Dispatch.Management.Data.Abstract.Infrastructure;

namespace ThreeBytes.Email.Dispatch.Management.Data.Concrete.Infrastructure
{
    public class ProvideEmailDispatchManagementSessionFactoryInitialisation : IProvideEmailDispatchManagementSessionFactoryInitialisation
    {
        public ISessionFactory InitialiseSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008.ConnectionString(
                        c => c.FromConnectionStringWithKey("ThreeByteEmailContext")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("ThreeBytes.Email.Dispatch.Management.Entities.Mappings")))
                .BuildSessionFactory();
        }
    }
}
