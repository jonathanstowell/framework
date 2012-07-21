using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Bootstrap;
using Bootstrap.Extensions.StartupTasks;
using Castle.Windsor;
using NServiceBus;

namespace ThreeBytes.Logging.WebUI.Installers
{
    public class NServiceBusStartupTask : IStartupTask
    {
        public void Run()
        {
            var assemblies = new DirectoryInfo(AppDomain.CurrentDomain.DynamicDirectory)
                                        .GetFiles("NServiceBus*.dll", SearchOption.AllDirectories)
                                        .Select(file => Assembly.LoadFrom(file.FullName));



            var bus = Configure.With(assemblies.Concat(MvcApplication.AssemblyResolver.PluginAssembliesByFullName.Values))
                        .Log4Net()
                        .CastleWindsorBuilder((IWindsorContainer)Bootstrapper.Container)
                        .XmlSerializer()
                        .MsmqTransport().IsTransactional(false)
                        .UnicastBus()
                            .LoadMessageHandlers()
                        .CreateBus()
                        .Start();

            MvcApplication.Bus = bus;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}