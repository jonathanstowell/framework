using System;
using System.Linq;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using ThreeBytes.Core.Data.nHibernate.Abstract;

namespace ThreeBytes.Logging.ServiceHost.Installers
{
    public class InitialiseSessionFactories : IStartupTask
    {
        public void Run()
        {
            foreach (var databaseFactory in Bootstrapper.ContainerExtension.ResolveAll<IDatabaseFactory>().ToList())
            {
                var factory = databaseFactory.SessionFactory;
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
