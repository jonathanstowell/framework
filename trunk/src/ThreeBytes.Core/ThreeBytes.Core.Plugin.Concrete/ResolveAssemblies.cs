using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Castle.Windsor;
using ThreeBytes.Core.Plugin.Abstract;

namespace ThreeBytes.Core.Plugin.Concrete
{
    public class ResolveAssemblies : IResolveAssemblies
    {
        private readonly string path;
        private readonly string[] patterns;

        private static Dictionary<string, Assembly> pluginAssembliesByFullName { get; set; }

        public static IWindsorContainer Container { get; set; }

        public ResolveAssemblies(string path, params string[] patterns)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            this.path = path;
            this.patterns = patterns;
            pluginAssembliesByFullName = new Dictionary<string, Assembly>();
            LoadPluginAssemblies();
        }

        public Dictionary<string, Assembly> PluginAssembliesByFullName
        {
            get
            {
                return pluginAssembliesByFullName;
            }
        }

        public Assembly GetAssembly(string name)
        {
            Assembly resolvedAssembly;
            if (TryGetAssembly(name, out resolvedAssembly))
            {
                return resolvedAssembly;
            }
            return null;
        }

        private void LoadPluginAssemblies()
        {
            var scanPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            var directory = new DirectoryInfo(scanPath);

            var files = new HashSet<FileInfo>();

            try
            {
                foreach (var pattern in patterns)
                {
                    var found = directory.GetFiles(pattern, SearchOption.AllDirectories);
                    files.UnionWith(found);
                }
            }
            catch (Exception)
            { }

            var ret = new List<Assembly>();

            foreach (var file in files)
            {
                var assembly = Assembly.LoadFrom(file.FullName);
                assembly.GetTypes();
                ret.Add(assembly);
                RegisterAssembly(assembly.FullName, assembly);
            }
        }

        private void RegisterAssembly(string assemblyName, Assembly assembly)
        {
            var comma = assemblyName.IndexOf(',');
            pluginAssembliesByFullName[assemblyName] = assembly;
            pluginAssembliesByFullName[comma == -1 ? assemblyName : assemblyName.Substring(0, comma)] = assembly;
        }

        private bool TryGetAssembly(string assemblyName, out Assembly assembly)
        {
            return PluginAssembliesByFullName.TryGetValue(assemblyName, out assembly);
        }
    }
}
