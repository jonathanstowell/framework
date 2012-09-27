using System;
using System.IO;
using System.Reflection;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Plugin.Abstract;

namespace ThreeBytes.Core.Plugin.Concrete
{
    public class HotSwap
    {
        private readonly string path;
        private readonly IResolveAssemblies resolveAssemblies;
        private readonly IWindsorContainer container;
        private readonly BootstrapEnvironment bootstrapEnvironment;

        public HotSwap(string path, IResolveAssemblies resolveAssemblies, IWindsorContainer container, BootstrapEnvironment bootstrapEnvironment)
        {
            this.path = path;
            this.resolveAssemblies = resolveAssemblies;
            this.container = container;
            this.bootstrapEnvironment = bootstrapEnvironment;
        }

        public void EnableHotSwap()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(path, "*.dll") { IncludeSubdirectories = true };

            watcher.Created += CodeChanged;
            watcher.Changed += CodeChanged;
            watcher.Renamed += CodeChanged;
            watcher.EnableRaisingEvents = true;
        }

        private void CodeChanged(object sender, FileSystemEventArgs e)
        {
            Assembly changedAssembly = Assembly.LoadFrom(e.FullPath);

            if (changedAssembly == null) 
                return;

            RegisterOrUpdateAssembly(e.FullPath, changedAssembly);

            Type[] types = changedAssembly.GetTypes();

            foreach (Type type in types)
            {
                try
                {
                    container.Kernel.ReleaseComponent(type.FullName);
                }
                catch (Exception)
                {}
            }

            foreach (Type type in types)
            {
                try
                {
                    if (bootstrapEnvironment == BootstrapEnvironment.WEB)
                    {
                        if (type == typeof (IWebWindsorRegistration))
                        {
                            IWebWindsorRegistration registration =
                                (IWebWindsorRegistration) Activator.CreateInstance(type);
                            registration.Install(container);
                        }
                    }

                    if (bootstrapEnvironment == BootstrapEnvironment.BUS)
                    {
                        if (type == typeof (IBusWindsorRegistration))
                        {
                            IBusWindsorRegistration registration =
                                (IBusWindsorRegistration) Activator.CreateInstance(type);
                            registration.Install(container);
                        }
                    }
                }
                catch (Exception)
                {}
            }
        }

        private void RegisterOrUpdateAssembly(string assemblyName, Assembly assembly)
        {
            var comma = assemblyName.IndexOf(',');
            resolveAssemblies.PluginAssembliesByFullName[assemblyName] = assembly;
            resolveAssemblies.PluginAssembliesByFullName[comma == -1 ? assemblyName : assemblyName.Substring(0, comma)] = assembly;
        }
    }
}
